using Microsoft.Graph;
using RecoCms6.Data;
using RecoCms6.Models;
using RecoCms6.Models.RecoDb;
using RecoCms6.Services.GraphApi;
using RecoCms6.Services.TemplateEngine;
using RecoCms6.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MimeKit;
using Microsoft.Identity.Client;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;

namespace RecoCms6.Services
{
    public class MailService
    {
        private GraphServiceClient _graphClient;
        private RecoDbContext _dbContext;

        public MailService(GraphApiAuthProvider authProvider, RecoDbContext dbService)
        {
            _graphClient = new GraphServiceClient(authProvider);
            _dbContext = dbService;
        }

        public async Task<string> UserName() => (await getUser()).DisplayName;
        public async Task<string> UserEmail()
        {
            try
            {
                var user = await getUser();

                return new string[] { user.Mail, user.OtherMails?.FirstOrDefault(), user.UserPrincipalName }
                    .FirstOrDefault(x => !string.IsNullOrWhiteSpace(x));
            }
            catch (Exception ex)
            {
                if (!ex.Message.Contains("Authorization_RequestDenied"))
                {
                    throw ex;
                }
            }
            return string.Empty;
        }

        //partial void OnSendEmail(System.Net.Mail.MailMessage mailMessage);

        //public async Task SendEmail(ApplicationUser user, string code, string callbackUrl, string subject, string text)
        //{
        //    var client = new System.Net.Mail.SmtpClient("smtpout.secureserver.net");
        //    client.UseDefaultCredentials = false;

        //    client.EnableSsl = true;

        //    client.Credentials = new System.Net.NetworkCredential("info@xlgclaims.com", "Test1234!");

        //    var mailMessage = new System.Net.Mail.MailMessage();
        //    mailMessage.From = new System.Net.Mail.MailAddress("info@xlgclaims.com");
        //    mailMessage.To.Add(user.Email);
        //    if (callbackUrl != null)
        //    {
        //        mailMessage.Body = string.Format(@"<a href=""{0}"">{1}</a>", callbackUrl, text);
        //    }
        //    else
        //    {
        //        mailMessage.Body = text;
        //    }

        //    mailMessage.Subject = subject;
        //    mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
        //    mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
        //    mailMessage.IsBodyHtml = true;

        //    //OnSendEmail(mailMessage);

        //    await client.SendMailAsync(mailMessage);
        //}

        /// <summary>
        /// TODO: Change to a system email address!
        /// </summary>
        public async Task SendReportMail(ClaimReportDetail report, ApplicationUser user, string reportHtml)
        {
            string subject = String.Empty;

            subject = report.ApplicationName;
            if (report.ClaimReportFlag != String.Empty)
                subject = subject + " " + report.ClaimReportFlag;

            var message = new MimeKit.MimeMessage
            {
                Subject = subject + " Claim Report Filed By " + report.SubmittedByName + " For  " + report.ClaimNo,
                Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = reportHtml
                }
            };

            List<MailboxAddress> recipientsList = new List<MailboxAddress>();
            recipientsList.Add(MailboxAddress.Parse(report.FileHandlerEmailAddress));

            message.To.Add(MailboxAddress.Parse(report.FileHandlerEmailAddress));
            if (!String.IsNullOrEmpty(report.UploadedByEmail))
            {
                message.Cc.Add(MailboxAddress.Parse(report.UploadedByEmail));
                message.ReplyTo.Add(MailboxAddress.Parse(report.UploadedByEmail));
            }

            message.ReplyTo.Add(MailboxAddress.Parse(user.Email));
            if (report.ReportsToEmail != null)
            {
                String[] reportsToList = report.ReportsToEmail.Split(',');
                foreach (string reportTo in reportsToList)
                    message.Cc.Add(MailboxAddress.Parse(reportTo));
            }

            var generalsettings = _dbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            message.From.Add(MailboxAddress.Parse(generalsettings.SystemEmail));

            await SendMail(message);
            //var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect(generalsettings.Host, (int)generalsettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            //smtp.Authenticate(generalsettings.SystemEmail, generalsettings.SystemEmailPassword);
            //await smtp.SendAsync(message);
            //smtp.Disconnect(true);

            //await _graphClient.Me
            //  .SendMail(message, true)
            //  .Request()
            //  .PostAsync();
        }

        //CP/CD version of SendReportMail function
        public async Task SendReportMail(ClaimReportDetail report, ApplicationUser user, string reportHtml, ClaimList masterclaimlist)
        {
            string subject = String.Empty;

            subject = report.ApplicationName;
            if (report.ClaimReportFlag != String.Empty)
                subject = subject + " " + report.ClaimReportFlag;

            var message = new MimeKit.MimeMessage
            {
                Subject = subject + " Claim Report Filed By " + report.SubmittedByName + " For  " + report.ClaimNo,
                Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = reportHtml
                }
            };

