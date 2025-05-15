using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components.Web;
using RecoCms6.Data;
using Microsoft.AspNetCore.Components;
using RecoCms6.Models.RecoDb;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace RecoCms6.Pages
{
    public partial class AddClaimantComponent
    {
        [Inject]
        public RecoDbContext DbContext { get; set; }

        protected RadzenUpload upload0;
        protected RadzenUpload upldTradeRecordSheet;
        protected RadzenUpload upldAgreementOfSale;
        protected RadzenUpload upldCommissionInvoice;
        protected RadzenUpload upldBuilderAgreements;
        protected RadzenUpload upldStatementOfAdjustments;
        protected RadzenUpload upldSplitCommissionChk;
        protected RadzenUpload upldNsfCommissionChk;

        protected RadzenProgressBar progressbar0;

        protected async System.Threading.Tasks.Task UploadClick(MouseEventArgs args)
        {
            await upload0.Upload();
        }

        public Claimant Get(int claimantID) 
        {
            return DbContext.Claimants
                .FirstOrDefault(x => x.ClaimantID == claimantID);
        }
      
        public void CreateAndLinkLitigationRoles()
        {

            if (claimant.ClaimantLitigationRoles == null)
                claimant.ClaimantLitigationRoles = new System.Collections.ObjectModel.Collection<ClaimantLitigationRole>();
            else
                claimant.ClaimantLitigationRoles.Clear();

            var toDelete = DbContext.ClaimantLitigationRoles.Where(x => x.ClaimantID == this.claimant.ClaimantID);
            DbContext.ClaimantLitigationRoles.RemoveRange(toDelete);


            foreach (int roleId in Roles)
            {
                claimant.ClaimantLitigationRoles.Add(new ClaimantLitigationRole()
                {
                    ClaimantID = this.claimant.ClaimantID,
                    LitigationRole = roleId
                });
            }
        }
        public async Task<int> CreateAndLinkLitigationRolesOld()
        {
            if (claimant.ClaimantID == 0)
            {
                DbContext.Claimants.Add(claimant);
            }
            DbContext.SaveChanges();

            var toDelete = DbContext.ClaimantLitigationRoles.Where(x => x.ClaimantID == this.claimant.ClaimantID);
            DbContext.ClaimantLitigationRoles.RemoveRange(toDelete);

            var toInsert = this.Roles.Select(roleId => new ClaimantLitigationRole()
            {
                ClaimantID = this.claimant.ClaimantID,
                LitigationRole = roleId
            });

            
            DbContext.ClaimantLitigationRoles.AddRange(toInsert);

            return await DbContext.SaveChangesAsync();
        }

        protected void Validate()
        {
            rfvClaimantName = string.IsNullOrEmpty(claimant.Name);

            if (string.IsNullOrEmpty(claimant.EmailAddress))
                rfvClaimantEmail = false;
            else
                rfvClaimantEmail = !IsEmailValid(claimant.EmailAddress);

            Regex regex = new Regex(@"([ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy][0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy])\ ?([0-9][ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy][0-9])");
            if (claimant.PostalCode != null && claimant.PostalCode != String.Empty)
            {
                Match match = regex.Match(claimant.PostalCode);
                rfvClaimantPostalCode = !match.Success;
            }
            else
                rfvClaimantPostalCode = false;


            if (solicitor.EmailAddress == String.Empty || solicitor.EmailAddress == null)
                rfvSolicitorEmail = false;
            else
                rfvSolicitorEmail = !IsEmailValid(solicitor.EmailAddress);

            rfvClaimantSolicitor = claimant.ClaimantSolicitorID is null;

            bPageIsValid = !(rfvClaimantName || rfvClaimantEmail || rfvClaimantPostalCode || rfvSolicitorEmail); //|| rfvClaimantSolicitor);
        }

        protected bool IsEmailValid(string emailaddress)
        {
            //No Validation for RECO CMS for now.  
            if (Globals.generalsettings.ApplicationName == "RECO CMS")
                return true;

            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}