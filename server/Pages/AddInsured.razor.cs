using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
using RecoCms6.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace RecoCms6.Pages
{
    public partial class AddInsuredComponent
    {
        [Inject]
        public RecoDbContext DbContext { get; set; }

        int _newBrokerageID;
        protected int newBrokerageID
        {
            get
            {
                return _newBrokerageID;
            }
            set
            {
                if (!object.Equals(_newBrokerageID, value))
                {
                    var args = new PropertyChangedEventArgs() { Name = "newBrokerageID", NewValue = value, OldValue = _newBrokerageID };
                    _newBrokerageID = value;
                    OnPropertyChanged(args);
                    Reload();
                }
            }
        }

        public Insured Get(int insuredID)
        {
            return DbContext.Insureds
                .FirstOrDefault(x => x.InsuredID == insuredID);
        }
        public async Task<int> LinkLitigationRoles() 
        {
            if (insured.InsuredID == 0)
            {
                DbContext.Insureds.Add(insured);
            }
            
            DbContext.SaveChanges();

            var toDelete = DbContext.InsuredLitigationRoles.Where(x => x.InsuredID == this.insured.InsuredID);
            DbContext.InsuredLitigationRoles.RemoveRange(toDelete);

            //var toInsert = this.Roles.Select(roleId => new InsuredLitigationRole()
            //{
            //    InsuredID = this.insured.InsuredID,
            //    LitigationRoleID = roleId
            //});
            //DbContext.InsuredLitigationRoles.AddRange(toInsert);
            
            return await DbContext.SaveChangesAsync();
        }

        public async void SetBrokerageDetails(dynamic args)
        {
            if (args != null)
            {
                var recoDbGetBrokerageByBrokerageIdResult = await RecoDb.GetBrokerageByBrokerageId(args);


                insured.BrokerageName = recoDbGetBrokerageByBrokerageIdResult.Name;
                insured.BrokerageAddress = recoDbGetBrokerageByBrokerageIdResult.Address;
                insured.BrokerageProvinceID = recoDbGetBrokerageByBrokerageIdResult.ProvinceID;
                insured.BrokerageCity = recoDbGetBrokerageByBrokerageIdResult.City;
                insured.BrokeragePostalCode = recoDbGetBrokerageByBrokerageIdResult.PostalCode;
                insured.BrokerageEmailAddress = recoDbGetBrokerageByBrokerageIdResult.EmailAddress;
                insured.BrokerageBusinessPhoneNum = recoDbGetBrokerageByBrokerageIdResult.BusinessPhoneNum;
                insured.BrokerOfRecord = recoDbGetBrokerageByBrokerageIdResult.BrokerOfRecordName;

                brokerage = recoDbGetBrokerageByBrokerageIdResult;
            }
            
        }

        protected async System.Threading.Tasks.Task NewBrokerageClick()
        {
           var dialogResult = await DialogService.OpenAsync<AddBrokerage>("Add Brokerage", null, new DialogOptions() { Width = $"{1200}px" });
            if (dialogResult != null)
            {
                newBrokerageID = dialogResult.BrokerageID;
            }

            if (dialogResult != null)
            {
                try
                {
                    var recoDbGetBrokeragesResult = await RecoDb.GetBrokerages();
                    getBrokeragesResult = recoDbGetBrokeragesResult;

                    insured.BrokerageID = newBrokerageID;
                    insured.BrokerageName = dialogResult.Name;
                    insured.BrokerageAddress = dialogResult.Address;
                    insured.BrokerageProvinceID = dialogResult.ProvinceID;
                    insured.BrokerageCity = dialogResult.City;
                    insured.BrokeragePostalCode = dialogResult.PostalCode;
                    insured.BrokerageEmailAddress = dialogResult.EmailAddress;
                    insured.BrokerageBusinessPhoneNum = dialogResult.BusinessPhoneNum;
                    insured.BrokerageContactPerson = dialogResult.ContactPerson;
                    insured.BrokerageContactEmail = dialogResult.ContactPersonEmail;
                    insured.BrokerageContactPhoneNum = dialogResult.ContactPersonPhoneNum;
                    brokerage = dialogResult;
                }
                catch (Exception ex)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"System Error", Detail = ex.Message });
                }
                
            }
        }

        protected async System.Threading.Tasks.Task RegistrantIDChange()
        {
            try
            {


                var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantID == @0", FilterParameters = new object[] { insured.RegistrantID } });
                registrant = recoDbGetRegistrantsResult.FirstOrDefault();

                insured = new Insured();

                insured.ClaimID = ClaimID;

                insured.ID = Guid.NewGuid();

                if (registrant != null)
                {
                    insured.RegistrantID = registrant.RegistrantID;
                    insured.Name = registrant.Name;
                    insured.Address = registrant.Address;
                    insured.PostalCode = registrant.PostalCode;
                    insured.BusinessPhoneNum = registrant.BusinessPhoneNum;
                    insured.CellPhoneNum = registrant.CellPhoneNum;
                    insured.PreferredCommunicationMethodID = registrant.PreferredCommunicationMethodID;
                    insured.City = registrant.City;
                    insured.BrokerageID = registrant.BrokerageID;
                    insured.ProvinceID = registrant.ProvinceID;
                    insured.PrimaryInsured = false;
                    SetBrokerageDetails(registrant.BrokerageID);
                }

                bUpdateRegistrant = false;
            }
            catch (Exception ex)
            {
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"System Error", Detail=ex.Message });
            }
        }

        protected async Task SaveErrorAsync(System.Exception exception)
        {
            try
            {
                var errorLog = new ErrorLog();
                errorLog.ClaimID = insured.ClaimID;
                errorLog.ErrorMessage = JsonConvert.SerializeObject(exception);
                errorLog.UserID = Security.User.Id;
                await RecoDb.CreateErrorLog(errorLog);
            }
            catch { }
        }
        protected async System.Threading.Tasks.Task SaveInsured()
        {
            if (insured.RegistrantID > 0 && !(String.IsNullOrEmpty(registrant.RegistrantNo)))
            {
                var recoDbGetRegistrantsResult = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantNo == @0 && i.RegistrantID != @1", FilterParameters = new object[] { registrant.RegistrantNo, registrant.RegistrantID } });
                if (recoDbGetRegistrantsResult.Count() > 0)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Registrant Number Exists in Database" });
                    return;
                }
            }

            if ((insured.RegistrantID == null || insured.RegistrantID == 0) && Globals.generalsettings.ApplicationName != "REIX CMS" && !(String.IsNullOrEmpty(registrant.RegistrantNo)))
            {
                var recoDbGetRegistrantsResult0 = await RecoDb.GetRegistrants(new Query() { Filter = $@"i => i.RegistrantNo == @0", FilterParameters = new object[] { registrant.RegistrantNo } });
                if (recoDbGetRegistrantsResult0.Count() > 0)
                {
                    NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Registrant Number Exists in Database" });
                    return;
                }
            }

            var recoDbGetNextClaimDisplayOrdersResult = await RecoDb.GetNextClaimDisplayOrders(new Query() { Filter = $@"i => i.ClaimID == @0", FilterParameters = new object[] { ClaimID } });
            if (intInsuredID == 0)
            {
                insured.DisplayOrder = (short)recoDbGetNextClaimDisplayOrdersResult.First().NextInsuredDisplayOrder;
            }

            registrant.Address = insured.Address;

            registrant.BrokerageID = insured.BrokerageID;

            registrant.BusinessPhoneNum = insured.BusinessPhoneNum;

            registrant.CellPhoneNum = insured.CellPhoneNum;

            registrant.City = insured.City;

            registrant.EmailAddress = insured.EmailAddress;

            registrant.Name = insured.Name;

            registrant.PostalCode = insured.PostalCode;

            registrant.PreferredCommunicationMethodID = insured.PreferredCommunicationMethodID;

            registrant.ProvinceID = insured.ProvinceID;

            if ((insured.RegistrantID == null || insured.RegistrantID == 0) && Globals.generalsettings.ApplicationName != "REIX CMS" && !(registrant.RegistrantNo == null || registrant.RegistrantNo == String.Empty))
            {
                var recoDbCreateRegistrantResult = await RecoDb.CreateRegistrant(registrant);
                insured.RegistrantID = registrant.RegistrantID;
            }

            if (bUpdateBroker)
            {
                var recoDbGetBrokerageByBrokerageIdResult = await RecoDb.GetBrokerageByBrokerageId(insured.BrokerageID);
                brokerage = recoDbGetBrokerageByBrokerageIdResult;
                brokerage.Name = insured.BrokerageName;
                brokerage.Address = insured.BrokerageAddress;
                brokerage.ProvinceID = insured.BrokerageProvinceID;
                brokerage.City = insured.BrokerageCity;
                brokerage.PostalCode = insured.BrokeragePostalCode;
                brokerage.EmailAddress = insured.BrokerageEmailAddress;
                brokerage.BusinessPhoneNum = insured.BrokerageBusinessPhoneNum;
                brokerage.BrokerOfRecordName = insured.BrokerOfRecord;
                var recoDbUpdateBrokerageResult = await RecoDb.UpdateBrokerage(brokerage.BrokerageID, brokerage);
            }

            try
            {
                if (intInsuredID == 0)
                {
                      insured = await RecoDb.CreateInsured(insured);
                    intInsuredID = insured.InsuredID;
                }
            }
            catch (System.Exception recoDbCreateInsuredException)
            {
                await SaveErrorAsync(recoDbCreateInsuredException);
                //string json = JsonConvert.SerializeObject(recoDbCreateInsuredException);
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Unable To Create Insured ", Detail = recoDbCreateInsuredException.InnerException.Message });
            }

            try
            {
                if (intInsuredID > 0)
                {
                    insured = await RecoDb.UpsertInsured(insured.ID, insured);
                }
            }
            catch (System.Exception recoDbUpdateInsuredException)
            {
                await SaveErrorAsync(recoDbUpdateInsuredException);
                //string json = JsonConvert.SerializeObject(recoDbUpdateInsuredException);
                NotificationService.Notify(new NotificationMessage() { Severity = NotificationSeverity.Error, Summary = $"Unable To Save Insured ", Detail = recoDbUpdateInsuredException.InnerException.Message });
            }
			 DialogService.Close(insured);
        }
    }
}