            List<MailboxAddress> recipientsList = new List<MailboxAddress>();
            recipientsList.Add(MailboxAddress.Parse(masterclaimlist.FileHandlerEmailAddress));

            message.To.Add(MailboxAddress.Parse(masterclaimlist.FileHandlerEmailAddress));
            if (!String.IsNullOrEmpty(report.UploadedByEmail))
            {
                message.Cc.Add(MailboxAddress.Parse(report.UploadedByEmail));
                message.ReplyTo.Add(MailboxAddress.Parse(report.UploadedByEmail));
            }

            message.ReplyTo.Add(MailboxAddress.Parse(user.Email));
            if (masterclaimlist.ReportsToEmail != null)
            {
                String[] reportsToList = masterclaimlist.ReportsToEmail.Split(',');
                foreach (string reportTo in reportsToList)
                    message.Cc.Add(MailboxAddress.Parse(reportTo));
            }

            var generalsettings = _dbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            message.From.Add(MailboxAddress.Parse(generalsettings.SystemEmail));

            await SendMail(message);

            //var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect(generalsettings.Host, (int)generalsettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            //smtp.Authenticate(generalsettings.SystemEmail, generalsettings.SystemEmailPassword);
            //await smtp.SendAsync(message);
            //smtp.Disconnect(true);

