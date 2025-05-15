using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using RecoCms6.Data;
using RecoCms6.Models;
using RecoCms6.Models.RecoDb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using File = RecoCms6.Models.RecoDb.File;

namespace RecoCms6.Services.Background.MailServices
{

    public class AttachmentMailHandler : IAutomaticMailHandler
    {
        protected IConfiguration Configuration { get; }
        protected RecoDbContext DbContext { get; }
        protected UserManager<ApplicationUser> UserManager { get; }
        protected GraphServiceClient graphServiceClient { get; set; }
        protected String userId { get; set; }
        protected String inboxId { get; set; }
        protected String nonProcessedId { get; set; }
        protected String failedId { get; set; }
        protected String processedId { get; set; }
        protected AuthenticationResult authResult { get; set; }

        protected string clientId { get; set; }
        protected string tenantId { get; set; }
        protected string clientSecret { get; set; }

        public AttachmentMailHandler(IConfiguration configuration, RecoDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            Configuration = configuration;
            DbContext = dbContext;
            UserManager = userManager;

            var generalsettings = DbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            clientId = generalsettings.SystemClientID;
            tenantId = generalsettings.SystemTenantID;
            clientSecret = generalsettings.SystemSecretKey;
            userId = generalsettings.BindAttachmentsObjectID;
        }

        protected bool IsSelectable(Message message)
        {
            bool bIsRECO = DbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault().ApplicationName == "RECO CMS";
            string claimId;
            return message.TryGetClaimId(bIsRECO, out claimId);
        }

        protected string GetSenderUserId(string email)
        {
            bool allowAnonym = (bool)DbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault().AllowAnonymousProcessing;

            var findUserResult = UserManager.FindByEmailAsync(email);
            findUserResult.Wait();
            var user = findUserResult.Result?.Id;

            if (user == null && allowAnonym)
            {
                var systemEmail = DbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault().SystemEmail;
                if (systemEmail != null)  //Attach file using system id if user can't be found
                {
                    findUserResult = UserManager.FindByEmailAsync(email);
                    findUserResult.Wait();
                    user = findUserResult.Result?.Id;

                    if (user != null)
                        return user;
                }

                var userid = DbContext.UserDetails.Where(x => x.Role == "Program Manager" && x.PrimeUser == true).FirstOrDefault().Id;
                return userid;
            }

            return user ?? throw new Exception("Emails from non-registered users are non-processable!");

        }

        protected int? GetFileType(string contentType)
        {
            switch (contentType)
            {
                case "image/gif":
                case "image/png":
                case "image/jpg": return 661;
                case "application/pdf":
                case "application/msword":
                case "application/vnd.openxmlformats-officedocument.wordprocessingml.document": return 35;
                default: return 33; //Default to File
            };
        }


        [DisableConcurrentExecution(60), AutomaticRetry(Attempts = 0)]
        public virtual async Task Process()
        {
            try
            {
                await InitGraphServiceClient();

                //Get inbox
                var inboxMsgs = graphServiceClient.Users[userId].MailFolders.Inbox.Request().GetAsync().Result;

                var childFolders = await graphServiceClient.Users[userId].MailFolders.Inbox.ChildFolders
                    .Request()
                    .GetAsync();

                //Get folder ids
                foreach (var folder in childFolders)
                {
                    if (folder.DisplayName == "Non-Processable")
                        nonProcessedId = folder.Id;
                    else if (folder.DisplayName == "Processed")
                        processedId = folder.Id;
                    else if (folder.DisplayName == "Failed")
                        failedId = folder.Id;
                }

                // Ensure child folders exist
                if (string.IsNullOrEmpty(nonProcessedId))
                {
                    await CreateInboxChildFolder("Non-Processable");
                }
                if (string.IsNullOrEmpty(processedId))
                {
                    await CreateInboxChildFolder("Processed");
                }
                if (string.IsNullOrEmpty(failedId))
                {
                    await CreateInboxChildFolder("Failed");
                }

                if (!(string.IsNullOrEmpty(nonProcessedId) && string.IsNullOrEmpty(failedId) && string.IsNullOrEmpty(processedId)))
                {
                    var messages = await graphServiceClient.Users[userId].MailFolders[inboxMsgs.Id].Messages
                        .Request()
                        .GetAsync();

                    foreach (var message in messages)
                    {
                        if (!IsSelectable(message))
                        {
                            await MoveMessageToFolder(message.Id, nonProcessedId);
                        }
                        else if (await Process(message))
                        {
                            await MoveMessageToFolder(message.Id, processedId);
                        }
                        else
                        {
                            await MoveMessageToFolder(message.Id, failedId);
                        }
                    }
                }
                graphServiceClient = null;
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                var errorLog = new ErrorLog()
                {
                    ErrorMessage = jsonMessage
                };
                DbContext.ErrorLogs.Add(errorLog);
                DbContext.SaveChanges();
            }
        }

