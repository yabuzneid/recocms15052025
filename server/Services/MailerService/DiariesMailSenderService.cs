using Microsoft.Extensions.Options;
using MimeKit;
using RecoCms6.Config;
using RecoCms6.Data;
using RecoCms6.Models.RecoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Graph;
using RecoCms6.Services.GraphApi;
using Newtonsoft.Json;

namespace RecoCms6.Services.MailerService
{
    public class DiariesMailSenderService : IDiariesMailSenderService
    {
        [Inject]
        protected MailService mailService { get; set; }

        private readonly MailConfig _mailConfig;
        private readonly RecoDbContext _context;
        private readonly GraphApiAuthProvider _authProvider;

        public DiariesMailSenderService(MailConfig mailConfig, RecoDbContext context)
        {
            var generalsettings = context.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();
            
            mailConfig.Host = generalsettings.Host;
            mailConfig.Password = generalsettings.SystemEmailPassword;
            mailConfig.Username = generalsettings.SystemEmail;
            mailConfig.NameFrom = generalsettings.SystemNameFrom;
            mailConfig.Port = (int)generalsettings.Port;
            mailConfig.UseSSL = (bool)generalsettings.UseSSL;
            _mailConfig = mailConfig;
            _context = context;
        }

        public DiariesMailSenderService(GraphApiAuthProvider authProvider, RecoDbContext context)
        {
            var generalsettings = context.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();

            _authProvider = authProvider;
            _context = context;
        }

        public async Task<bool> SendMailAsync()
        {
            var diaryStatusId = _context.ParameterDetails.FirstOrDefault(x => x.ParamTypeDesc == "Diary Status" && x.ParamDesc == "Open").ParameterID;
            var diaries = _context.Diaries.Where(x => x.AbeyanceDate == DateTime.Now.Date && x.DiaryStatusID == diaryStatusId).ToList();
            var generalsettings = _context.GeneralSettings.Where(x => x.Active == true).FirstOrDefault();

            //var smtp = new MailKit.Net.Smtp.SmtpClient();

            MailboxAddress mailSender;

            //smtp.Connect(generalsettings.Host, (int)generalsettings.Port, MailKit.Security.SecureSocketOptions.StartTls);
            //smtp.Authenticate(generalsettings.SystemEmail, generalsettings.SystemEmailPassword);

            diaryStatusId = _context.ParameterDetails.FirstOrDefault(x => x.ParamTypeDesc == "Diary Status" && x.ParamDesc == "Sent").ParameterID;
            foreach (var diary in diaries)
            {

                try
                {
                    var claimNo = _context.Claims.FirstOrDefault(x => x.ClaimID == diary.ClaimID).ClaimNo;
                    var mailBody = diary.Details ?? string.Empty;
                    var diarySender = _context.ServiceProviders.First(x => x.Name == diary.EnteredBy || x.UserID == diary.EnteredBy);
                    
                    if (diarySender == null)
                        mailSender = MailboxAddress.Parse(_mailConfig.Username);
                    else
                        mailSender = MailboxAddress.Parse(diarySender.EmailAddress);

                    var mailMessage = new MimeMessage();
                    mailMessage.Subject = generalsettings.ApplicationName + " Reminder RE: " + claimNo + " - " + diary.Subject;
                    mailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = mailBody };
                    mailMessage.Sender = mailSender;
                    mailMessage.From.Add(mailSender);
                    //mailMessage.ReplyTo.Add(MailboxAddress.Parse(diarySender.EmailAddress.Trim()));

                    if (diary.Recipients == null || diary.Recipients.Trim() == String.Empty)  //Skip Diaries without recipients
                        continue;

                    diary.Recipients = diary.Recipients.Replace(',', ';');
                    var recipients = diary.Recipients.Split(';');

                    List<MailboxAddress> recipientsList = new List<MailboxAddress>();
                    foreach (var recipient in recipients)
                        recipientsList.Add(MailboxAddress.Parse(recipient.Trim()));
                    
                    mailMessage.To.AddRange(recipientsList);

                    if (mailService == null)
                        mailService = new MailService(_authProvider, _context);
                    
                    await mailService.SendMail(mailMessage);

                    //smtp.Send(mailMessage);
                    diary.DiaryStatusID = diaryStatusId;
                    await CreateSentNote(diary, claimNo);
                    _context.SaveChanges();
                }
                catch (Exception ex) //Add email to send to programmer if there's an issue with a diary.
                {
                    string jsonMessage = JsonConvert.SerializeObject(ex);
                    var errorLog = new ErrorLog()
                    {
                        ErrorMessage = jsonMessage,
                        ClaimID = diary.ClaimID,
                    };
                    _context.ErrorLogs.Add(errorLog);
                    _context.SaveChanges();
                }
            }
            //smtp.Disconnect(true);
            return true;
        }

        protected async Task CreateSentNote(Diary diary, String claimNo)
        {
            Note note = new Note();

            note.ID = Guid.NewGuid();
            note.Subject = "Diary Sent To: " + diary.Recipients + " Re: " + claimNo;
            note.Details = diary.Details;
            note.EnteredByID = diary.EnteredBy;
            note.ClaimID = diary.ClaimID;


            try
            {
                await _context.AddAsync(note);
            }
            catch { }
        }
    }
}