            //await _graphClient.Me
            //  .SendMail(message, true)
            //  .Request()
            //  .PostAsync();
        }

        public async Task SendMail(Message message, String userEmail = "")
        {

            List<Recipient> replyTos = new List<Recipient>();

            string[] scopes = new string[] { "https://graph.microsoft.com/.default" };

            var generalsettings = _dbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            string clientId = generalsettings.SystemClientID;
            string tenantId = generalsettings.SystemTenantID;
            string clientSecret = generalsettings.SystemSecretKey;
            string userObjectID = String.Empty;


            var serviceProvider = _dbContext.ServiceProviders.FirstOrDefault(x => x.EmailAddress == userEmail && x.ServiceProviderObjectID != null);
            if (serviceProvider != null)
                userObjectID = serviceProvider.ServiceProviderObjectID;

            if (userObjectID.IsNullOrEmpty())
            {
                userObjectID = generalsettings.SystemObjectID;
                message.From = new Recipient { EmailAddress = new EmailAddress { Address = generalsettings.SystemEmail } };

                if (message.ReplyTo == null && userEmail != String.Empty)
                {
                    replyTos.Add(new Microsoft.Graph.Recipient { EmailAddress = new Microsoft.Graph.EmailAddress { Address = userEmail } });
                    message.ReplyTo = replyTos;
                }
            }
                

            IConfidentialClientApplication confidentialClient = ConfidentialClientApplicationBuilder
                .Create(clientId)
                .WithClientSecret(clientSecret)
                .WithAuthority(new Uri($"https://login.microsoftonline.com/{tenantId}/v2.0"))
                .Build();

            // Retrieve an access token for Microsoft Graph (gets a fresh token if needed).
            var authResult = await confidentialClient
                    .AcquireTokenForClient(scopes)
                    .ExecuteAsync().ConfigureAwait(false);

            var token = authResult.AccessToken;
            // Build the Microsoft Graph client. As the authentication provider, set an async lambda
            // which uses the MSAL client to obtain an app-only access token to Microsoft Graph,
            // and inserts this access token in the Authorization header of each API request.
            GraphServiceClient graphServiceClient =
                new GraphServiceClient(new DelegateAuthenticationProvider(async (requestMessage) =>
                {
                    // Add the access token in the Authorization header of the API request.
                    requestMessage.Headers.Authorization =
                            new AuthenticationHeaderValue("Bearer", token);
                })
                );

            await graphServiceClient.Users[userObjectID]
                  .SendMail(message, false)
                  .Request()
                  .PostAsync();
        }

        public async Task SendMail(MimeMessage mime)
        {
            var tos = new List<Recipient>();
            var ccs = new List<Recipient>();
            var replyTos = new List<Recipient>();
            var froms = new List<Recipient>();
            var attachments = new MessageAttachmentsCollectionPage();

            foreach (var i in mime.To)
                tos.Add(new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = i.ToString()
                    }
                });

            foreach (var i in mime.Cc)
                ccs.Add(new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = i.ToString()
                    }
                });

            foreach (var i in mime.ReplyTo)
                replyTos.Add(new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = i.ToString()
                    }
                });


            foreach (var i in mime.From)
                froms.Add(new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = i.ToString()
                    }
                });

            foreach (var i in mime.Attachments)
            {
                using (var memory = new MemoryStream())
                {
                    i.WriteTo(memory);
                    memory.Seek(0, SeekOrigin.Begin);

                    byte[] file = new byte[memory.Length];
                    memory.Read(file, 0, (int)memory.Length);
                    attachments.Add(new FileAttachment
                    {
                        //Still need to set up
                        Name = i.ContentDisposition.FileName,
                        ContentBytes = file,
                        ContentType = i.ContentType.Name
                    });
                }
            }

            var message = new Microsoft.Graph.Message
            {
                Subject = mime.Subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = mime.HtmlBody??mime.TextBody
                },
                ToRecipients = tos,
                CcRecipients = ccs,
                ReplyTo = replyTos,
                From = froms.FirstOrDefault(),
                Attachments = attachments
            };

            await SendMail(message, mime.From.FirstOrDefault().ToString());
            //var generalsettings = _dbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            //var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect(generalsettings.Host, (int)generalsettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            //smtp.Authenticate(generalsettings.SystemEmail, generalsettings.SystemEmailPassword);
            //await smtp.SendAsync(message);
            //smtp.Disconnect(true);
        }
        private IEnumerable<Recipient> SplitAndTrimRecipients(string input)
        {
            if (input == String.Empty)
                return new List<Recipient>();

            input = input.Replace(";", ",");
            return input.Split(",").Select(x => new Recipient { EmailAddress = new EmailAddress { Address = x.Trim() } }).ToList();
        }

        public async Task SendMail(RecoMail recoMail, ApplicationUser user, bool saveToSentItems = false)
        {
            List<Recipient> recipientsList = new List<Recipient>();
            List<Recipient> ccList = new List<Recipient>();
            List<Recipient> bccList = new List<Recipient>();

            Recipient emailFrom = new Recipient { EmailAddress = new EmailAddress { Address = user.Email.Trim() } };
            
            foreach (var recipient in recoMail.To)
                recipientsList.AddRange(SplitAndTrimRecipients(recipient));

            //recipientsList.Add(new Recipient { EmailAddress = new EmailAddress { Address = recipient.Trim() } });

            if (recoMail.CC != null)
                foreach (var recipient in recoMail.CC)
                    ccList.AddRange(SplitAndTrimRecipients(recipient));

            //ccList.Add(new Recipient { EmailAddress = new EmailAddress { Address = recipient.Trim() } });

            if (recoMail.BCC != null)
                foreach (var recipient in recoMail.BCC)
                    bccList.AddRange(SplitAndTrimRecipients(recipient));

            //bccList.Add(new Recipient { EmailAddress = new EmailAddress { Address = recipient.Trim() } });

            var message = new Microsoft.Graph.Message
            {
                Subject = recoMail.Subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = recoMail.Message
                },
                ToRecipients = recipientsList,
                CcRecipients = ccList,
                BccRecipients = bccList,
                From = emailFrom
            };

            //var builder = new BodyBuilder();

            //// Set the plain-text version of the message text
            //builder.HtmlBody = recoMail.Message;
            MessageAttachmentsCollectionPage attachments = new MessageAttachmentsCollectionPage();

            if (recoMail.ClaimFiles?.Count > 0)
                recoMail.ClaimFiles.ForEach(file =>
                {
                    attachments.Add(new FileAttachment { Name = file.Filename,ContentBytes=file.StoredDocument, ContentType = file.ContentType });
                });

            if (recoMail.Files?.Count > 0)
                foreach (var file in recoMail.Files)
                    attachments.Add(new FileAttachment { Name = file.Name, ContentBytes = await ToByteArray(file.Data)});

            if (recoMail.Notes?.Count > 0)
            {
                string result = TemplateBuilder.BuildNotesAttachment(recoMail);
                attachments.Add(new FileAttachment { Name = "Notes.pdf", ContentBytes = result.ToPDFByteArray(), ContentType="application/pdf" });
            }

            if (attachments.Count > 0)
                message.Attachments = attachments;

            await SendMail(message, user.Email);

            //var generalsettings = _dbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            //var smtp = new MailKit.Net.Smtp.SmtpClient();
            //smtp.Connect(generalsettings.Host, (int)generalsettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            //smtp.Authenticate(generalsettings.SystemEmail, generalsettings.SystemEmailPassword);
            //await smtp.SendAsync(message);
            //smtp.Disconnect(true);

            //await _graphClient.Me
            //  .SendMail(message, saveToSentItems)
            //  .Request()
            //  .PostAsync();
        }

        public async Task SendPaymentMail(RecoMail recoMail, bool saveToSentItems = false)
        {
            var generalsettings = _dbContext.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            var client = new System.Net.Mail.SmtpClient(generalsettings.Host);
            client.UseDefaultCredentials = false;

            client.EnableSsl = true;

            client.Credentials = new System.Net.NetworkCredential(generalsettings.SystemEmail, generalsettings.SystemEmailPassword);

            var mailMessage = new System.Net.Mail.MailMessage();
            mailMessage.From = new System.Net.Mail.MailAddress(generalsettings.SystemEmail);

            foreach (string userAddress in recoMail.To)
                mailMessage.To.Add(userAddress);

            foreach (string userAddress in recoMail.CC)
                mailMessage.CC.Add(userAddress);

            var message = new Message
            {
                Subject = recoMail.Subject,
                Body = new ItemBody
                {
                    ContentType = BodyType.Html,
                    Content = recoMail.Message
                },
                ToRecipients = recoMail.To.Select(x => new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = x
                    }
                }).ToList(),
                CcRecipients = recoMail.CC.Select(x => new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = x
                    }
                }).ToList()
            };

            if (recoMail.HasFiles())
            {
                message.Attachments = new MessageAttachmentsCollectionPage();
            }

            if (recoMail.ClaimFiles?.Count > 0)
                recoMail.ClaimFiles.ForEach(file =>
                {
                    mailMessage.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(file.StoredDocument), file.Filename));
                });

            if (recoMail.Files?.Count > 0)
            {
                foreach (var file in recoMail.Files)
                {
                    mailMessage.Attachments.Add(new System.Net.Mail.Attachment(file.Data, file.Name));
                }
            }

            if (recoMail.Notes?.Count > 0)
            {
                string result = TemplateBuilder.BuildNotesAttachment(recoMail);
                mailMessage.Attachments.Add(new System.Net.Mail.Attachment(new MemoryStream(result.ToPDFByteArray()), "Payment.pdf", "application/pdf"));
            }

            //await _graphClient.Me
            //  .SendMail(message, saveToSentItems)
            //  .Request()
            //  .PostAsync();

            mailMessage.Body = recoMail.Message;

            mailMessage.Subject =" Payment - " + recoMail.Claimlist.ClaimNo;
            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.SubjectEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;

            //OnSendEmail(mailMessage);

            await client.SendMailAsync(mailMessage);
        }
        public async Task SendMail(Message message, bool saveToSentItems = false)
        {
            await _graphClient.Me
              .SendMail(message, saveToSentItems)
              .Request()
              .PostAsync();
        }

        public async Task<List<Message>> GetMessages(int? skip = 0, int? top = 20)
        {
            var messages = await _graphClient.Me.Messages
            .Request()
            .Select("receivedDateTime,sender,subject,body")
            .Skip(skip.Value)
            .Top(top.Value)
            .GetAsync();

            return messages.ToList();
        }

        public async Task<List<RecoMessage>> GetRecoMessages(int? skip = 0, int? top = 20)
        {
            var result = (await this.GetMessages(skip, top)).Select(x => new RecoMessage()
            {
                Message = x
            }).ToList();

            // check if one of the messages was attached to a claim or not
            var messageIds = result.Select(x => x.Message.Id).ToList();
            var links = (from link in _dbContext.EmailLinkFiles
                         join claim in _dbContext.Claims
                         on link.ClaimID equals claim.ClaimID
                         where messageIds.Contains(link.MailID)
                         select new
                         {
                             MailID = link.MailID,
                             Claim = claim
                         }).ToList();

            result.ForEach(x =>
            {
                if (links.Any(y => x.Message.Id == y.MailID))
                {
                    x.Claim = links.FirstOrDefault(y => y.MailID == x.Message.Id)?.Claim;
                }
            });

            return result;
        }


        public async Task<Message> GetMessage(string Id)
        {
            var messages = await _graphClient.Me.Messages[Id]
            .Request()
            .Select("receivedDateTime,toRecipients,from,sender,subject,body")
            .GetAsync();

            return messages;
        }

        private async Task<User> getUser()
            => await _graphClient.Me.Request()
                .Select("mail")
                .GetAsync();


        private async Task<Byte[]> ToByteArray(Stream stream)
        {
            var ms = new MemoryStream();
            
            await stream.CopyToAsync(ms);

            return ms.ToArray();
        }
    }
}
