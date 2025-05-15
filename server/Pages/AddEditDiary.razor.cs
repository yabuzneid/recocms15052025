using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using System.Runtime.CompilerServices;
using RecoCms6.Models.RecoDb;
using Microsoft.AspNetCore.Components;
using Microsoft.IdentityModel.Tokens;
using RecoCms6.Services;
using Newtonsoft.Json;

namespace RecoCms6.Pages
{
    public partial class AddEditDiaryComponent
    {
        private const string EmailSeparator = ", \n";
        [Inject]
        public MacroService MacroService { get; set; }

        public async Task<bool> SetFormByTemplateProperties()
        {
            var template = getDiaryTemplateResults.FirstOrDefault(x => x.DiaryTemplateID == TemplateID);

            diary.Subject = await MacroService.Replace(diary.ClaimID, template.Subject);
            diary.Details = await MacroService.Replace(diary.ClaimID, template.TemplateText);

            return true;
        }



        public List<string> ValidateRecipients()
        {
            var separator = ", \n";

            var emails = diary.Recipients
                .Split(separator)
                .Select(email => email.Trim())
                .ToList();
            if (emails.IsNullOrEmpty())
                throw new Exception("No email was provided.");

            return emails
                .Where(email => !IsValidEmail(email))
                .ToList();
        }

        bool IsValidEmail(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                    return false;

                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        protected async Task SaveErrorAsync(System.Exception exception)
        {
            try
            {
                var errorLog = new ErrorLog();
                errorLog.ClaimID = diary.ClaimID;
                errorLog.ErrorMessage = JsonConvert.SerializeObject(exception);
                errorLog.UserID = Security.User.Id;
                await RecoDb.CreateErrorLog(errorLog);
            }
            catch { }
        }

        public async Task UpdateDiary() 
        {
            try
            {
                //var executeResult0 = await Task.Run(async () =>
                //{
                    
                //    //return await RecoDb.UpdateDiaryForced((Guid)diary.ID, diary);
                //});
                DialogService.Close(await RecoDb.UpdateDiaryForced((Guid)diary.ID, diary));
            }
            catch (System.Exception exception)
            {
                _ = SaveErrorAsync(exception);
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to edit Diary!");
            }

        }
    }
}