        protected virtual async Task InitGraphServiceClient()
        {
            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };

            IConfidentialClientApplication confidentialClient = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}/v2.0"))
                .Build();

            // Retrieve an access token for Microsoft Graph (gets a fresh token if needed).
            authResult = await confidentialClient
                    .AcquireTokenForClient(scopes)
                    .ExecuteAsync().ConfigureAwait(false);

            var token = authResult.AccessToken;
            // Build the Microsoft Graph client. As the authentication provider, set an async lambda
            // which uses the MSAL client to obtain an app-only access token to Microsoft Graph,
            // and inserts this access token in the Authorization header of each API request.

            graphServiceClient = new GraphServiceClient(new DelegateAuthenticationProvider(async (requestMessage) =>
                // Add the access token in the Authorization header of the API request.
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token))
                );
        }

        protected async Task CreateInboxChildFolder(string displayName)
        {
            var mailFolder = new Microsoft.Graph.MailFolder
            {
                DisplayName = displayName
            };

            await graphServiceClient.Users[userId].MailFolders.Inbox.ChildFolders
                .Request()
                .AddAsync(mailFolder);
        }

        protected async Task MoveMessageToFolder(string messageId, string folderId)
        {
            await graphServiceClient.Users[userId].Messages[messageId]
                .Move(folderId)
                .Request()
                .PostAsync();
        }

        protected virtual async Task<bool> Process(Message message)
        {
            bool bIsRECO = DbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault().ApplicationName == "RECO CMS";
            List<string> imageExtensions = new List<string> { ".jpg", ".jpeg", ".gif", ".png" };

            string claimId;
            if (!message.TryGetClaimId(bIsRECO, out claimId))
            {
                return false;
            }
            var claim = DbContext.Claims.FirstOrDefault(c => c.ClaimNo == claimId);
            if (claim == null)
                return false;
            try
            {

                var attachments = await graphServiceClient.Users[userId].Messages[message.Id].Attachments
                .Request()
                .GetAsync();

                foreach (FileAttachment attachment in attachments)
                {

                    //Do not attach image files from email.
                    if (imageExtensions.Contains(Path.GetExtension(attachment.Name)))
                        continue;

                    var data = attachment.ContentBytes;
                    var entry = new File()
                    {
                        ID = Guid.NewGuid(),
                        ClaimID = claim.ClaimID,
                        Extension = Path.GetExtension(attachment.Name),
                        Subject = Path.GetFileNameWithoutExtension(attachment.Name),
                        Filename = attachment.Name,
                        EntryDate = DateTime.Now, // it can be converted to a specific timezone if needed
                        StoredDocument = data,
                        UploadedById = GetSenderUserId(message.From.EmailAddress.Address),
                        ContentType = attachment.ContentType,
                        FileTypeID = GetFileType(attachment.ContentType)
                    };
                    DbContext.Files.Add(entry);
                    DbContext.SaveChanges();
                    //DbContext.FilesRoles.AddRange(entry.GetDefaultRoles());
                    //DbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                var errorLog = new ErrorLog()
                {
                    ErrorMessage = jsonMessage,
                    ClaimID = claim.ClaimID,
                };
                DbContext.ErrorLogs.Add(errorLog);
                DbContext.SaveChanges();
                return false;
            }

            return true;
        }

    }
}
