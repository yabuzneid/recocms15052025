using Radzen;
using System;
using System.Web;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Data;
using System.Text.Encodings.Web;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components;
using RecoCms6.Data;

namespace RecoCms6
{
    public partial class RecoDbService
    {
        RecoDbContext Context
        {
           get
           {
             return this.context;
           }
        }

        private readonly RecoDbContext context;
        private readonly NavigationManager navigationManager;

        public RecoDbService(RecoDbContext context, NavigationManager navigationManager)
        {
            this.context = context;
            this.navigationManager = navigationManager;
        }

        public void Reset() => Context.ChangeTracker.Entries().Where(e => e.Entity != null).ToList().ForEach(e => e.State = EntityState.Detached);


      public async Task ExportAccountingAuditsToExcel(int? ProgramID, string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/accountingaudits/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/accountingaudits/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportAccountingAuditsToCSV(int? ProgramID, string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/accountingaudits/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/accountingaudits/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.AccountingAudit>> GetAccountingAudits(int? ProgramID, string StartDate, string EndDate, Query query = null)
      {
          OnAccountingAuditsDefaultParams(ref ProgramID, ref StartDate, ref EndDate);

          var items = Context.AccountingAudits.FromSqlRaw("EXEC [dbo].[AccountingAudit] @ProgramID={0}, @StartDate={1}, @EndDate={2}", ProgramID, string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnAccountingAuditsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnAccountingAuditsDefaultParams(ref int? ProgramID, ref string StartDate, ref string EndDate);

      partial void OnAccountingAuditsInvoke(ref IQueryable<Models.RecoDb.AccountingAudit> items);

      public async Task ExportAccountingRecoveryAuditsToExcel(int? ProgramID, string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/accountingrecoveryaudits/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/accountingrecoveryaudits/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportAccountingRecoveryAuditsToCSV(int? ProgramID, string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/accountingrecoveryaudits/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/accountingrecoveryaudits/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.AccountingRecoveryAudit>> GetAccountingRecoveryAudits(int? ProgramID, string StartDate, string EndDate, Query query = null)
      {
          OnAccountingRecoveryAuditsDefaultParams(ref ProgramID, ref StartDate, ref EndDate);

          var items = Context.AccountingRecoveryAudits.FromSqlRaw("EXEC [dbo].[AccountingRecoveryAudit] @ProgramID={0}, @StartDate={1}, @EndDate={2}", ProgramID, string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnAccountingRecoveryAuditsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnAccountingRecoveryAuditsDefaultParams(ref int? ProgramID, ref string StartDate, ref string EndDate);

      partial void OnAccountingRecoveryAuditsInvoke(ref IQueryable<Models.RecoDb.AccountingRecoveryAudit> items);
        public async Task ExportActiveFileHandlerDiariesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/activefilehandlerdiaries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/activefilehandlerdiaries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportActiveFileHandlerDiariesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/activefilehandlerdiaries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/activefilehandlerdiaries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnActiveFileHandlerDiariesRead(ref IQueryable<Models.RecoDb.ActiveFileHandlerDiary> items);

        public async Task<IQueryable<Models.RecoDb.ActiveFileHandlerDiary>> GetActiveFileHandlerDiaries(Query query = null)
        {
            var items = Context.ActiveFileHandlerDiaries.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnActiveFileHandlerDiariesRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportActiveUserDiaryReportsToExcel(string ReminderDateFrom, string ReminderDateTo, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/activeuserdiaryreports/excel(ReminderDateFrom='{ReminderDateFrom}', ReminderDateTo='{ReminderDateTo}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/activeuserdiaryreports/excel(ReminderDateFrom='{ReminderDateFrom}', ReminderDateTo='{ReminderDateTo}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportActiveUserDiaryReportsToCSV(string ReminderDateFrom, string ReminderDateTo, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/activeuserdiaryreports/csv(ReminderDateFrom='{ReminderDateFrom}', ReminderDateTo='{ReminderDateTo}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/activeuserdiaryreports/csv(ReminderDateFrom='{ReminderDateFrom}', ReminderDateTo='{ReminderDateTo}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ActiveUserDiaryReportModel>> GetActiveUserDiaryReports(string ReminderDateFrom, string ReminderDateTo, string UserID, Query query = null)
      {
          OnActiveUserDiaryReportsDefaultParams(ref ReminderDateFrom, ref ReminderDateTo, ref UserID);

          var items = Context.ActiveUserDiaryReports.FromSqlRaw("EXEC [dbo].[ActiveUserDiaryReport] @ReminderDateFrom={0}, @ReminderDateTo={1}, @UserID={2}", string.IsNullOrEmpty(ReminderDateFrom) ? DBNull.Value : (object)DateTime.Parse(ReminderDateFrom, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(ReminderDateTo) ? DBNull.Value : (object)DateTime.Parse(ReminderDateTo, null, System.Globalization.DateTimeStyles.RoundtripKind), UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnActiveUserDiaryReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnActiveUserDiaryReportsDefaultParams(ref string ReminderDateFrom, ref string ReminderDateTo, ref string UserID);

      partial void OnActiveUserDiaryReportsInvoke(ref IQueryable<Models.RecoDb.ActiveUserDiaryReportModel> items);
        public async Task ExportActualDaysOpensToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/actualdaysopens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/actualdaysopens/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportActualDaysOpensToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/actualdaysopens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/actualdaysopens/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnActualDaysOpensRead(ref IQueryable<Models.RecoDb.ActualDaysOpen> items);

        public async Task<IQueryable<Models.RecoDb.ActualDaysOpen>> GetActualDaysOpens(Query query = null)
        {
            var items = Context.ActualDaysOpens.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnActualDaysOpensRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportActuaryBordereausToExcel(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/actuarybordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/actuarybordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportActuaryBordereausToCSV(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/actuarybordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/actuarybordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ActuaryBordereau>> GetActuaryBordereaus(string ReportDate, Query query = null)
      {
          OnActuaryBordereausDefaultParams(ref ReportDate);

          var items = Context.ActuaryBordereaus.FromSqlRaw("EXEC [dbo].[ActuaryBordereau] @ReportDate={0}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnActuaryBordereausInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnActuaryBordereausDefaultParams(ref string ReportDate);

      partial void OnActuaryBordereausInvoke(ref IQueryable<Models.RecoDb.ActuaryBordereau> items);
      public async Task<int> AddErrorLogs(string ErrorMessage, string UserID, int? ClaimID)
      {
          OnAddErrorLogsDefaultParams(ref ErrorMessage, ref UserID, ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ErrorMessage", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = ErrorMessage},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[AddErrorLog] @ErrorMessage, @UserID, @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnAddErrorLogsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnAddErrorLogsDefaultParams(ref string ErrorMessage, ref string UserID, ref int? ClaimID);
      partial void OnAddErrorLogsInvoke(ref int result);
        public async Task ExportAdministratorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/administrators/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/administrators/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAdministratorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/administrators/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/administrators/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAdministratorsRead(ref IQueryable<Models.RecoDb.Administrator> items);

        public async Task<IQueryable<Models.RecoDb.Administrator>> GetAdministrators(Query query = null)
        {
            var items = Context.Administrators.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAdministratorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAdministratorCreated(Models.RecoDb.Administrator item);
        partial void OnAfterAdministratorCreated(Models.RecoDb.Administrator item);

        public async Task<Models.RecoDb.Administrator> CreateAdministrator(Models.RecoDb.Administrator administrator)
        {
            OnAdministratorCreated(administrator);

            var existingItem = Context.Administrators
                              .Where(i => i.ID == administrator.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Administrators.Add(administrator);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(administrator).State = EntityState.Detached;
                administrator.Parameter = null;
                administrator.Parameter1 = null;
                throw;
            }

            OnAfterAdministratorCreated(administrator);

            return administrator;
        }
        public async Task ExportAppointmentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/appointments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/appointments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAppointmentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/appointments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/appointments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAppointmentsRead(ref IQueryable<Models.RecoDb.Appointment> items);

        public async Task<IQueryable<Models.RecoDb.Appointment>> GetAppointments(Query query = null)
        {
            var items = Context.Appointments.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAppointmentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAppointmentCreated(Models.RecoDb.Appointment item);
        partial void OnAfterAppointmentCreated(Models.RecoDb.Appointment item);

        public async Task<Models.RecoDb.Appointment> CreateAppointment(Models.RecoDb.Appointment appointment)
        {
            OnAppointmentCreated(appointment);

            var existingItem = Context.Appointments
                              .Where(i => i.ID == appointment.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Appointments.Add(appointment);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(appointment).State = EntityState.Detached;
                appointment.Claim = null;
                appointment.Parameter = null;
                appointment.Parameter1 = null;
                throw;
            }

            OnAfterAppointmentCreated(appointment);

            return appointment;
        }
        public async Task ExportAuditTrailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/audittrails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/audittrails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAuditTrailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/audittrails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/audittrails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAuditTrailsRead(ref IQueryable<Models.RecoDb.AuditTrail> items);

        public async Task<IQueryable<Models.RecoDb.AuditTrail>> GetAuditTrails(Query query = null)
        {
            var items = Context.AuditTrails.AsQueryable();

            items = items.Include(i => i.Claim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAuditTrailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAuditTrailCreated(Models.RecoDb.AuditTrail item);
        partial void OnAfterAuditTrailCreated(Models.RecoDb.AuditTrail item);

        public async Task<Models.RecoDb.AuditTrail> CreateAuditTrail(Models.RecoDb.AuditTrail auditTrail)
        {
            OnAuditTrailCreated(auditTrail);

            var existingItem = Context.AuditTrails
                              .Where(i => i.AuditTrailID == auditTrail.AuditTrailID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AuditTrails.Add(auditTrail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(auditTrail).State = EntityState.Detached;
                auditTrail.Claim = null;
                throw;
            }

            OnAfterAuditTrailCreated(auditTrail);

            return auditTrail;
        }
        public async Task ExportAuditTrailDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/audittraildetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/audittraildetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAuditTrailDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/audittraildetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/audittraildetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAuditTrailDetailsRead(ref IQueryable<Models.RecoDb.AuditTrailDetail> items);

        public async Task<IQueryable<Models.RecoDb.AuditTrailDetail>> GetAuditTrailDetails(Query query = null)
        {
            var items = Context.AuditTrailDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAuditTrailDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportAutoReservingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/autoreservings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/autoreservings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAutoReservingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/autoreservings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/autoreservings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAutoReservingsRead(ref IQueryable<Models.RecoDb.AutoReserving> items);

        public async Task<IQueryable<Models.RecoDb.AutoReserving>> GetAutoReservings(Query query = null)
        {
            var items = Context.AutoReservings.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAutoReservingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAutoReservingCreated(Models.RecoDb.AutoReserving item);
        partial void OnAfterAutoReservingCreated(Models.RecoDb.AutoReserving item);

        public async Task<Models.RecoDb.AutoReserving> CreateAutoReserving(Models.RecoDb.AutoReserving autoReserving)
        {
            OnAutoReservingCreated(autoReserving);

            var existingItem = Context.AutoReservings
                              .Where(i => i.ProgramID == autoReserving.ProgramID && i.ClaimInitiationID == autoReserving.ClaimInitiationID && i.ClaimOrIncident == autoReserving.ClaimOrIncident)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.AutoReservings.Add(autoReserving);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(autoReserving).State = EntityState.Detached;
                autoReserving.Parameter = null;
                autoReserving.Parameter1 = null;
                throw;
            }

            OnAfterAutoReservingCreated(autoReserving);

            return autoReserving;
        }
        public async Task ExportAvailableIncurredCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/availableincurredcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/availableincurredcategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAvailableIncurredCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/availableincurredcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/availableincurredcategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAvailableIncurredCategoriesRead(ref IQueryable<Models.RecoDb.AvailableIncurredCategory> items);

        public async Task<IQueryable<Models.RecoDb.AvailableIncurredCategory>> GetAvailableIncurredCategories(Query query = null)
        {
            var items = Context.AvailableIncurredCategories.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAvailableIncurredCategoriesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportAvailableIncurredTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/availableincurredtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/availableincurredtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportAvailableIncurredTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/availableincurredtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/availableincurredtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnAvailableIncurredTypesRead(ref IQueryable<Models.RecoDb.AvailableIncurredType> items);

        public async Task<IQueryable<Models.RecoDb.AvailableIncurredType>> GetAvailableIncurredTypes(Query query = null)
        {
            var items = Context.AvailableIncurredTypes.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnAvailableIncurredTypesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportBinaryRoleValuesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/binaryrolevalues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/binaryrolevalues/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBinaryRoleValuesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/binaryrolevalues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/binaryrolevalues/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBinaryRoleValuesRead(ref IQueryable<Models.RecoDb.BinaryRoleValue> items);

        public async Task<IQueryable<Models.RecoDb.BinaryRoleValue>> GetBinaryRoleValues(Query query = null)
        {
            var items = Context.BinaryRoleValues.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBinaryRoleValuesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBinaryRoleValueCreated(Models.RecoDb.BinaryRoleValue item);
        partial void OnAfterBinaryRoleValueCreated(Models.RecoDb.BinaryRoleValue item);

        public async Task<Models.RecoDb.BinaryRoleValue> CreateBinaryRoleValue(Models.RecoDb.BinaryRoleValue binaryRoleValue)
        {
            OnBinaryRoleValueCreated(binaryRoleValue);

            var existingItem = Context.BinaryRoleValues
                              .Where(i => i.RoleID == binaryRoleValue.RoleID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BinaryRoleValues.Add(binaryRoleValue);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(binaryRoleValue).State = EntityState.Detached;
                throw;
            }

            OnAfterBinaryRoleValueCreated(binaryRoleValue);

            return binaryRoleValue;
        }
        public async Task ExportBrokeragesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/brokerages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/brokerages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBrokeragesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/brokerages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/brokerages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBrokeragesRead(ref IQueryable<Models.RecoDb.Brokerage> items);

        public async Task<IQueryable<Models.RecoDb.Brokerage>> GetBrokerages(Query query = null)
        {
            var items = Context.Brokerages.AsQueryable();

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Administrator);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBrokeragesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBrokerageCreated(Models.RecoDb.Brokerage item);
        partial void OnAfterBrokerageCreated(Models.RecoDb.Brokerage item);

        public async Task<Models.RecoDb.Brokerage> CreateBrokerage(Models.RecoDb.Brokerage brokerage)
        {
            OnBrokerageCreated(brokerage);

            var existingItem = Context.Brokerages
                .AsNoTracking()
                .FirstOrDefault(i => i.BrokerageID == brokerage.BrokerageID);

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Brokerages.Add(brokerage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(brokerage).State = EntityState.Detached;
                brokerage.Registrant = null;
                brokerage.Parameter = null;
                brokerage.Administrator = null;
                throw;
            }

            OnAfterBrokerageCreated(brokerage);

            return brokerage;
        }
        public async Task ExportBrokerageContactsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/brokeragecontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/brokeragecontacts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBrokerageContactsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/brokeragecontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/brokeragecontacts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBrokerageContactsRead(ref IQueryable<Models.RecoDb.BrokerageContact> items);

        public async Task<IQueryable<Models.RecoDb.BrokerageContact>> GetBrokerageContacts(Query query = null)
        {
            var items = Context.BrokerageContacts.AsQueryable();

            items = items.Include(i => i.Brokerage);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBrokerageContactsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBrokerageContactCreated(Models.RecoDb.BrokerageContact item);
        partial void OnAfterBrokerageContactCreated(Models.RecoDb.BrokerageContact item);

        public async Task<Models.RecoDb.BrokerageContact> CreateBrokerageContact(Models.RecoDb.BrokerageContact brokerageContact)
        {
            OnBrokerageContactCreated(brokerageContact);

            var existingItem = Context.BrokerageContacts
                              .Where(i => i.BrokerageContactID == brokerageContact.BrokerageContactID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.BrokerageContacts.Add(brokerageContact);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(brokerageContact).State = EntityState.Detached;
                brokerageContact.Brokerage = null;
                brokerageContact.Parameter = null;
                throw;
            }

            OnAfterBrokerageContactCreated(brokerageContact);

            return brokerageContact;
        }
        public async Task ExportBuildersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/builders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/builders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBuildersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/builders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/builders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBuildersRead(ref IQueryable<Models.RecoDb.Builder> items);

        public async Task<IQueryable<Models.RecoDb.Builder>> GetBuilders(Query query = null)
        {
            var items = Context.Builders.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBuildersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnBuilderCreated(Models.RecoDb.Builder item);
        partial void OnAfterBuilderCreated(Models.RecoDb.Builder item);

        public async Task<Models.RecoDb.Builder> CreateBuilder(Models.RecoDb.Builder builder)
        {
            OnBuilderCreated(builder);

            var existingItem = Context.Builders
                              .Where(i => i.ID == builder.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Builders.Add(builder);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(builder).State = EntityState.Detached;
                builder.Parameter = null;
                builder.Parameter1 = null;
                throw;
            }

            OnAfterBuilderCreated(builder);

            return builder;
        }
        public async Task ExportBuilderDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/builderdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/builderdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportBuilderDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/builderdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/builderdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnBuilderDetailsRead(ref IQueryable<Models.RecoDb.BuilderDetail> items);

        public async Task<IQueryable<Models.RecoDb.BuilderDetail>> GetBuilderDetails(Query query = null)
        {
            var items = Context.BuilderDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnBuilderDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportCdiNoticeOfClaimDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/cdinoticeofclaimdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/cdinoticeofclaimdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCdiNoticeOfClaimDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/cdinoticeofclaimdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/cdinoticeofclaimdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCdiNoticeOfClaimDetailsRead(ref IQueryable<Models.RecoDb.CdiNoticeOfClaimDetail> items);

        public async Task<IQueryable<Models.RecoDb.CdiNoticeOfClaimDetail>> GetCdiNoticeOfClaimDetails(Query query = null)
        {
            var items = Context.CdiNoticeOfClaimDetails.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCdiNoticeOfClaimDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCdiNoticeOfClaimDetailCreated(Models.RecoDb.CdiNoticeOfClaimDetail item);
        partial void OnAfterCdiNoticeOfClaimDetailCreated(Models.RecoDb.CdiNoticeOfClaimDetail item);

        public async Task<Models.RecoDb.CdiNoticeOfClaimDetail> CreateCdiNoticeOfClaimDetail(Models.RecoDb.CdiNoticeOfClaimDetail cdiNoticeOfClaimDetail)
        {
            OnCdiNoticeOfClaimDetailCreated(cdiNoticeOfClaimDetail);

            var existingItem = Context.CdiNoticeOfClaimDetails
                              .Where(i => i.ID == cdiNoticeOfClaimDetail.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CdiNoticeOfClaimDetails.Add(cdiNoticeOfClaimDetail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cdiNoticeOfClaimDetail).State = EntityState.Detached;
                throw;
            }

            OnAfterCdiNoticeOfClaimDetailCreated(cdiNoticeOfClaimDetail);

            return cdiNoticeOfClaimDetail;
        }
        public async Task ExportCdpClaimDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/cdpclaimdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/cdpclaimdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCdpClaimDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/cdpclaimdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/cdpclaimdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCdpClaimDetailsRead(ref IQueryable<Models.RecoDb.CdpClaimDetail> items);

        public async Task<IQueryable<Models.RecoDb.CdpClaimDetail>> GetCdpClaimDetails(Query query = null)
        {
            var items = Context.CdpClaimDetails.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Claim1);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Claim2);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCdpClaimDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCdpClaimDetailCreated(Models.RecoDb.CdpClaimDetail item);
        partial void OnAfterCdpClaimDetailCreated(Models.RecoDb.CdpClaimDetail item);

        public async Task<Models.RecoDb.CdpClaimDetail> CreateCdpClaimDetail(Models.RecoDb.CdpClaimDetail cdpClaimDetail)
        {
            OnCdpClaimDetailCreated(cdpClaimDetail);

            var existingItem = Context.CdpClaimDetails
                              .Where(i => i.ClaimID == cdpClaimDetail.ClaimID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CdpClaimDetails.Add(cdpClaimDetail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cdpClaimDetail).State = EntityState.Detached;
                cdpClaimDetail.Claim = null;
                cdpClaimDetail.Parameter = null;
                cdpClaimDetail.Claim1 = null;
                cdpClaimDetail.Parameter1 = null;
                cdpClaimDetail.Claim2 = null;
                throw;
            }

            OnAfterCdpClaimDetailCreated(cdpClaimDetail);

            return cdpClaimDetail;
        }
      public async Task<int> CheckInvoicesForErrors(int? FirmID)
      {
          OnCheckInvoicesForErrorsDefaultParams(ref FirmID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@FirmID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = FirmID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[CheckInvoicesForErrors] @FirmID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnCheckInvoicesForErrorsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnCheckInvoicesForErrorsDefaultParams(ref int? FirmID);
      partial void OnCheckInvoicesForErrorsInvoke(ref int result);

      public async Task ExportCheckSystemNoticesToExcel(string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/checksystemnotices/excel(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/checksystemnotices/excel(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportCheckSystemNoticesToCSV(string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/checksystemnotices/csv(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/checksystemnotices/csv(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.CheckSystemNotice>> GetCheckSystemNotices(string UserID, Query query = null)
      {
          OnCheckSystemNoticesDefaultParams(ref UserID);

          var items = Context.CheckSystemNotices.FromSqlRaw("EXEC [dbo].[CheckSystemNotice] @UserID={0}", UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnCheckSystemNoticesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnCheckSystemNoticesDefaultParams(ref string UserID);

      partial void OnCheckSystemNoticesInvoke(ref IQueryable<Models.RecoDb.CheckSystemNotice> items);

      public async Task ExportCheckTransactionLimitsToExcel(string UserID, int? IncurredCategoryID, int? IncurredTypeID, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/checktransactionlimits/excel(UserID='{UserID}', IncurredCategoryID={IncurredCategoryID}, IncurredTypeID={IncurredTypeID}, ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/checktransactionlimits/excel(UserID='{UserID}', IncurredCategoryID={IncurredCategoryID}, IncurredTypeID={IncurredTypeID}, ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportCheckTransactionLimitsToCSV(string UserID, int? IncurredCategoryID, int? IncurredTypeID, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/checktransactionlimits/csv(UserID='{UserID}', IncurredCategoryID={IncurredCategoryID}, IncurredTypeID={IncurredTypeID}, ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/checktransactionlimits/csv(UserID='{UserID}', IncurredCategoryID={IncurredCategoryID}, IncurredTypeID={IncurredTypeID}, ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.CheckTransactionLimit>> GetCheckTransactionLimits(string UserID, int? IncurredCategoryID, int? IncurredTypeID, int? ProgramID, Query query = null)
      {
          OnCheckTransactionLimitsDefaultParams(ref UserID, ref IncurredCategoryID, ref IncurredTypeID, ref ProgramID);

          var items = Context.CheckTransactionLimits.FromSqlRaw("EXEC [dbo].[CheckTransactionLimit] @UserID={0}, @IncurredCategoryID={1}, @IncurredTypeID={2}, @ProgramID={3}", UserID, IncurredCategoryID, IncurredTypeID, ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnCheckTransactionLimitsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnCheckTransactionLimitsDefaultParams(ref string UserID, ref int? IncurredCategoryID, ref int? IncurredTypeID, ref int? ProgramID);

      partial void OnCheckTransactionLimitsInvoke(ref IQueryable<Models.RecoDb.CheckTransactionLimit> items);
        public async Task ExportClaimsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimsRead(ref IQueryable<Models.RecoDb.Claim> items);

        public async Task<IQueryable<Models.RecoDb.Claim>> GetClaims(Query query = null)
        {
            var items = Context.Claims.AsQueryable().AsNoTracking();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.ServiceProvider1);

            items = items.Include(i => i.ServiceProvider2);

            items = items.Include(i => i.ServiceProvider3);

            items = items.Include(i => i.Brokerage);

            items = items.Include(i => i.Parameter3);

            items = items.Include(i => i.Parameter4);

            items = items.Include(i => i.Parameter5);

            items = items.Include(i => i.Occurrence);

            items = items.Include(i => i.ServiceProvider4);

            items = items.Include(i => i.Parameter6);

            items = items.Include(i => i.Parameter7);

            items = items.Include(i => i.Parameter8);

            items = items.Include(i => i.ServiceProvider5);

            items = items.Include(i => i.Parameter9);

            items = items.Include(i => i.Claimant);

            items = items.Include(i => i.Claim1);

            items = items.Include(i => i.Parameter10);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimCreated(Models.RecoDb.Claim item);
        partial void OnAfterClaimCreated(Models.RecoDb.Claim item);

        public async Task<Models.RecoDb.Claim> CreateClaim(Models.RecoDb.Claim claim)
        {
            OnClaimCreated(claim);

            var existingItem = Context.Claims
                              .Where(i => i.ID == claim.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Claims.Add(claim);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claim).State = EntityState.Detached;
                claim.Parameter = null;
                claim.Parameter1 = null;
                claim.Parameter2 = null;
                claim.ServiceProvider = null;
                claim.ServiceProvider1 = null;
                claim.ServiceProvider2 = null;
                claim.ServiceProvider3 = null;
                claim.Brokerage = null;
                claim.Parameter3 = null;
                claim.Parameter4 = null;
                claim.Parameter5 = null;
                claim.Occurrence = null;
                claim.ServiceProvider4 = null;
                claim.Parameter6 = null;
                claim.Parameter7 = null;
                claim.Parameter8 = null;
                claim.ServiceProvider5 = null;
                claim.Parameter9 = null;
                claim.Claimant = null;
                claim.Claim1 = null;
                claim.Parameter10 = null;
                throw;
            }

            OnAfterClaimCreated(claim);

            return claim;
        }

      public async Task ExportClaimActivityLogsToExcel(int? ClaimID, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimactivitylogs/excel(ClaimID={ClaimID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimactivitylogs/excel(ClaimID={ClaimID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimActivityLogsToCSV(int? ClaimID, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimactivitylogs/csv(ClaimID={ClaimID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimactivitylogs/csv(ClaimID={ClaimID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimActivityLog>> GetClaimActivityLogs(int? ClaimID, string UserID, Query query = null)
      {
          OnClaimActivityLogsDefaultParams(ref ClaimID, ref UserID);

          var items = Context.ClaimActivityLogs.FromSqlRaw("EXEC [dbo].[ClaimActivityLog] @ClaimID={0}, @UserID={1}", ClaimID, UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimActivityLogsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimActivityLogsDefaultParams(ref int? ClaimID, ref string UserID);

      partial void OnClaimActivityLogsInvoke(ref IQueryable<Models.RecoDb.ClaimActivityLog> items);
        public async Task ExportClaimBasePrincipalsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimbaseprincipals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimbaseprincipals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimBasePrincipalsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimbaseprincipals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimbaseprincipals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimBasePrincipalsRead(ref IQueryable<Models.RecoDb.ClaimBasePrincipal> items);

        public async Task<IQueryable<Models.RecoDb.ClaimBasePrincipal>> GetClaimBasePrincipals(Query query = null)
        {
            var items = Context.ClaimBasePrincipals.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimBasePrincipalsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimClaimantsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimclaimants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimclaimants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimClaimantsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimclaimants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimclaimants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimClaimantsRead(ref IQueryable<Models.RecoDb.ClaimClaimant> items);

        public async Task<IQueryable<Models.RecoDb.ClaimClaimant>> GetClaimClaimants(Query query = null)
        {
            var items = Context.ClaimClaimants.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimClaimantsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimCurrentPaymentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimcurrentpayments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimcurrentpayments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimCurrentPaymentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimcurrentpayments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimcurrentpayments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimCurrentPaymentsRead(ref IQueryable<Models.RecoDb.ClaimCurrentPayment> items);

        public async Task<IQueryable<Models.RecoDb.ClaimCurrentPayment>> GetClaimCurrentPayments(Query query = null)
        {
            var items = Context.ClaimCurrentPayments.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimCurrentPaymentsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimCurrentReservesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimcurrentreserves/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimcurrentreserves/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimCurrentReservesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimcurrentreserves/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimcurrentreserves/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimCurrentReservesRead(ref IQueryable<Models.RecoDb.ClaimCurrentReserf> items);

        public async Task<IQueryable<Models.RecoDb.ClaimCurrentReserf>> GetClaimCurrentReserves(Query query = null)
        {
            var items = Context.ClaimCurrentReserves.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimCurrentReservesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimDetailsBordereausToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimdetailsbordereaus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimdetailsbordereaus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimDetailsBordereausToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimdetailsbordereaus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimdetailsbordereaus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimDetailsBordereausRead(ref IQueryable<Models.RecoDb.ClaimDetailsBordereau> items);

        public async Task<IQueryable<Models.RecoDb.ClaimDetailsBordereau>> GetClaimDetailsBordereaus(Query query = null)
        {
            var items = Context.ClaimDetailsBordereaus.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimDetailsBordereausRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportClaimDetailsReportsToExcel(string StartDate, string EndDate, int? ClaimStatusID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimdetailsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', ClaimStatusID={ClaimStatusID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimdetailsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', ClaimStatusID={ClaimStatusID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimDetailsReportsToCSV(string StartDate, string EndDate, int? ClaimStatusID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimdetailsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', ClaimStatusID={ClaimStatusID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimdetailsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', ClaimStatusID={ClaimStatusID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimDetailsReport>> GetClaimDetailsReports(string StartDate, string EndDate, int? ClaimStatusID, Query query = null)
      {
          OnClaimDetailsReportsDefaultParams(ref StartDate, ref EndDate, ref ClaimStatusID);

          var items = Context.ClaimDetailsReports.FromSqlRaw("EXEC [dbo].[ClaimDetailsReport] @StartDate={0}, @EndDate={1}, @ClaimStatusID={2}", string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ClaimStatusID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimDetailsReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimDetailsReportsDefaultParams(ref string StartDate, ref string EndDate, ref int? ClaimStatusID);

      partial void OnClaimDetailsReportsInvoke(ref IQueryable<Models.RecoDb.ClaimDetailsReport> items);
        public async Task ExportClaimDiaryDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimdiarydetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimdiarydetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimDiaryDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimdiarydetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimdiarydetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimDiaryDetailsRead(ref IQueryable<Models.RecoDb.ClaimDiaryDetail> items);

        public async Task<IQueryable<Models.RecoDb.ClaimDiaryDetail>> GetClaimDiaryDetails(Query query = null)
        {
            var items = Context.ClaimDiaryDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimDiaryDetailsRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportClaimEmailAddressesToExcel(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimemailaddresses/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimemailaddresses/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimEmailAddressesToCSV(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimemailaddresses/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimemailaddresses/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimEmailAddress>> GetClaimEmailAddresses(int? ClaimID, Query query = null)
      {
          OnClaimEmailAddressesDefaultParams(ref ClaimID);

          var items = Context.ClaimEmailAddresses.FromSqlRaw("EXEC [dbo].[ClaimEmailAddresses] @ClaimID={0}", ClaimID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimEmailAddressesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimEmailAddressesDefaultParams(ref int? ClaimID);

      partial void OnClaimEmailAddressesInvoke(ref IQueryable<Models.RecoDb.ClaimEmailAddress> items);
        public async Task ExportClaimExpertsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimexperts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimexperts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimExpertsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimexperts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimexperts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimExpertsRead(ref IQueryable<Models.RecoDb.ClaimExpert> items);

        public async Task<IQueryable<Models.RecoDb.ClaimExpert>> GetClaimExperts(Query query = null)
        {
            var items = Context.ClaimExperts.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimExpertsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimFileHandlerAndReportsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimfilehandlerandreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimfilehandlerandreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimFileHandlerAndReportsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimfilehandlerandreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimfilehandlerandreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimFileHandlerAndReportsRead(ref IQueryable<Models.RecoDb.ClaimFileHandlerAndReport> items);

        public async Task<IQueryable<Models.RecoDb.ClaimFileHandlerAndReport>> GetClaimFileHandlerAndReports(Query query = null)
        {
            var items = Context.ClaimFileHandlerAndReports.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimFileHandlerAndReportsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimFileReportingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimfilereportings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimfilereportings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimFileReportingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimfilereportings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimfilereportings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimFileReportingsRead(ref IQueryable<Models.RecoDb.ClaimFileReporting> items);

        public async Task<IQueryable<Models.RecoDb.ClaimFileReporting>> GetClaimFileReportings(Query query = null)
        {
            var items = Context.ClaimFileReportings.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.ServiceProvider);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimFileReportingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimFileReportingCreated(Models.RecoDb.ClaimFileReporting item);
        partial void OnAfterClaimFileReportingCreated(Models.RecoDb.ClaimFileReporting item);

        public async Task<Models.RecoDb.ClaimFileReporting> CreateClaimFileReporting(Models.RecoDb.ClaimFileReporting claimFileReporting)
        {
            OnClaimFileReportingCreated(claimFileReporting);

            var existingItem = Context.ClaimFileReportings
                              .Where(i => i.FileReportID == claimFileReporting.FileReportID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClaimFileReportings.Add(claimFileReporting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claimFileReporting).State = EntityState.Detached;
                claimFileReporting.Claim = null;
                claimFileReporting.ServiceProvider = null;
                throw;
            }

            OnAfterClaimFileReportingCreated(claimFileReporting);

            return claimFileReporting;
        }

      public async Task ExportClaimFileSummariesToExcel(int? ClaimID, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimfilesummaries/excel(ClaimID={ClaimID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimfilesummaries/excel(ClaimID={ClaimID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimFileSummariesToCSV(int? ClaimID, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimfilesummaries/csv(ClaimID={ClaimID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimfilesummaries/csv(ClaimID={ClaimID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimFileSummary>> GetClaimFileSummaries(int? ClaimID, string UserID, Query query = null)
      {
          OnClaimFileSummariesDefaultParams(ref ClaimID, ref UserID);

          var items = Context.ClaimFileSummaries.FromSqlRaw("EXEC [dbo].[ClaimFileSummary] @ClaimID={0}, @UserID={1}", ClaimID, UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimFileSummariesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimFileSummariesDefaultParams(ref int? ClaimID, ref string UserID);

      partial void OnClaimFileSummariesInvoke(ref IQueryable<Models.RecoDb.ClaimFileSummary> items);

      public async Task ExportClaimFilesByUsersToExcel(string UserID, int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimfilesbyusers/excel(UserID='{UserID}', ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimfilesbyusers/excel(UserID='{UserID}', ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimFilesByUsersToCSV(string UserID, int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimfilesbyusers/csv(UserID='{UserID}', ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimfilesbyusers/csv(UserID='{UserID}', ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimFilesByUser>> GetClaimFilesByUsers(string UserID, int? ClaimID, Query query = null)
      {
          OnClaimFilesByUsersDefaultParams(ref UserID, ref ClaimID);

          var items = Context.ClaimFilesByUsers.FromSqlRaw("EXEC [dbo].[ClaimFilesByUser] @UserID={0}, @ClaimID={1}", UserID, ClaimID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimFilesByUsersInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimFilesByUsersDefaultParams(ref string UserID, ref int? ClaimID);

      partial void OnClaimFilesByUsersInvoke(ref IQueryable<Models.RecoDb.ClaimFilesByUser> items);
        public async Task ExportClaimIndividualTransactionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimindividualtransactions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimindividualtransactions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimIndividualTransactionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimindividualtransactions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimindividualtransactions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimIndividualTransactionsRead(ref IQueryable<Models.RecoDb.ClaimIndividualTransaction> items);

        public async Task<IQueryable<Models.RecoDb.ClaimIndividualTransaction>> GetClaimIndividualTransactions(Query query = null)
        {
            var items = Context.ClaimIndividualTransactions.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimIndividualTransactionsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimInsuredsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claiminsureds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claiminsureds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimInsuredsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claiminsureds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claiminsureds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimInsuredsRead(ref IQueryable<Models.RecoDb.ClaimInsured> items);

        public async Task<IQueryable<Models.RecoDb.ClaimInsured>> GetClaimInsureds(Query query = null)
        {
            var items = Context.ClaimInsureds.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimInsuredsRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportClaimLagTimeReportsToExcel(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimlagtimereports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimlagtimereports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimLagTimeReportsToCSV(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimlagtimereports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimlagtimereports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimLagTimeReport>> GetClaimLagTimeReports(string StartDate, string EndDate, Query query = null)
      {
          OnClaimLagTimeReportsDefaultParams(ref StartDate, ref EndDate);

          var items = Context.ClaimLagTimeReports.FromSqlRaw("EXEC [dbo].[ClaimLagTimeReport] @StartDate={0}, @EndDate={1}", string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimLagTimeReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimLagTimeReportsDefaultParams(ref string StartDate, ref string EndDate);

      partial void OnClaimLagTimeReportsInvoke(ref IQueryable<Models.RecoDb.ClaimLagTimeReport> items);
        public async Task ExportClaimListsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimListsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimListsRead(ref IQueryable<Models.RecoDb.ClaimList> items);

        public async Task<IQueryable<Models.RecoDb.ClaimList>> GetClaimLists(Query query = null)
        {
            var items = Context.ClaimLists.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimListsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimLitigationDatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimlitigationdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimlitigationdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimLitigationDatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimlitigationdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimlitigationdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimLitigationDatesRead(ref IQueryable<Models.RecoDb.ClaimLitigationDate> items);

        public async Task<IQueryable<Models.RecoDb.ClaimLitigationDate>> GetClaimLitigationDates(Query query = null)
        {
            var items = Context.ClaimLitigationDates.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimLitigationDatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimLitigationDateCreated(Models.RecoDb.ClaimLitigationDate item);
        partial void OnAfterClaimLitigationDateCreated(Models.RecoDb.ClaimLitigationDate item);

        public async Task<Models.RecoDb.ClaimLitigationDate> CreateClaimLitigationDate(Models.RecoDb.ClaimLitigationDate claimLitigationDate)
        {
            OnClaimLitigationDateCreated(claimLitigationDate);

            var existingItem = Context.ClaimLitigationDates
                              .Where(i => i.LitigationDateID == claimLitigationDate.LitigationDateID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                claimLitigationDate.Claim = null;
                claimLitigationDate.Parameter = null;
                claimLitigationDate.Parameter1 = null;
                Context.ClaimLitigationDates.Add(claimLitigationDate);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claimLitigationDate).State = EntityState.Detached;
                claimLitigationDate.Claim = null;
                claimLitigationDate.Parameter = null;
                claimLitigationDate.Parameter1 = null;
                throw;
            }

            OnAfterClaimLitigationDateCreated(claimLitigationDate);

            return claimLitigationDate;
        }
        public async Task ExportClaimOtherPartiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimotherparties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimotherparties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimOtherPartiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimotherparties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimotherparties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimOtherPartiesRead(ref IQueryable<Models.RecoDb.ClaimOtherParty> items);

        public async Task<IQueryable<Models.RecoDb.ClaimOtherParty>> GetClaimOtherParties(Query query = null)
        {
            var items = Context.ClaimOtherParties.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimOtherPartiesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimPreferencesDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimpreferencesdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimpreferencesdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimPreferencesDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimpreferencesdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimpreferencesdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimPreferencesDetailsRead(ref IQueryable<Models.RecoDb.ClaimPreferencesDetail> items);

        public async Task<IQueryable<Models.RecoDb.ClaimPreferencesDetail>> GetClaimPreferencesDetails(Query query = null)
        {
            var items = Context.ClaimPreferencesDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimPreferencesDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimPrincipalsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimprincipals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimprincipals/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimPrincipalsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimprincipals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimprincipals/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimPrincipalsRead(ref IQueryable<Models.RecoDb.ClaimPrincipal> items);

        public async Task<IQueryable<Models.RecoDb.ClaimPrincipal>> GetClaimPrincipals(Query query = null)
        {
            var items = Context.ClaimPrincipals.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimPrincipalsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimRapidSearchListsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimrapidsearchlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimrapidsearchlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimRapidSearchListsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimrapidsearchlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimrapidsearchlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimRapidSearchListsRead(ref IQueryable<Models.RecoDb.ClaimRapidSearchList> items);

        public async Task<IQueryable<Models.RecoDb.ClaimRapidSearchList>> GetClaimRapidSearchLists(Query query = null)
        {
            var items = Context.ClaimRapidSearchLists.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimRapidSearchListsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimReportsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimReportsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimReportsRead(ref IQueryable<Models.RecoDb.ClaimReport> items);

        public async Task<IQueryable<Models.RecoDb.ClaimReport>> GetClaimReports(Query query = null)
        {
            var items = Context.ClaimReports.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Firm);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimReportsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimReportCreated(Models.RecoDb.ClaimReport item);
        partial void OnAfterClaimReportCreated(Models.RecoDb.ClaimReport item);

        public async Task<Models.RecoDb.ClaimReport> CreateClaimReport(Models.RecoDb.ClaimReport claimReport)
        {
            OnClaimReportCreated(claimReport);

            var existingItem = Context.ClaimReports
                              .Where(i => i.ClaimReportID == claimReport.ClaimReportID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClaimReports.Add(claimReport);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claimReport).State = EntityState.Detached;
                claimReport.Claim = null;
                claimReport.Parameter = null;
                claimReport.Firm = null;
                throw;
            }

            OnAfterClaimReportCreated(claimReport);

            return claimReport;
        }
        public async Task ExportClaimReportDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimreportdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimreportdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimReportDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimreportdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimreportdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimReportDetailsRead(ref IQueryable<Models.RecoDb.ClaimReportDetail> items);

        public async Task<IQueryable<Models.RecoDb.ClaimReportDetail>> GetClaimReportDetails(Query query = null)
        {
            var items = Context.ClaimReportDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimReportDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimSearchListsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimsearchlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimsearchlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimSearchListsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimsearchlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimsearchlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimSearchListsRead(ref IQueryable<Models.RecoDb.ClaimSearchList> items);

        public async Task<IQueryable<Models.RecoDb.ClaimSearchList>> GetClaimSearchLists(Query query = null)
        {
            var items = Context.ClaimSearchLists.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimSearchListsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimStatusHistoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimstatushistories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimstatushistories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimStatusHistoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimstatushistories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimstatushistories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimStatusHistoriesRead(ref IQueryable<Models.RecoDb.ClaimStatusHistory> items);

        public async Task<IQueryable<Models.RecoDb.ClaimStatusHistory>> GetClaimStatusHistories(Query query = null)
        {
            var items = Context.ClaimStatusHistories.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimStatusHistoriesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimStatusHistoryCreated(Models.RecoDb.ClaimStatusHistory item);
        partial void OnAfterClaimStatusHistoryCreated(Models.RecoDb.ClaimStatusHistory item);

        public async Task<Models.RecoDb.ClaimStatusHistory> CreateClaimStatusHistory(Models.RecoDb.ClaimStatusHistory claimStatusHistory)
        {
            OnClaimStatusHistoryCreated(claimStatusHistory);

            var existingItem = Context.ClaimStatusHistories
                              .Where(i => i.ClaimStatusID == claimStatusHistory.ClaimStatusID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClaimStatusHistories.Add(claimStatusHistory);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claimStatusHistory).State = EntityState.Detached;
                claimStatusHistory.Claim = null;
                claimStatusHistory.Parameter = null;
                throw;
            }

            OnAfterClaimStatusHistoryCreated(claimStatusHistory);

            return claimStatusHistory;
        }

      public async Task ExportClaimSummariesToExcel(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimsummaries/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimsummaries/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimSummariesToCSV(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimsummaries/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimsummaries/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimSummary>> GetClaimSummaries(int? ClaimID, Query query = null)
      {
          OnClaimSummariesDefaultParams(ref ClaimID);

          var items = Context.ClaimSummaries.FromSqlRaw("EXEC [dbo].[ClaimSummary] @ClaimID={0}", ClaimID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimSummariesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimSummariesDefaultParams(ref int? ClaimID);

      partial void OnClaimSummariesInvoke(ref IQueryable<Models.RecoDb.ClaimSummary> items);
        public async Task ExportClaimTotalIncurredByCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimtotalincurredbycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimtotalincurredbycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimTotalIncurredByCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimtotalincurredbycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimtotalincurredbycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimTotalIncurredByCategoriesRead(ref IQueryable<Models.RecoDb.ClaimTotalIncurredByCategory> items);

        public async Task<IQueryable<Models.RecoDb.ClaimTotalIncurredByCategory>> GetClaimTotalIncurredByCategories(Query query = null)
        {
            var items = Context.ClaimTotalIncurredByCategories.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimTotalIncurredByCategoriesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportClaimTotalIncurredByTransactionDatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimtotalincurredbytransactiondates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimtotalincurredbytransactiondates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimTotalIncurredByTransactionDatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimtotalincurredbytransactiondates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimtotalincurredbytransactiondates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimTotalIncurredByTransactionDatesRead(ref IQueryable<Models.RecoDb.ClaimTotalIncurredByTransactionDate> items);

        public async Task<IQueryable<Models.RecoDb.ClaimTotalIncurredByTransactionDate>> GetClaimTotalIncurredByTransactionDates(Query query = null)
        {
            var items = Context.ClaimTotalIncurredByTransactionDates.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimTotalIncurredByTransactionDatesRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportClaimTransactionSummaryByDatesToExcel(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimtransactionsummarybydates/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimtransactionsummarybydates/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimTransactionSummaryByDatesToCSV(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimtransactionsummarybydates/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimtransactionsummarybydates/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimTransactionSummaryByDate>> GetClaimTransactionSummaryByDates(string ReportDate, Query query = null)
      {
          OnClaimTransactionSummaryByDatesDefaultParams(ref ReportDate);

          var items = Context.ClaimTransactionSummaryByDates.FromSqlRaw("EXEC [dbo].[ClaimTransactionSummaryByDate] @ReportDate={0}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimTransactionSummaryByDatesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimTransactionSummaryByDatesDefaultParams(ref string ReportDate);

      partial void OnClaimTransactionSummaryByDatesInvoke(ref IQueryable<Models.RecoDb.ClaimTransactionSummaryByDate> items);
        public async Task ExportClaimantsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimantsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimantsRead(ref IQueryable<Models.RecoDb.Claimant> items);

        public async Task<IQueryable<Models.RecoDb.Claimant>> GetClaimants(Query query = null)
        {
            var items = Context.Claimants.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.ClaimantSolicitor);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.Brokerage);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimantsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimantCreated(Models.RecoDb.Claimant item);
        partial void OnAfterClaimantCreated(Models.RecoDb.Claimant item);

        public async Task<Models.RecoDb.Claimant> CreateClaimant(Models.RecoDb.Claimant claimant)
        {
            OnClaimantCreated(claimant);

            var existingItem = Context.Claimants
                              .Where(i => i.ID == claimant.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Claimants.Add(claimant);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claimant).State = EntityState.Detached;
                claimant.Claim = null;
                claimant.Registrant = null;
                claimant.Parameter = null;
                claimant.Parameter1 = null;
                claimant.ClaimantSolicitor = null;
                claimant.Parameter2 = null;
                claimant.Brokerage = null;
                throw;
            }

            OnAfterClaimantCreated(claimant);

            return claimant;
        }
        public async Task ExportClaimantLitigationRolesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimantlitigationroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimantlitigationroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimantLitigationRolesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimantlitigationroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimantlitigationroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimantLitigationRolesRead(ref IQueryable<Models.RecoDb.ClaimantLitigationRole> items);

        public async Task<IQueryable<Models.RecoDb.ClaimantLitigationRole>> GetClaimantLitigationRoles(Query query = null)
        {
            var items = Context.ClaimantLitigationRoles.AsQueryable();

            items = items.Include(i => i.Claimant);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimantLitigationRolesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimantLitigationRoleCreated(Models.RecoDb.ClaimantLitigationRole item);
        partial void OnAfterClaimantLitigationRoleCreated(Models.RecoDb.ClaimantLitigationRole item);

        public async Task<Models.RecoDb.ClaimantLitigationRole> CreateClaimantLitigationRole(Models.RecoDb.ClaimantLitigationRole claimantLitigationRole)
        {
            OnClaimantLitigationRoleCreated(claimantLitigationRole);

            var existingItem = Context.ClaimantLitigationRoles
                              .Where(i => i.ClaimantID == claimantLitigationRole.ClaimantID && i.LitigationRole == claimantLitigationRole.LitigationRole)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClaimantLitigationRoles.Add(claimantLitigationRole);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claimantLitigationRole).State = EntityState.Detached;
                claimantLitigationRole.Claimant = null;
                claimantLitigationRole.Parameter = null;
                throw;
            }

            OnAfterClaimantLitigationRoleCreated(claimantLitigationRole);

            return claimantLitigationRole;
        }
        public async Task ExportClaimantPaymentsReceivedsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimantpaymentsreceiveds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimantpaymentsreceiveds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimantPaymentsReceivedsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimantpaymentsreceiveds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimantpaymentsreceiveds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimantPaymentsReceivedsRead(ref IQueryable<Models.RecoDb.ClaimantPaymentsReceived> items);

        public async Task<IQueryable<Models.RecoDb.ClaimantPaymentsReceived>> GetClaimantPaymentsReceiveds(Query query = null)
        {
            var items = Context.ClaimantPaymentsReceiveds.AsQueryable();

            items = items.Include(i => i.Claimant);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimantPaymentsReceivedsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimantPaymentsReceivedCreated(Models.RecoDb.ClaimantPaymentsReceived item);
        partial void OnAfterClaimantPaymentsReceivedCreated(Models.RecoDb.ClaimantPaymentsReceived item);

        public async Task<Models.RecoDb.ClaimantPaymentsReceived> CreateClaimantPaymentsReceived(Models.RecoDb.ClaimantPaymentsReceived claimantPaymentsReceived)
        {
            OnClaimantPaymentsReceivedCreated(claimantPaymentsReceived);

            var existingItem = Context.ClaimantPaymentsReceiveds
                              .Where(i => i.ClaimantID == claimantPaymentsReceived.ClaimantID && i.PaymentReceivedDate == claimantPaymentsReceived.PaymentReceivedDate)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClaimantPaymentsReceiveds.Add(claimantPaymentsReceived);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claimantPaymentsReceived).State = EntityState.Detached;
                claimantPaymentsReceived.Claimant = null;
                throw;
            }

            OnAfterClaimantPaymentsReceivedCreated(claimantPaymentsReceived);

            return claimantPaymentsReceived;
        }
        public async Task ExportClaimantSolicitorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimantsolicitors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimantsolicitors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimantSolicitorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimantsolicitors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimantsolicitors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimantSolicitorsRead(ref IQueryable<Models.RecoDb.ClaimantSolicitor> items);

        public async Task<IQueryable<Models.RecoDb.ClaimantSolicitor>> GetClaimantSolicitors(Query query = null)
        {
            var items = Context.ClaimantSolicitors.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimantSolicitorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnClaimantSolicitorCreated(Models.RecoDb.ClaimantSolicitor item);
        partial void OnAfterClaimantSolicitorCreated(Models.RecoDb.ClaimantSolicitor item);

        public async Task<Models.RecoDb.ClaimantSolicitor> CreateClaimantSolicitor(Models.RecoDb.ClaimantSolicitor claimantSolicitor)
        {
            OnClaimantSolicitorCreated(claimantSolicitor);

            var existingItem = Context.ClaimantSolicitors
                              .Where(i => i.ID == claimantSolicitor.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ClaimantSolicitors.Add(claimantSolicitor);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(claimantSolicitor).State = EntityState.Detached;
                claimantSolicitor.Parameter = null;
                claimantSolicitor.Parameter1 = null;
                throw;
            }

            OnAfterClaimantSolicitorCreated(claimantSolicitor);

            return claimantSolicitor;
        }
        public async Task ExportClaimantTotalIncurredByCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimanttotalincurredbycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimanttotalincurredbycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimantTotalIncurredByCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimanttotalincurredbycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimanttotalincurredbycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimantTotalIncurredByCategoriesRead(ref IQueryable<Models.RecoDb.ClaimantTotalIncurredByCategory> items);

        public async Task<IQueryable<Models.RecoDb.ClaimantTotalIncurredByCategory>> GetClaimantTotalIncurredByCategories(Query query = null)
        {
            var items = Context.ClaimantTotalIncurredByCategories.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimantTotalIncurredByCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportClaimsClosedQuarterlyReportsToExcel(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimsclosedquarterlyreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimsclosedquarterlyreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimsClosedQuarterlyReportsToCSV(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimsclosedquarterlyreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimsclosedquarterlyreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimsClosedQuarterlyReport>> GetClaimsClosedQuarterlyReports(string StartDate, string EndDate, Query query = null)
      {
          OnClaimsClosedQuarterlyReportsDefaultParams(ref StartDate, ref EndDate);

          var items = Context.ClaimsClosedQuarterlyReports.FromSqlRaw("EXEC [dbo].[ClaimsClosedQuarterlyReport] @StartDate={0}, @EndDate={1}", string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimsClosedQuarterlyReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimsClosedQuarterlyReportsDefaultParams(ref string StartDate, ref string EndDate);

      partial void OnClaimsClosedQuarterlyReportsInvoke(ref IQueryable<Models.RecoDb.ClaimsClosedQuarterlyReport> items);
        public async Task ExportClaimsWithIndemnitiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnities/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportClaimsWithIndemnitiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnities/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnClaimsWithIndemnitiesRead(ref IQueryable<Models.RecoDb.ClaimsWithIndemnity> items);

        public async Task<IQueryable<Models.RecoDb.ClaimsWithIndemnity>> GetClaimsWithIndemnities(Query query = null)
        {
            var items = Context.ClaimsWithIndemnities.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnClaimsWithIndemnitiesRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportClaimsWithIndemnityPaidsToExcel(int? ProgramID, string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnitypaids/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnitypaids/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimsWithIndemnityPaidsToCSV(int? ProgramID, string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnitypaids/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnitypaids/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimsWithIndemnityPaid>> GetClaimsWithIndemnityPaids(int? ProgramID, string ReportDate, Query query = null)
      {
          OnClaimsWithIndemnityPaidsDefaultParams(ref ProgramID, ref ReportDate);

          var items = Context.ClaimsWithIndemnityPaids.FromSqlRaw("EXEC [dbo].[ClaimsWithIndemnityPaid] @ProgramID={0}, @ReportDate={1}", ProgramID, string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimsWithIndemnityPaidsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimsWithIndemnityPaidsDefaultParams(ref int? ProgramID, ref string ReportDate);

      partial void OnClaimsWithIndemnityPaidsInvoke(ref IQueryable<Models.RecoDb.ClaimsWithIndemnityPaid> items);

      public async Task ExportClaimsWithIndemnityPaidDetailedsToExcel(int? ProgramID, string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnitypaiddetaileds/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnitypaiddetaileds/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimsWithIndemnityPaidDetailedsToCSV(int? ProgramID, string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnitypaiddetaileds/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnitypaiddetaileds/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimsWithIndemnityPaidDetailed>> GetClaimsWithIndemnityPaidDetaileds(int? ProgramID, string ReportDate, Query query = null)
      {
          OnClaimsWithIndemnityPaidDetailedsDefaultParams(ref ProgramID, ref ReportDate);

          var items = Context.ClaimsWithIndemnityPaidDetaileds.FromSqlRaw("EXEC [dbo].[ClaimsWithIndemnityPaidDetailed] @ProgramID={0}, @ReportDate={1}", ProgramID, string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimsWithIndemnityPaidDetailedsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimsWithIndemnityPaidDetailedsDefaultParams(ref int? ProgramID, ref string ReportDate);

      partial void OnClaimsWithIndemnityPaidDetailedsInvoke(ref IQueryable<Models.RecoDb.ClaimsWithIndemnityPaidDetailed> items);

      public async Task ExportClaimsWithIndemnityReservesToExcel(int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnityreserves/excel(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnityreserves/excel(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimsWithIndemnityReservesToCSV(int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnityreserves/csv(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnityreserves/csv(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimsWithIndemnityReserf>> GetClaimsWithIndemnityReserves(int? ProgramID, Query query = null)
      {
          OnClaimsWithIndemnityReservesDefaultParams(ref ProgramID);

          var items = Context.ClaimsWithIndemnityReserves.FromSqlRaw("EXEC [dbo].[ClaimsWithIndemnityReserves] @ProgramID={0}", ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimsWithIndemnityReservesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimsWithIndemnityReservesDefaultParams(ref int? ProgramID);

      partial void OnClaimsWithIndemnityReservesInvoke(ref IQueryable<Models.RecoDb.ClaimsWithIndemnityReserf> items);

      public async Task ExportClaimsWithIndemnityReserveWithDetailsToExcel(int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnityreservewithdetails/excel(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnityreservewithdetails/excel(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimsWithIndemnityReserveWithDetailsToCSV(int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithindemnityreservewithdetails/csv(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithindemnityreservewithdetails/csv(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimsWithIndemnityReserveWithDetail>> GetClaimsWithIndemnityReserveWithDetails(int? ProgramID, Query query = null)
      {
          OnClaimsWithIndemnityReserveWithDetailsDefaultParams(ref ProgramID);

          var items = Context.ClaimsWithIndemnityReserveWithDetails.FromSqlRaw("EXEC [dbo].[ClaimsWithIndemnityReserveWithDetails] @ProgramID={0}", ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimsWithIndemnityReserveWithDetailsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimsWithIndemnityReserveWithDetailsDefaultParams(ref int? ProgramID);

      partial void OnClaimsWithIndemnityReserveWithDetailsInvoke(ref IQueryable<Models.RecoDb.ClaimsWithIndemnityReserveWithDetail> items);

      public async Task ExportClaimsWithReserveDetailsReportsToExcel(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithreservedetailsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithreservedetailsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportClaimsWithReserveDetailsReportsToCSV(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/claimswithreservedetailsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/claimswithreservedetailsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ClaimsWithReserveDetailsReport>> GetClaimsWithReserveDetailsReports(string StartDate, string EndDate, Query query = null)
      {
          OnClaimsWithReserveDetailsReportsDefaultParams(ref StartDate, ref EndDate);

          var items = Context.ClaimsWithReserveDetailsReports.FromSqlRaw("EXEC [dbo].[ClaimsWithReserveDetailsReport] @StartDate={0}, @EndDate={1}", string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnClaimsWithReserveDetailsReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnClaimsWithReserveDetailsReportsDefaultParams(ref string StartDate, ref string EndDate);

      partial void OnClaimsWithReserveDetailsReportsInvoke(ref IQueryable<Models.RecoDb.ClaimsWithReserveDetailsReport> items);
      public async Task<int> ClearClaimantLitigationRoles(int? ClaimantID)
      {
          OnClearClaimantLitigationRolesDefaultParams(ref ClaimantID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimantID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimantID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ClearClaimantLitigationRoles] @ClaimantID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnClearClaimantLitigationRolesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnClearClaimantLitigationRolesDefaultParams(ref int? ClaimantID);
      partial void OnClearClaimantLitigationRolesInvoke(ref int result);

      public async Task<int> ClearInvoiceUploadData()
      {
          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
          };

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ClearInvoiceUploadData]", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnClearInvoiceUploadDataInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnClearInvoiceUploadDataInvoke(ref int result);

      public async Task<int> ClearSystemNotices()
      {
          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
          };

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ClearSystemNotice]", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnClearSystemNoticesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnClearSystemNoticesInvoke(ref int result);

      public async Task ExportCloneClaimPrincipalsToExcel(int? ClaimID, string ClonedClaimNo, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/cloneclaimprincipals/excel(ClaimID={ClaimID}, ClonedClaimNo='{ClonedClaimNo}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/cloneclaimprincipals/excel(ClaimID={ClaimID}, ClonedClaimNo='{ClonedClaimNo}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportCloneClaimPrincipalsToCSV(int? ClaimID, string ClonedClaimNo, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/cloneclaimprincipals/csv(ClaimID={ClaimID}, ClonedClaimNo='{ClonedClaimNo}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/cloneclaimprincipals/csv(ClaimID={ClaimID}, ClonedClaimNo='{ClonedClaimNo}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.CloneClaimPrincipal>> GetCloneClaimPrincipals(int? ClaimID, string ClonedClaimNo, string UserID, Query query = null)
      {
          OnCloneClaimPrincipalsDefaultParams(ref ClaimID, ref ClonedClaimNo, ref UserID);

          var items = Context.CloneClaimPrincipals.FromSqlRaw("EXEC [dbo].[CloneClaimPrincipals] @ClaimID={0}, @ClonedClaimNo={1}, @UserID={2}", ClaimID, ClonedClaimNo, UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnCloneClaimPrincipalsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnCloneClaimPrincipalsDefaultParams(ref int? ClaimID, ref string ClonedClaimNo, ref string UserID);

      partial void OnCloneClaimPrincipalsInvoke(ref IQueryable<Models.RecoDb.CloneClaimPrincipal> items);
      public async Task<int> CloseEntireClaims(int? ClaimID, string UserID)
      {
          OnCloseEntireClaimsDefaultParams(ref ClaimID, ref UserID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[CloseEntireClaim] @ClaimID, @UserID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnCloseEntireClaimsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnCloseEntireClaimsDefaultParams(ref int? ClaimID, ref string UserID);
      partial void OnCloseEntireClaimsInvoke(ref int result);
      public async Task<int> CloseIndividualClaimReserves(int? ClaimID, int? IncurredTypeID, string UserID)
      {
          OnCloseIndividualClaimReservesDefaultParams(ref ClaimID, ref IncurredTypeID, ref UserID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
              new SqlParameter("@IncurredTypeID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = IncurredTypeID},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[CloseIndividualClaimReserves] @ClaimID, @IncurredTypeID, @UserID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnCloseIndividualClaimReservesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnCloseIndividualClaimReservesDefaultParams(ref int? ClaimID, ref int? IncurredTypeID, ref string UserID);
      partial void OnCloseIndividualClaimReservesInvoke(ref int result);
        public async Task ExportCommissionInstallmentsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/commissioninstallments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/commissioninstallments/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCommissionInstallmentsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/commissioninstallments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/commissioninstallments/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCommissionInstallmentsRead(ref IQueryable<Models.RecoDb.CommissionInstallment> items);

        public async Task<IQueryable<Models.RecoDb.CommissionInstallment>> GetCommissionInstallments(Query query = null)
        {
            var items = Context.CommissionInstallments.AsQueryable();

            items = items.Include(i => i.Trade);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCommissionInstallmentsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCommissionInstallmentCreated(Models.RecoDb.CommissionInstallment item);
        partial void OnAfterCommissionInstallmentCreated(Models.RecoDb.CommissionInstallment item);

        public async Task<Models.RecoDb.CommissionInstallment> CreateCommissionInstallment(Models.RecoDb.CommissionInstallment commissionInstallment)
        {
            OnCommissionInstallmentCreated(commissionInstallment);

            var existingItem = Context.CommissionInstallments
                              .Where(i => i.CommissionInstallmentID == commissionInstallment.CommissionInstallmentID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CommissionInstallments.Add(commissionInstallment);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(commissionInstallment).State = EntityState.Detached;
                commissionInstallment.Trade = null;
                throw;
            }

            OnAfterCommissionInstallmentCreated(commissionInstallment);

            return commissionInstallment;
        }
      public async Task<int> ConsolidateClaimants(int? ConsolidatedClaimantID, int? DiscontinuedClaimantID)
      {
          OnConsolidateClaimantsDefaultParams(ref ConsolidatedClaimantID, ref DiscontinuedClaimantID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ConsolidatedClaimantID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ConsolidatedClaimantID},
              new SqlParameter("@DiscontinuedClaimantID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = DiscontinuedClaimantID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ConsolidateClaimants] @ConsolidatedClaimantID, @DiscontinuedClaimantID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnConsolidateClaimantsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnConsolidateClaimantsDefaultParams(ref int? ConsolidatedClaimantID, ref int? DiscontinuedClaimantID);
      partial void OnConsolidateClaimantsInvoke(ref int result);
        public async Task ExportCostAwardsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/costawards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/costawards/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCostAwardsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/costawards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/costawards/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCostAwardsRead(ref IQueryable<Models.RecoDb.CostAward> items);

        public async Task<IQueryable<Models.RecoDb.CostAward>> GetCostAwards(Query query = null)
        {
            var items = Context.CostAwards.AsQueryable();

            items = items.Include(i => i.Claim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCostAwardsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCostAwardCreated(Models.RecoDb.CostAward item);
        partial void OnAfterCostAwardCreated(Models.RecoDb.CostAward item);

        public async Task<Models.RecoDb.CostAward> CreateCostAward(Models.RecoDb.CostAward costAward)
        {
            OnCostAwardCreated(costAward);

            var existingItem = Context.CostAwards
                              .Where(i => i.CostAwardID == costAward.CostAwardID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CostAwards.Add(costAward);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(costAward).State = EntityState.Detached;
                costAward.Claim = null;
                throw;
            }

            OnAfterCostAwardCreated(costAward);

            return costAward;
        }

      public async Task ExportCostOfClaimsByTypeReportsToExcel(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/costofclaimsbytypereports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/costofclaimsbytypereports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportCostOfClaimsByTypeReportsToCSV(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/costofclaimsbytypereports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/costofclaimsbytypereports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.CostOfClaimsByTypeReport>> GetCostOfClaimsByTypeReports(Query query = null)
      {
          var items = Context.CostOfClaimsByTypeReports.FromSqlRaw("EXEC [dbo].[CostOfClaimsByTypeReport]").ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnCostOfClaimsByTypeReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnCostOfClaimsByTypeReportsInvoke(ref IQueryable<Models.RecoDb.CostOfClaimsByTypeReport> items);
        public async Task ExportCourtDatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/courtdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/courtdates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCourtDatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/courtdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/courtdates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCourtDatesRead(ref IQueryable<Models.RecoDb.CourtDate> items);

        public async Task<IQueryable<Models.RecoDb.CourtDate>> GetCourtDates(Query query = null)
        {
            var items = Context.CourtDates.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.ServiceProvider);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCourtDatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCourtDateCreated(Models.RecoDb.CourtDate item);
        partial void OnAfterCourtDateCreated(Models.RecoDb.CourtDate item);

        public async Task<Models.RecoDb.CourtDate> CreateCourtDate(Models.RecoDb.CourtDate courtDate)
        {
            OnCourtDateCreated(courtDate);

            var existingItem = Context.CourtDates
                              .Where(i => i.CourtDateID == courtDate.CourtDateID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CourtDates.Add(courtDate);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(courtDate).State = EntityState.Detached;
                courtDate.Claim = null;
                courtDate.Parameter = null;
                courtDate.ServiceProvider = null;
                throw;
            }

            OnAfterCourtDateCreated(courtDate);

            return courtDate;
        }
        public async Task ExportCppNoticeOfClaimsDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/cppnoticeofclaimsdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/cppnoticeofclaimsdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCppNoticeOfClaimsDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/cppnoticeofclaimsdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/cppnoticeofclaimsdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCppNoticeOfClaimsDetailsRead(ref IQueryable<Models.RecoDb.CppNoticeOfClaimsDetail> items);

        public async Task<IQueryable<Models.RecoDb.CppNoticeOfClaimsDetail>> GetCppNoticeOfClaimsDetails(Query query = null)
        {
            var items = Context.CppNoticeOfClaimsDetails.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCppNoticeOfClaimsDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCppNoticeOfClaimsDetailCreated(Models.RecoDb.CppNoticeOfClaimsDetail item);
        partial void OnAfterCppNoticeOfClaimsDetailCreated(Models.RecoDb.CppNoticeOfClaimsDetail item);

        public async Task<Models.RecoDb.CppNoticeOfClaimsDetail> CreateCppNoticeOfClaimsDetail(Models.RecoDb.CppNoticeOfClaimsDetail cppNoticeOfClaimsDetail)
        {
            OnCppNoticeOfClaimsDetailCreated(cppNoticeOfClaimsDetail);

            var existingItem = Context.CppNoticeOfClaimsDetails
                              .Where(i => i.NoticeOfClaimDetailsID == cppNoticeOfClaimsDetail.NoticeOfClaimDetailsID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CppNoticeOfClaimsDetails.Add(cppNoticeOfClaimsDetail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(cppNoticeOfClaimsDetail).State = EntityState.Detached;
                throw;
            }

            OnAfterCppNoticeOfClaimsDetailCreated(cppNoticeOfClaimsDetail);

            return cppNoticeOfClaimsDetail;
        }
        public async Task ExportCrossReferencedClaimsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/crossreferencedclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/crossreferencedclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportCrossReferencedClaimsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/crossreferencedclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/crossreferencedclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnCrossReferencedClaimsRead(ref IQueryable<Models.RecoDb.CrossReferencedClaim> items);

        public async Task<IQueryable<Models.RecoDb.CrossReferencedClaim>> GetCrossReferencedClaims(Query query = null)
        {
            var items = Context.CrossReferencedClaims.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Claim1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnCrossReferencedClaimsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnCrossReferencedClaimCreated(Models.RecoDb.CrossReferencedClaim item);
        partial void OnAfterCrossReferencedClaimCreated(Models.RecoDb.CrossReferencedClaim item);

        public async Task<Models.RecoDb.CrossReferencedClaim> CreateCrossReferencedClaim(Models.RecoDb.CrossReferencedClaim crossReferencedClaim)
        {
            OnCrossReferencedClaimCreated(crossReferencedClaim);

            var existingItem = Context.CrossReferencedClaims
                              .Where(i => i.ClaimID == crossReferencedClaim.ClaimID && i.XRefClaimID == crossReferencedClaim.XRefClaimID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.CrossReferencedClaims.Add(crossReferencedClaim);
                Context.SaveChanges();
                Context.Entry(crossReferencedClaim).State = EntityState.Detached;
            }
            catch
            {
                Context.Entry(crossReferencedClaim).State = EntityState.Detached;
                crossReferencedClaim.Claim = null;
                crossReferencedClaim.Claim1 = null;
                throw;
            }

            OnAfterCrossReferencedClaimCreated(crossReferencedClaim);

            return crossReferencedClaim;
        }

      public async Task ExportCurrentDiaryReportsToExcel(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/currentdiaryreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/currentdiaryreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportCurrentDiaryReportsToCSV(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/currentdiaryreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/currentdiaryreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.CurrentDiaryReport>> GetCurrentDiaryReports(Query query = null)
      {
          var items = Context.CurrentDiaryReports.FromSqlRaw("EXEC [dbo].[CurrentDiaryReport]").ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnCurrentDiaryReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnCurrentDiaryReportsInvoke(ref IQueryable<Models.RecoDb.CurrentDiaryReport> items);

      public async Task ExportDefenseCounselWithOpenFilesToExcel(int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/defensecounselwithopenfiles/excel(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/defensecounselwithopenfiles/excel(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportDefenseCounselWithOpenFilesToCSV(int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/defensecounselwithopenfiles/csv(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/defensecounselwithopenfiles/csv(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.DefenseCounselWithOpenFile>> GetDefenseCounselWithOpenFiles(int? ProgramID, Query query = null)
      {
          OnDefenseCounselWithOpenFilesDefaultParams(ref ProgramID);

          var items = Context.DefenseCounselWithOpenFiles.FromSqlRaw("EXEC [dbo].[DefenseCounselWithOpenFiles] @ProgramID={0}", ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnDefenseCounselWithOpenFilesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnDefenseCounselWithOpenFilesDefaultParams(ref int? ProgramID);

      partial void OnDefenseCounselWithOpenFilesInvoke(ref IQueryable<Models.RecoDb.DefenseCounselWithOpenFile> items);
        public async Task ExportDiariesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/diaries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/diaries/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDiariesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/diaries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/diaries/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDiariesRead(ref IQueryable<Models.RecoDb.Diary> items);

        public async Task<IQueryable<Models.RecoDb.Diary>> GetDiaries(Query query = null)
        {
            var items = Context.Diaries.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnDiariesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDiaryCreated(Models.RecoDb.Diary item);
        partial void OnAfterDiaryCreated(Models.RecoDb.Diary item);

        public async Task<Models.RecoDb.Diary> CreateDiary(Models.RecoDb.Diary diary)
        {
            OnDiaryCreated(diary);

            var existingItem = Context.Diaries
                              .Where(i => i.ID == diary.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Diaries.Add(diary);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(diary).State = EntityState.Detached;
                diary.Claim = null;
                diary.Parameter = null;
                throw;
            }

            OnAfterDiaryCreated(diary);

            return diary;
        }
        public async Task ExportDiaryTemplatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/diarytemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/diarytemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportDiaryTemplatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/diarytemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/diarytemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnDiaryTemplatesRead(ref IQueryable<Models.RecoDb.DiaryTemplate> items);

        public async Task<IQueryable<Models.RecoDb.DiaryTemplate>> GetDiaryTemplates(Query query = null)
        {
            var items = Context.DiaryTemplates.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnDiaryTemplatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnDiaryTemplateCreated(Models.RecoDb.DiaryTemplate item);
        partial void OnAfterDiaryTemplateCreated(Models.RecoDb.DiaryTemplate item);

        public async Task<Models.RecoDb.DiaryTemplate> CreateDiaryTemplate(Models.RecoDb.DiaryTemplate diaryTemplate)
        {
            OnDiaryTemplateCreated(diaryTemplate);

            var existingItem = Context.DiaryTemplates
                              .Where(i => i.DiaryTemplateID == diaryTemplate.DiaryTemplateID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.DiaryTemplates.Add(diaryTemplate);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(diaryTemplate).State = EntityState.Detached;
                diaryTemplate.Parameter = null;
                diaryTemplate.Parameter1 = null;
                throw;
            }

            OnAfterDiaryTemplateCreated(diaryTemplate);

            return diaryTemplate;
        }
        public async Task ExportEmailFoldersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/emailfolders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/emailfolders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmailFoldersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/emailfolders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/emailfolders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmailFoldersRead(ref IQueryable<Models.RecoDb.EmailFolder> items);

        public async Task<IQueryable<Models.RecoDb.EmailFolder>> GetEmailFolders(Query query = null)
        {
            var items = Context.EmailFolders.AsQueryable();

            items = items.Include(i => i.EmailFolder1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEmailFoldersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmailFolderCreated(Models.RecoDb.EmailFolder item);
        partial void OnAfterEmailFolderCreated(Models.RecoDb.EmailFolder item);

        public async Task<Models.RecoDb.EmailFolder> CreateEmailFolder(Models.RecoDb.EmailFolder emailFolder)
        {
            OnEmailFolderCreated(emailFolder);

            var existingItem = Context.EmailFolders
                              .Where(i => i.ID == emailFolder.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EmailFolders.Add(emailFolder);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(emailFolder).State = EntityState.Detached;
                emailFolder.EmailFolder1 = null;
                throw;
            }

            OnAfterEmailFolderCreated(emailFolder);

            return emailFolder;
        }
        public async Task ExportEmailLinkFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/emaillinkfiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/emaillinkfiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmailLinkFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/emaillinkfiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/emaillinkfiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmailLinkFilesRead(ref IQueryable<Models.RecoDb.EmailLinkFile> items);

        public async Task<IQueryable<Models.RecoDb.EmailLinkFile>> GetEmailLinkFiles(Query query = null)
        {
            var items = Context.EmailLinkFiles.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEmailLinkFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmailLinkFileCreated(Models.RecoDb.EmailLinkFile item);
        partial void OnAfterEmailLinkFileCreated(Models.RecoDb.EmailLinkFile item);

        public async Task<Models.RecoDb.EmailLinkFile> CreateEmailLinkFile(Models.RecoDb.EmailLinkFile emailLinkFile)
        {
            OnEmailLinkFileCreated(emailLinkFile);

            var existingItem = Context.EmailLinkFiles
                              .Where(i => i.ID == emailLinkFile.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EmailLinkFiles.Add(emailLinkFile);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(emailLinkFile).State = EntityState.Detached;
                throw;
            }

            OnAfterEmailLinkFileCreated(emailLinkFile);

            return emailLinkFile;
        }
        public async Task ExportEmailMessagesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/emailmessages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/emailmessages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEmailMessagesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/emailmessages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/emailmessages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEmailMessagesRead(ref IQueryable<Models.RecoDb.EmailMessage> items);

        public async Task<IQueryable<Models.RecoDb.EmailMessage>> GetEmailMessages(Query query = null)
        {
            var items = Context.EmailMessages.AsQueryable();

            items = items.Include(i => i.EmailFolder);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEmailMessagesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEmailMessageCreated(Models.RecoDb.EmailMessage item);
        partial void OnAfterEmailMessageCreated(Models.RecoDb.EmailMessage item);

        public async Task<Models.RecoDb.EmailMessage> CreateEmailMessage(Models.RecoDb.EmailMessage emailMessage)
        {
            OnEmailMessageCreated(emailMessage);

            var existingItem = Context.EmailMessages
                              .Where(i => i.ID == emailMessage.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EmailMessages.Add(emailMessage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(emailMessage).State = EntityState.Detached;
                emailMessage.EmailFolder = null;
                throw;
            }

            OnAfterEmailMessageCreated(emailMessage);

            return emailMessage;
        }

      public async Task ExportEmptyReserveBordereausToExcel(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/emptyreservebordereaus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/emptyreservebordereaus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportEmptyReserveBordereausToCSV(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/emptyreservebordereaus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/emptyreservebordereaus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.EmptyReserveBordereau>> GetEmptyReserveBordereaus(Query query = null)
      {
          var items = Context.EmptyReserveBordereaus.FromSqlRaw("EXEC [dbo].[EmptyReserveBordereau]").ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnEmptyReserveBordereausInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnEmptyReserveBordereausInvoke(ref IQueryable<Models.RecoDb.EmptyReserveBordereau> items);
        public async Task ExportEoClaimDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/eoclaimdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/eoclaimdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEoClaimDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/eoclaimdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/eoclaimdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEoClaimDetailsRead(ref IQueryable<Models.RecoDb.EoClaimDetail> items);

        public async Task<IQueryable<Models.RecoDb.EoClaimDetail>> GetEoClaimDetails(Query query = null)
        {
            var items = Context.EoClaimDetails.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.ServiceProvider1);

            items = items.Include(i => i.ServiceProvider2);

            items = items.Include(i => i.ServiceProvider3);

            items = items.Include(i => i.ServiceProvider4);

            items = items.Include(i => i.Parameter3);

            items = items.Include(i => i.Parameter4);

            items = items.Include(i => i.Parameter5);

            items = items.Include(i => i.Parameter6);

            items = items.Include(i => i.Parameter7);

            items = items.Include(i => i.Parameter8);

            items = items.Include(i => i.Parameter9);

            items = items.Include(i => i.Parameter10);

            items = items.Include(i => i.Parameter11);

            items = items.Include(i => i.Parameter12);

            items = items.Include(i => i.Parameter13);

            items = items.Include(i => i.Parameter14);

            items = items.Include(i => i.Parameter15);

            items = items.Include(i => i.Parameter16);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEoClaimDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEoClaimDetailCreated(Models.RecoDb.EoClaimDetail item);
        partial void OnAfterEoClaimDetailCreated(Models.RecoDb.EoClaimDetail item);

        public async Task<Models.RecoDb.EoClaimDetail> CreateEoClaimDetail(Models.RecoDb.EoClaimDetail eoClaimDetail)
        {
            OnEoClaimDetailCreated(eoClaimDetail);

            var existingItem = Context.EoClaimDetails
                              .Where(i => i.ClaimID == eoClaimDetail.ClaimID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EoClaimDetails.Add(eoClaimDetail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(eoClaimDetail).State = EntityState.Detached;
                eoClaimDetail.Claim = null;
                eoClaimDetail.Parameter = null;
                eoClaimDetail.Parameter1 = null;
                eoClaimDetail.Parameter2 = null;
                eoClaimDetail.ServiceProvider = null;
                eoClaimDetail.ServiceProvider1 = null;
                eoClaimDetail.ServiceProvider2 = null;
                eoClaimDetail.ServiceProvider3 = null;
                eoClaimDetail.ServiceProvider4 = null;
                eoClaimDetail.Parameter3 = null;
                eoClaimDetail.Parameter4 = null;
                eoClaimDetail.Parameter5 = null;
                eoClaimDetail.Parameter6 = null;
                eoClaimDetail.Parameter7 = null;
                eoClaimDetail.Parameter8 = null;
                eoClaimDetail.Parameter9 = null;
                eoClaimDetail.Parameter10 = null;
                eoClaimDetail.Parameter11 = null;
                eoClaimDetail.Parameter12 = null;
                eoClaimDetail.Parameter13 = null;
                eoClaimDetail.Parameter14 = null;
                eoClaimDetail.Parameter15 = null;
                eoClaimDetail.Parameter16 = null;
                throw;
            }

            OnAfterEoClaimDetailCreated(eoClaimDetail);

            return eoClaimDetail;
        }
        public async Task ExportEoNoticeOfClaimsDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/eonoticeofclaimsdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/eonoticeofclaimsdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportEoNoticeOfClaimsDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/eonoticeofclaimsdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/eonoticeofclaimsdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnEoNoticeOfClaimsDetailsRead(ref IQueryable<Models.RecoDb.EoNoticeOfClaimsDetail> items);

        public async Task<IQueryable<Models.RecoDb.EoNoticeOfClaimsDetail>> GetEoNoticeOfClaimsDetails(Query query = null)
        {
            var items = Context.EoNoticeOfClaimsDetails.AsQueryable();

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnEoNoticeOfClaimsDetailsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnEoNoticeOfClaimsDetailCreated(Models.RecoDb.EoNoticeOfClaimsDetail item);
        partial void OnAfterEoNoticeOfClaimsDetailCreated(Models.RecoDb.EoNoticeOfClaimsDetail item);

        public async Task<Models.RecoDb.EoNoticeOfClaimsDetail> CreateEoNoticeOfClaimsDetail(Models.RecoDb.EoNoticeOfClaimsDetail eoNoticeOfClaimsDetail)
        {
            OnEoNoticeOfClaimsDetailCreated(eoNoticeOfClaimsDetail);

            var existingItem = Context.EoNoticeOfClaimsDetails
                              .Where(i => i.NoticeOfClaimID == eoNoticeOfClaimsDetail.NoticeOfClaimID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.EoNoticeOfClaimsDetails.Add(eoNoticeOfClaimsDetail);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(eoNoticeOfClaimsDetail).State = EntityState.Detached;
                eoNoticeOfClaimsDetail.NoticeOfClaim = null;
                eoNoticeOfClaimsDetail.Parameter = null;
                throw;
            }

            OnAfterEoNoticeOfClaimsDetailCreated(eoNoticeOfClaimsDetail);

            return eoNoticeOfClaimsDetail;
        }
        public async Task ExportErrorDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/errordetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/errordetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportErrorDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/errordetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/errordetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnErrorDetailsRead(ref IQueryable<Models.RecoDb.ErrorDetail> items);

        public async Task<IQueryable<Models.RecoDb.ErrorDetail>> GetErrorDetails(Query query = null)
        {
            var items = Context.ErrorDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnErrorDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportErrorLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/errorlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/errorlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportErrorLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/errorlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/errorlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnErrorLogsRead(ref IQueryable<Models.RecoDb.ErrorLog> items);

        public async Task<IQueryable<Models.RecoDb.ErrorLog>> GetErrorLogs(Query query = null)
        {
            var items = Context.ErrorLogs.AsQueryable();

            items = items.Include(i => i.Claim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnErrorLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnErrorLogCreated(Models.RecoDb.ErrorLog item);
        partial void OnAfterErrorLogCreated(Models.RecoDb.ErrorLog item);

        public async Task<Models.RecoDb.ErrorLog> CreateErrorLog(Models.RecoDb.ErrorLog errorLog)
        {
            OnErrorLogCreated(errorLog);

            var existingItem = Context.ErrorLogs
                              .Where(i => i.ErrorLogID == errorLog.ErrorLogID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ErrorLogs.Add(errorLog);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(errorLog).State = EntityState.Detached;
                errorLog.Claim = null;
                throw;
            }

            OnAfterErrorLogCreated(errorLog);

            return errorLog;
        }
        public async Task ExportExpertsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/experts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/experts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportExpertsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/experts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/experts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnExpertsRead(ref IQueryable<Models.RecoDb.Expert> items);

        public async Task<IQueryable<Models.RecoDb.Expert>> GetExperts(Query query = null)
        {
            var items = Context.Experts.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.Firm);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnExpertsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnExpertCreated(Models.RecoDb.Expert item);
        partial void OnAfterExpertCreated(Models.RecoDb.Expert item);

        public async Task<Models.RecoDb.Expert> CreateExpert(Models.RecoDb.Expert expert)
        {
            OnExpertCreated(expert);

            var existingItem = Context.Experts
                              .Where(i => i.ExpertID == expert.ExpertID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Experts.Add(expert);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(expert).State = EntityState.Detached;
                expert.Claim = null;
                expert.Parameter = null;
                expert.ServiceProvider = null;
                expert.Parameter1 = null;
                expert.Parameter2 = null;
                expert.Firm = null;
                throw;
            }

            OnAfterExpertCreated(expert);

            return expert;
        }
        public async Task ExportFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/files/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/files/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/files/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/files/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFilesRead(ref IQueryable<Models.RecoDb.File> items);

        public async Task<IQueryable<Models.RecoDb.File>> GetFiles(Query query = null)
        {
            var items = Context.Files.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFileCreated(Models.RecoDb.File item);
        partial void OnAfterFileCreated(Models.RecoDb.File item);

        public async Task<Models.RecoDb.File> CreateFile(Models.RecoDb.File file)
        {
            OnFileCreated(file);

            var existingItem = Context.Files
                              .Where(i => i.ID == file.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Files.Add(file);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(file).State = EntityState.Detached;
                throw;
            }

            OnAfterFileCreated(file);

            return file;
        }
        public async Task ExportFileDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/filedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/filedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFileDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/filedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/filedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFileDetailsRead(ref IQueryable<Models.RecoDb.FileDetail> items);

        public async Task<IQueryable<Models.RecoDb.FileDetail>> GetFileDetails(Query query = null)
        {
            var items = Context.FileDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFileDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportFileRoleDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fileroledetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/fileroledetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFileRoleDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fileroledetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/fileroledetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFileRoleDetailsRead(ref IQueryable<Models.RecoDb.FileRoleDetail> items);

        public async Task<IQueryable<Models.RecoDb.FileRoleDetail>> GetFileRoleDetails(Query query = null)
        {
            var items = Context.FileRoleDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFileRoleDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportFilesRolesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/filesroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/filesroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFilesRolesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/filesroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/filesroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFilesRolesRead(ref IQueryable<Models.RecoDb.FilesRole> items);

        public async Task<IQueryable<Models.RecoDb.FilesRole>> GetFilesRoles(Query query = null)
        {
            var items = Context.FilesRoles.AsQueryable();

            items = items.Include(i => i.Role);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFilesRolesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFilesRoleCreated(Models.RecoDb.FilesRole item);
        partial void OnAfterFilesRoleCreated(Models.RecoDb.FilesRole item);

        public async Task<Models.RecoDb.FilesRole> CreateFilesRole(Models.RecoDb.FilesRole filesRole)
        {
            OnFilesRoleCreated(filesRole);

            var existingItem = Context.FilesRoles
                              .Where(i => i.Id == filesRole.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.FilesRoles.Add(filesRole);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(filesRole).State = EntityState.Detached;
                filesRole.Role = null;
                throw;
            }

            OnAfterFilesRoleCreated(filesRole);

            return filesRole;
        }

      public async Task ExportFindOpenFilesForRegistrantsToExcel(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/findopenfilesforregistrants/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/findopenfilesforregistrants/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportFindOpenFilesForRegistrantsToCSV(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/findopenfilesforregistrants/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/findopenfilesforregistrants/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.FindOpenFilesForRegistrant>> GetFindOpenFilesForRegistrants(int? ClaimID, Query query = null)
      {
          OnFindOpenFilesForRegistrantsDefaultParams(ref ClaimID);

          var items = Context.FindOpenFilesForRegistrants.FromSqlRaw("EXEC [dbo].[FindOpenFilesForRegistrant] @ClaimID={0}", ClaimID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnFindOpenFilesForRegistrantsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnFindOpenFilesForRegistrantsDefaultParams(ref int? ClaimID);

      partial void OnFindOpenFilesForRegistrantsInvoke(ref IQueryable<Models.RecoDb.FindOpenFilesForRegistrant> items);

      public async Task ExportFindServiceProviderByIdentityUsersToExcel(string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/findserviceproviderbyidentityusers/excel(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/findserviceproviderbyidentityusers/excel(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportFindServiceProviderByIdentityUsersToCSV(string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/findserviceproviderbyidentityusers/csv(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/findserviceproviderbyidentityusers/csv(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.FindServiceProviderByIdentityUser>> GetFindServiceProviderByIdentityUsers(string UserID, Query query = null)
      {
          OnFindServiceProviderByIdentityUsersDefaultParams(ref UserID);

          var items = Context.FindServiceProviderByIdentityUsers.FromSqlRaw("EXEC [dbo].[FindServiceProviderByIdentityUser] @UserID={0}", UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnFindServiceProviderByIdentityUsersInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnFindServiceProviderByIdentityUsersDefaultParams(ref string UserID);

      partial void OnFindServiceProviderByIdentityUsersInvoke(ref IQueryable<Models.RecoDb.FindServiceProviderByIdentityUser> items);
        public async Task ExportFirmsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/firms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/firms/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFirmsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/firms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/firms/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFirmsRead(ref IQueryable<Models.RecoDb.Firm> items);

        public async Task<IQueryable<Models.RecoDb.Firm>> GetFirms(Query query = null)
        {
            var items = Context.Firms.AsQueryable();

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFirmsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnFirmCreated(Models.RecoDb.Firm item);
        partial void OnAfterFirmCreated(Models.RecoDb.Firm item);

        public async Task<Models.RecoDb.Firm> CreateFirm(Models.RecoDb.Firm firm)
        {
            OnFirmCreated(firm);

            var existingItem = Context.Firms
                              .Where(i => i.ID == firm.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Firms.Add(firm);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(firm).State = EntityState.Detached;
                firm.Parameter = null;
                throw;
            }

            OnAfterFirmCreated(firm);

            return firm;
        }
        public async Task ExportFirmDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/firmdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/firmdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFirmDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/firmdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/firmdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFirmDetailsRead(ref IQueryable<Models.RecoDb.FirmDetail> items);

        public async Task<IQueryable<Models.RecoDb.FirmDetail>> GetFirmDetails(Query query = null)
        {
            var items = Context.FirmDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFirmDetailsRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportFullBordereausToExcel(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fullbordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/fullbordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportFullBordereausToCSV(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fullbordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/fullbordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.FullBordereau>> GetFullBordereaus(string ReportDate, Query query = null)
      {
          OnFullBordereausDefaultParams(ref ReportDate);

          var items = Context.FullBordereaus.FromSqlRaw("EXEC [dbo].[FullBordereau] @ReportDate={0}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnFullBordereausInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnFullBordereausDefaultParams(ref string ReportDate);

      partial void OnFullBordereausInvoke(ref IQueryable<Models.RecoDb.FullBordereau> items);

      public async Task ExportFullBordereauRecosToExcel(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fullbordereaurecos/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/fullbordereaurecos/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportFullBordereauRecosToCSV(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fullbordereaurecos/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/fullbordereaurecos/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.FullBordereauReco>> GetFullBordereauRecos(string ReportDate, Query query = null)
      {
          OnFullBordereauRecosDefaultParams(ref ReportDate);

          var items = Context.FullBordereauRecos.FromSqlRaw("EXEC [dbo].[FullBordereau_RECO] @ReportDate={0}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnFullBordereauRecosInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnFullBordereauRecosDefaultParams(ref string ReportDate);

      partial void OnFullBordereauRecosInvoke(ref IQueryable<Models.RecoDb.FullBordereauReco> items);
        public async Task ExportFullClaimStatusHistoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fullclaimstatushistories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/fullclaimstatushistories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportFullClaimStatusHistoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fullclaimstatushistories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/fullclaimstatushistories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnFullClaimStatusHistoriesRead(ref IQueryable<Models.RecoDb.FullClaimStatusHistory> items);

        public async Task<IQueryable<Models.RecoDb.FullClaimStatusHistory>> GetFullClaimStatusHistories(Query query = null)
        {
            var items = Context.FullClaimStatusHistories.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnFullClaimStatusHistoriesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportGeneralSettingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generalsettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generalsettings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportGeneralSettingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generalsettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generalsettings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnGeneralSettingsRead(ref IQueryable<Models.RecoDb.GeneralSetting> items);

        public IQueryable<Models.RecoDb.GeneralSetting> GetGeneralSettings(Query query = null)
        {
            var items = Context.GeneralSettings.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnGeneralSettingsRead(ref items);

            return items;
        }

        partial void OnGeneralSettingCreated(Models.RecoDb.GeneralSetting item);
        partial void OnAfterGeneralSettingCreated(Models.RecoDb.GeneralSetting item);

        public async Task<Models.RecoDb.GeneralSetting> CreateGeneralSetting(Models.RecoDb.GeneralSetting generalSetting)
        {
            OnGeneralSettingCreated(generalSetting);

            var existingItem = Context.GeneralSettings
                              .Where(i => i.ID == generalSetting.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.GeneralSettings.Add(generalSetting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(generalSetting).State = EntityState.Detached;
                throw;
            }

            OnAfterGeneralSettingCreated(generalSetting);

            return generalSetting;
        }

      public async Task ExportGenerateClaimNumbersToExcel(int? ProgramID, int? ContractYear, int? SelectedOccurrence, bool? IsIncident, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generateclaimnumbers/excel(ProgramID={ProgramID}, ContractYear={ContractYear}, SelectedOccurrence={SelectedOccurrence}, IsIncident={IsIncident}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generateclaimnumbers/excel(ProgramID={ProgramID}, ContractYear={ContractYear}, SelectedOccurrence={SelectedOccurrence}, IsIncident={IsIncident}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGenerateClaimNumbersToCSV(int? ProgramID, int? ContractYear, int? SelectedOccurrence, bool? IsIncident, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generateclaimnumbers/csv(ProgramID={ProgramID}, ContractYear={ContractYear}, SelectedOccurrence={SelectedOccurrence}, IsIncident={IsIncident}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generateclaimnumbers/csv(ProgramID={ProgramID}, ContractYear={ContractYear}, SelectedOccurrence={SelectedOccurrence}, IsIncident={IsIncident}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GenerateClaimNumber>> GetGenerateClaimNumbers(int? ProgramID, int? ContractYear, int? SelectedOccurrence, bool? IsIncident, Query query = null)
      {
          OnGenerateClaimNumbersDefaultParams(ref ProgramID, ref ContractYear, ref SelectedOccurrence, ref IsIncident);

          var items = Context.GenerateClaimNumbers.FromSqlRaw("EXEC [dbo].[GenerateClaimNumber] @ProgramID={0}, @ContractYear={1}, @SelectedOccurrence={2}, @IsIncident={3}", ProgramID, ContractYear, SelectedOccurrence, IsIncident).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGenerateClaimNumbersInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGenerateClaimNumbersDefaultParams(ref int? ProgramID, ref int? ContractYear, ref int? SelectedOccurrence, ref bool? IsIncident);

      partial void OnGenerateClaimNumbersInvoke(ref IQueryable<Models.RecoDb.GenerateClaimNumber> items);

      public async Task ExportGenerateNewClaimantClaimsToExcel(int? MasterFileID, int? ClaimantID, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generatenewclaimantclaims/excel(MasterFileID={MasterFileID}, ClaimantID={ClaimantID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generatenewclaimantclaims/excel(MasterFileID={MasterFileID}, ClaimantID={ClaimantID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGenerateNewClaimantClaimsToCSV(int? MasterFileID, int? ClaimantID, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generatenewclaimantclaims/csv(MasterFileID={MasterFileID}, ClaimantID={ClaimantID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generatenewclaimantclaims/csv(MasterFileID={MasterFileID}, ClaimantID={ClaimantID}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GenerateNewClaimantClaim>> GetGenerateNewClaimantClaims(int? MasterFileID, int? ClaimantID, string UserID, Query query = null)
      {
          OnGenerateNewClaimantClaimsDefaultParams(ref MasterFileID, ref ClaimantID, ref UserID);

          var items = Context.GenerateNewClaimantClaims.FromSqlRaw("EXEC [dbo].[GenerateNewClaimantClaim] @MasterFileID={0}, @ClaimantID={1}, @UserID={2}", MasterFileID, ClaimantID, UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGenerateNewClaimantClaimsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGenerateNewClaimantClaimsDefaultParams(ref int? MasterFileID, ref int? ClaimantID, ref string UserID);

      partial void OnGenerateNewClaimantClaimsInvoke(ref IQueryable<Models.RecoDb.GenerateNewClaimantClaim> items);

      public async Task ExportGenerateNewClaimantTradeClaimsToExcel(int? MasterClaimID, int? ClaimantID, string ReportDate, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generatenewclaimanttradeclaims/excel(MasterClaimID={MasterClaimID}, ClaimantID={ClaimantID}, ReportDate='{ReportDate}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generatenewclaimanttradeclaims/excel(MasterClaimID={MasterClaimID}, ClaimantID={ClaimantID}, ReportDate='{ReportDate}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGenerateNewClaimantTradeClaimsToCSV(int? MasterClaimID, int? ClaimantID, string ReportDate, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generatenewclaimanttradeclaims/csv(MasterClaimID={MasterClaimID}, ClaimantID={ClaimantID}, ReportDate='{ReportDate}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generatenewclaimanttradeclaims/csv(MasterClaimID={MasterClaimID}, ClaimantID={ClaimantID}, ReportDate='{ReportDate}', UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GenerateNewClaimantTradeClaim>> GetGenerateNewClaimantTradeClaims(int? MasterClaimID, int? ClaimantID, string ReportDate, string UserID, Query query = null)
      {
          OnGenerateNewClaimantTradeClaimsDefaultParams(ref MasterClaimID, ref ClaimantID, ref ReportDate, ref UserID);

          var items = Context.GenerateNewClaimantTradeClaims.FromSqlRaw("EXEC [dbo].[GenerateNewClaimantTradeClaim] @MasterClaimID={0}, @ClaimantID={1}, @ReportDate={2}, @UserID={3}", MasterClaimID, ClaimantID, string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGenerateNewClaimantTradeClaimsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGenerateNewClaimantTradeClaimsDefaultParams(ref int? MasterClaimID, ref int? ClaimantID, ref string ReportDate, ref string UserID);

      partial void OnGenerateNewClaimantTradeClaimsInvoke(ref IQueryable<Models.RecoDb.GenerateNewClaimantTradeClaim> items);

      public async Task ExportGenerateNewOccurrencesToExcel(int? ProgramID, int? ContractYear, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generatenewoccurrences/excel(ProgramID={ProgramID}, ContractYear={ContractYear}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generatenewoccurrences/excel(ProgramID={ProgramID}, ContractYear={ContractYear}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGenerateNewOccurrencesToCSV(int? ProgramID, int? ContractYear, string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/generatenewoccurrences/csv(ProgramID={ProgramID}, ContractYear={ContractYear}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/generatenewoccurrences/csv(ProgramID={ProgramID}, ContractYear={ContractYear}, UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GenerateNewOccurrence>> GetGenerateNewOccurrences(int? ProgramID, int? ContractYear, string UserID, Query query = null)
      {
          OnGenerateNewOccurrencesDefaultParams(ref ProgramID, ref ContractYear, ref UserID);

          var items = Context.GenerateNewOccurrences.FromSqlRaw("EXEC [dbo].[GenerateNewOccurrence] @ProgramID={0}, @ContractYear={1}, @UserID={2}", ProgramID, ContractYear, UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGenerateNewOccurrencesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGenerateNewOccurrencesDefaultParams(ref int? ProgramID, ref int? ContractYear, ref string UserID);

      partial void OnGenerateNewOccurrencesInvoke(ref IQueryable<Models.RecoDb.GenerateNewOccurrence> items);

      public async Task ExportGetAvailableServiceProvidersToExcel(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getavailableserviceproviders/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getavailableserviceproviders/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetAvailableServiceProvidersToCSV(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getavailableserviceproviders/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getavailableserviceproviders/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetAvailableServiceProvider>> GetGetAvailableServiceProviders(int? ClaimID, Query query = null)
      {
          OnGetAvailableServiceProvidersDefaultParams(ref ClaimID);

          var items = Context.GetAvailableServiceProviders.FromSqlRaw("EXEC [dbo].[GetAvailableServiceProviders] @ClaimID={0}", ClaimID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetAvailableServiceProvidersInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetAvailableServiceProvidersDefaultParams(ref int? ClaimID);

      partial void OnGetAvailableServiceProvidersInvoke(ref IQueryable<Models.RecoDb.GetAvailableServiceProvider> items);

      public async Task ExportGetFileByIdsToExcel(string Id, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getfilebyids/excel(Id='{Id}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getfilebyids/excel(Id='{Id}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetFileByIdsToCSV(string Id, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getfilebyids/csv(Id='{Id}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getfilebyids/csv(Id='{Id}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetFileById>> GetGetFileByIds(string Id, Query query = null)
      {
          OnGetFileByIdsDefaultParams(ref Id);

          var items = Context.GetFileByIds.FromSqlRaw("EXEC [dbo].[GetFileById] @Id={0}", Id).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetFileByIdsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetFileByIdsDefaultParams(ref string Id);

      partial void OnGetFileByIdsInvoke(ref IQueryable<Models.RecoDb.GetFileById> items);

      public async Task ExportGetHigherRankedRolesToExcel(string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/gethigherrankedroles/excel(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/gethigherrankedroles/excel(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetHigherRankedRolesToCSV(string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/gethigherrankedroles/csv(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/gethigherrankedroles/csv(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetHigherRankedRole>> GetGetHigherRankedRoles(string UserID, Query query = null)
      {
          OnGetHigherRankedRolesDefaultParams(ref UserID);

          var items = Context.GetHigherRankedRoles.FromSqlRaw("EXEC [dbo].[GetHigherRankedRoles] @UserID={0}", UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetHigherRankedRolesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetHigherRankedRolesDefaultParams(ref string UserID);

      partial void OnGetHigherRankedRolesInvoke(ref IQueryable<Models.RecoDb.GetHigherRankedRole> items);

      public async Task ExportGetLowerRankedRolesToExcel(string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getlowerrankedroles/excel(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getlowerrankedroles/excel(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetLowerRankedRolesToCSV(string UserID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getlowerrankedroles/csv(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getlowerrankedroles/csv(UserID='{UserID}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetLowerRankedRole>> GetGetLowerRankedRoles(string UserID, Query query = null)
      {
          OnGetLowerRankedRolesDefaultParams(ref UserID);

          var items = Context.GetLowerRankedRoles.FromSqlRaw("EXEC [dbo].[GetLowerRankedRoles] @UserID={0}", UserID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetLowerRankedRolesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetLowerRankedRolesDefaultParams(ref string UserID);

      partial void OnGetLowerRankedRolesInvoke(ref IQueryable<Models.RecoDb.GetLowerRankedRole> items);

      public async Task ExportGetMaxDiaryTemplateDisplayOrdersToExcel(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getmaxdiarytemplatedisplayorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getmaxdiarytemplatedisplayorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetMaxDiaryTemplateDisplayOrdersToCSV(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getmaxdiarytemplatedisplayorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getmaxdiarytemplatedisplayorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetMaxDiaryTemplateDisplayOrder>> GetGetMaxDiaryTemplateDisplayOrders(Query query = null)
      {
          var items = Context.GetMaxDiaryTemplateDisplayOrders.FromSqlRaw("EXEC [dbo].[GetMaxDiaryTemplateDisplayOrder]").ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetMaxDiaryTemplateDisplayOrdersInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetMaxDiaryTemplateDisplayOrdersInvoke(ref IQueryable<Models.RecoDb.GetMaxDiaryTemplateDisplayOrder> items);

      public async Task ExportGetNextClaimantOrderNumsToExcel(int? claimid, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getnextclaimantordernums/excel(claimid={claimid}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getnextclaimantordernums/excel(claimid={claimid}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetNextClaimantOrderNumsToCSV(int? claimid, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getnextclaimantordernums/csv(claimid={claimid}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getnextclaimantordernums/csv(claimid={claimid}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetNextClaimantOrderNum>> GetGetNextClaimantOrderNums(int? claimid, Query query = null)
      {
          OnGetNextClaimantOrderNumsDefaultParams(ref claimid);

          var items = Context.GetNextClaimantOrderNums.FromSqlRaw("EXEC [dbo].[GetNextClaimantOrderNum] @claimid={0}", claimid).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetNextClaimantOrderNumsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetNextClaimantOrderNumsDefaultParams(ref int? claimid);

      partial void OnGetNextClaimantOrderNumsInvoke(ref IQueryable<Models.RecoDb.GetNextClaimantOrderNum> items);

      public async Task ExportGetNextInsuredOrderNumsToExcel(int? claimid, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getnextinsuredordernums/excel(claimid={claimid}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getnextinsuredordernums/excel(claimid={claimid}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetNextInsuredOrderNumsToCSV(int? claimid, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getnextinsuredordernums/csv(claimid={claimid}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getnextinsuredordernums/csv(claimid={claimid}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetNextInsuredOrderNum>> GetGetNextInsuredOrderNums(int? claimid, Query query = null)
      {
          OnGetNextInsuredOrderNumsDefaultParams(ref claimid);

          var items = Context.GetNextInsuredOrderNums.FromSqlRaw("EXEC [dbo].[GetNextInsuredOrderNum] @claimid={0}", claimid).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetNextInsuredOrderNumsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetNextInsuredOrderNumsDefaultParams(ref int? claimid);

      partial void OnGetNextInsuredOrderNumsInvoke(ref IQueryable<Models.RecoDb.GetNextInsuredOrderNum> items);

      public async Task ExportGetReportDatesToExcel(int? ServiceProviderID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getreportdates/excel(ServiceProviderID={ServiceProviderID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getreportdates/excel(ServiceProviderID={ServiceProviderID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetReportDatesToCSV(int? ServiceProviderID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getreportdates/csv(ServiceProviderID={ServiceProviderID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getreportdates/csv(ServiceProviderID={ServiceProviderID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetReportDate>> GetGetReportDates(int? ServiceProviderID, Query query = null)
      {
          OnGetReportDatesDefaultParams(ref ServiceProviderID);

          var items = Context.GetReportDates.FromSqlRaw("EXEC [dbo].[GetReportDate] @ServiceProviderID={0}", ServiceProviderID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetReportDatesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetReportDatesDefaultParams(ref int? ServiceProviderID);

      partial void OnGetReportDatesInvoke(ref IQueryable<Models.RecoDb.GetReportDate> items);

      public async Task ExportGetSevenYearsClaimIndemnitiesToExcel(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getsevenyearsclaimindemnities/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getsevenyearsclaimindemnities/excel(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportGetSevenYearsClaimIndemnitiesToCSV(int? ClaimID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/getsevenyearsclaimindemnities/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/getsevenyearsclaimindemnities/csv(ClaimID={ClaimID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.GetSevenYearsClaimIndemnity>> GetGetSevenYearsClaimIndemnities(int? ClaimID, Query query = null)
      {
          OnGetSevenYearsClaimIndemnitiesDefaultParams(ref ClaimID);

          var items = Context.GetSevenYearsClaimIndemnities.FromSqlRaw("EXEC [dbo].[GetSevenYearsClaimIndemnity] @ClaimID={0}", ClaimID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnGetSevenYearsClaimIndemnitiesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnGetSevenYearsClaimIndemnitiesDefaultParams(ref int? ClaimID);

      partial void OnGetSevenYearsClaimIndemnitiesInvoke(ref IQueryable<Models.RecoDb.GetSevenYearsClaimIndemnity> items);
        public async Task ExportInsuredsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/insureds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/insureds/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInsuredsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/insureds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/insureds/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInsuredsRead(ref IQueryable<Models.RecoDb.Insured> items);

        public async Task<IQueryable<Models.RecoDb.Insured>> GetInsureds(Query query = null)
        {
            var items = Context.Insureds.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Brokerage);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInsuredsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInsuredCreated(Models.RecoDb.Insured item);
        partial void OnAfterInsuredCreated(Models.RecoDb.Insured item);

        public async Task<Models.RecoDb.Insured> CreateInsured(Models.RecoDb.Insured insured)
        {
            OnInsuredCreated(insured);

            var existingItem = Context.Insureds
                              .Where(i => i.ID == insured.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Insureds.Add(insured);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(insured).State = EntityState.Detached;
                insured.Claim = null;
                insured.Registrant = null;
                insured.Parameter = null;
                insured.Brokerage = null;
                insured.Parameter1 = null;
                throw;
            }

            OnAfterInsuredCreated(insured);

            return insured;
        }
        public async Task ExportInsuredLitigationRolesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/insuredlitigationroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/insuredlitigationroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInsuredLitigationRolesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/insuredlitigationroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/insuredlitigationroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInsuredLitigationRolesRead(ref IQueryable<Models.RecoDb.InsuredLitigationRole> items);

        public async Task<IQueryable<Models.RecoDb.InsuredLitigationRole>> GetInsuredLitigationRoles(Query query = null)
        {
            var items = Context.InsuredLitigationRoles.AsQueryable();

            items = items.Include(i => i.Insured);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInsuredLitigationRolesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInsuredLitigationRoleCreated(Models.RecoDb.InsuredLitigationRole item);
        partial void OnAfterInsuredLitigationRoleCreated(Models.RecoDb.InsuredLitigationRole item);

        public async Task<Models.RecoDb.InsuredLitigationRole> CreateInsuredLitigationRole(Models.RecoDb.InsuredLitigationRole insuredLitigationRole)
        {
            OnInsuredLitigationRoleCreated(insuredLitigationRole);

            var existingItem = Context.InsuredLitigationRoles
                              .Where(i => i.InsuredID == insuredLitigationRole.InsuredID && i.LitigationRoleID == insuredLitigationRole.LitigationRoleID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.InsuredLitigationRoles.Add(insuredLitigationRole);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(insuredLitigationRole).State = EntityState.Detached;
                insuredLitigationRole.Insured = null;
                insuredLitigationRole.Parameter = null;
                throw;
            }

            OnAfterInsuredLitigationRoleCreated(insuredLitigationRole);

            return insuredLitigationRole;
        }
        public async Task ExportInvoiceUploadsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/invoiceuploads/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/invoiceuploads/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvoiceUploadsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/invoiceuploads/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/invoiceuploads/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvoiceUploadsRead(ref IQueryable<Models.RecoDb.InvoiceUpload> items);

        public async Task<IQueryable<Models.RecoDb.InvoiceUpload>> GetInvoiceUploads(Query query = null)
        {
            var items = Context.InvoiceUploads.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvoiceUploadsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInvoiceUploadCreated(Models.RecoDb.InvoiceUpload item);
        partial void OnAfterInvoiceUploadCreated(Models.RecoDb.InvoiceUpload item);

        public async Task<Models.RecoDb.InvoiceUpload> CreateInvoiceUpload(Models.RecoDb.InvoiceUpload invoiceUpload)
        {
            OnInvoiceUploadCreated(invoiceUpload);

            var existingItem = Context.InvoiceUploads
                              .Where(i => i.InvoiceUploadID == invoiceUpload.InvoiceUploadID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.InvoiceUploads.Add(invoiceUpload);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(invoiceUpload).State = EntityState.Detached;
                throw;
            }

            OnAfterInvoiceUploadCreated(invoiceUpload);

            return invoiceUpload;
        }
        public async Task ExportInvoiceUploadFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/invoiceuploadfiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/invoiceuploadfiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvoiceUploadFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/invoiceuploadfiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/invoiceuploadfiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvoiceUploadFilesRead(ref IQueryable<Models.RecoDb.InvoiceUploadFile> items);

        public async Task<IQueryable<Models.RecoDb.InvoiceUploadFile>> GetInvoiceUploadFiles(Query query = null)
        {
            var items = Context.InvoiceUploadFiles.AsQueryable();

            items = items.Include(i => i.Firm);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvoiceUploadFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInvoiceUploadFileCreated(Models.RecoDb.InvoiceUploadFile item);
        partial void OnAfterInvoiceUploadFileCreated(Models.RecoDb.InvoiceUploadFile item);

        public async Task<Models.RecoDb.InvoiceUploadFile> CreateInvoiceUploadFile(Models.RecoDb.InvoiceUploadFile invoiceUploadFile)
        {
            OnInvoiceUploadFileCreated(invoiceUploadFile);

            var existingItem = Context.InvoiceUploadFiles
                              .Where(i => i.FileID == invoiceUploadFile.FileID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.InvoiceUploadFiles.Add(invoiceUploadFile);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(invoiceUploadFile).State = EntityState.Detached;
                invoiceUploadFile.Firm = null;
                throw;
            }

            OnAfterInvoiceUploadFileCreated(invoiceUploadFile);

            return invoiceUploadFile;
        }
        public async Task ExportInvoiceUploadRowErrorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/invoiceuploadrowerrors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/invoiceuploadrowerrors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportInvoiceUploadRowErrorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/invoiceuploadrowerrors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/invoiceuploadrowerrors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnInvoiceUploadRowErrorsRead(ref IQueryable<Models.RecoDb.InvoiceUploadRowError> items);

        public async Task<IQueryable<Models.RecoDb.InvoiceUploadRowError>> GetInvoiceUploadRowErrors(Query query = null)
        {
            var items = Context.InvoiceUploadRowErrors.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnInvoiceUploadRowErrorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnInvoiceUploadRowErrorCreated(Models.RecoDb.InvoiceUploadRowError item);
        partial void OnAfterInvoiceUploadRowErrorCreated(Models.RecoDb.InvoiceUploadRowError item);

        public async Task<Models.RecoDb.InvoiceUploadRowError> CreateInvoiceUploadRowError(Models.RecoDb.InvoiceUploadRowError invoiceUploadRowError)
        {
            OnInvoiceUploadRowErrorCreated(invoiceUploadRowError);

            var existingItem = Context.InvoiceUploadRowErrors
                              .Where(i => i.ErrorID == invoiceUploadRowError.ErrorID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.InvoiceUploadRowErrors.Add(invoiceUploadRowError);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(invoiceUploadRowError).State = EntityState.Detached;
                throw;
            }

            OnAfterInvoiceUploadRowErrorCreated(invoiceUploadRowError);

            return invoiceUploadRowError;
        }
        public async Task ExportIssueReportingsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/issuereportings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/issuereportings/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportIssueReportingsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/issuereportings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/issuereportings/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnIssueReportingsRead(ref IQueryable<Models.RecoDb.IssueReporting> items);

        public async Task<IQueryable<Models.RecoDb.IssueReporting>> GetIssueReportings(Query query = null)
        {
            var items = Context.IssueReportings.AsQueryable();

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnIssueReportingsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnIssueReportingCreated(Models.RecoDb.IssueReporting item);
        partial void OnAfterIssueReportingCreated(Models.RecoDb.IssueReporting item);

        public async Task<Models.RecoDb.IssueReporting> CreateIssueReporting(Models.RecoDb.IssueReporting issueReporting)
        {
            OnIssueReportingCreated(issueReporting);

            var existingItem = Context.IssueReportings
                              .Where(i => i.IssueReportingID == issueReporting.IssueReportingID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.IssueReportings.Add(issueReporting);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(issueReporting).State = EntityState.Detached;
                issueReporting.Parameter = null;
                throw;
            }

            OnAfterIssueReportingCreated(issueReporting);

            return issueReporting;
        }

      public async Task ExportLargeLossBordereausToExcel(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/largelossbordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/largelossbordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportLargeLossBordereausToCSV(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/largelossbordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/largelossbordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.LargeLossBordereau>> GetLargeLossBordereaus(string ReportDate, Query query = null)
      {
          OnLargeLossBordereausDefaultParams(ref ReportDate);

          var items = Context.LargeLossBordereaus.FromSqlRaw("EXEC [dbo].[LargeLossBordereau] @ReportDate={0}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnLargeLossBordereausInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnLargeLossBordereausDefaultParams(ref string ReportDate);

      partial void OnLargeLossBordereausInvoke(ref IQueryable<Models.RecoDb.LargeLossBordereau> items);

      public async Task ExportLastDefenceClaimReportsToExcel(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/lastdefenceclaimreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/lastdefenceclaimreports/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportLastDefenceClaimReportsToCSV(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/lastdefenceclaimreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/lastdefenceclaimreports/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.LastDefenceClaimReport>> GetLastDefenceClaimReports(Query query = null)
      {
          var items = Context.LastDefenceClaimReports.FromSqlRaw("EXEC [dbo].[LastDefenceClaimReport]").ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnLastDefenceClaimReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnLastDefenceClaimReportsInvoke(ref IQueryable<Models.RecoDb.LastDefenceClaimReport> items);
        public async Task ExportLossCauseTagsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/losscausetags/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/losscausetags/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLossCauseTagsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/losscausetags/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/losscausetags/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLossCauseTagsRead(ref IQueryable<Models.RecoDb.LossCauseTag> items);

        public async Task<IQueryable<Models.RecoDb.LossCauseTag>> GetLossCauseTags(Query query = null)
        {
            var items = Context.LossCauseTags.AsQueryable();

            items = items.Include(i => i.Claim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLossCauseTagsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnLossCauseTagCreated(Models.RecoDb.LossCauseTag item);
        partial void OnAfterLossCauseTagCreated(Models.RecoDb.LossCauseTag item);

        public async Task<Models.RecoDb.LossCauseTag> CreateLossCauseTag(Models.RecoDb.LossCauseTag lossCauseTag)
        {
            OnLossCauseTagCreated(lossCauseTag);

            var existingItem = Context.LossCauseTags
                              .Where(i => i.ClaimID == lossCauseTag.ClaimID && i.LossCauseTag1 == lossCauseTag.LossCauseTag1)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.LossCauseTags.Add(lossCauseTag);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(lossCauseTag).State = EntityState.Detached;
                lossCauseTag.Claim = null;
                throw;
            }

            OnAfterLossCauseTagCreated(lossCauseTag);

            return lossCauseTag;
        }
        public async Task ExportLossCauseTagCountsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/losscausetagcounts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/losscausetagcounts/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportLossCauseTagCountsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/losscausetagcounts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/losscausetagcounts/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnLossCauseTagCountsRead(ref IQueryable<Models.RecoDb.LossCauseTagCount> items);

        public async Task<IQueryable<Models.RecoDb.LossCauseTagCount>> GetLossCauseTagCounts(Query query = null)
        {
            var items = Context.LossCauseTagCounts.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnLossCauseTagCountsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportMostRecentStatusChangeDatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/mostrecentstatuschangedates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/mostrecentstatuschangedates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportMostRecentStatusChangeDatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/mostrecentstatuschangedates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/mostrecentstatuschangedates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnMostRecentStatusChangeDatesRead(ref IQueryable<Models.RecoDb.MostRecentStatusChangeDate> items);

        public async Task<IQueryable<Models.RecoDb.MostRecentStatusChangeDate>> GetMostRecentStatusChangeDates(Query query = null)
        {
            var items = Context.MostRecentStatusChangeDates.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnMostRecentStatusChangeDatesRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportMovementBordereausToExcel(string ReportDate, string PreviousDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/movementbordereaus/excel(ReportDate='{ReportDate}', PreviousDate='{PreviousDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/movementbordereaus/excel(ReportDate='{ReportDate}', PreviousDate='{PreviousDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportMovementBordereausToCSV(string ReportDate, string PreviousDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/movementbordereaus/csv(ReportDate='{ReportDate}', PreviousDate='{PreviousDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/movementbordereaus/csv(ReportDate='{ReportDate}', PreviousDate='{PreviousDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.MovementBordereau>> GetMovementBordereaus(string ReportDate, string PreviousDate, Query query = null)
      {
          OnMovementBordereausDefaultParams(ref ReportDate, ref PreviousDate);

          var items = Context.MovementBordereaus.FromSqlRaw("EXEC [dbo].[MovementBordereau] @ReportDate={0}, @PreviousDate={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(PreviousDate) ? DBNull.Value : (object)DateTime.Parse(PreviousDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnMovementBordereausInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnMovementBordereausDefaultParams(ref string ReportDate, ref string PreviousDate);

      partial void OnMovementBordereausInvoke(ref IQueryable<Models.RecoDb.MovementBordereau> items);
        public async Task ExportNextClaimDisplayOrdersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/nextclaimdisplayorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/nextclaimdisplayorders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNextClaimDisplayOrdersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/nextclaimdisplayorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/nextclaimdisplayorders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNextClaimDisplayOrdersRead(ref IQueryable<Models.RecoDb.NextClaimDisplayOrder> items);

        public async Task<IQueryable<Models.RecoDb.NextClaimDisplayOrder>> GetNextClaimDisplayOrders(Query query = null)
        {
            var items = Context.NextClaimDisplayOrders.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNextClaimDisplayOrdersRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportNoActiveDiaryBordereausToExcel(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noactivediarybordereaus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noactivediarybordereaus/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportNoActiveDiaryBordereausToCSV(Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noactivediarybordereaus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noactivediarybordereaus/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.NoActiveDiaryBordereau>> GetNoActiveDiaryBordereaus(Query query = null)
      {
          var items = Context.NoActiveDiaryBordereaus.FromSqlRaw("EXEC [dbo].[NoActiveDiaryBordereau]").ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnNoActiveDiaryBordereausInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnNoActiveDiaryBordereausInvoke(ref IQueryable<Models.RecoDb.NoActiveDiaryBordereau> items);
        public async Task ExportNotesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/notes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/notes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNotesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/notes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/notes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNotesRead(ref IQueryable<Models.RecoDb.Note> items);

        public async Task<IQueryable<Models.RecoDb.Note>> GetNotes(Query query = null)
        {
            var items = Context.Notes.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNotesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoteCreated(Models.RecoDb.Note item);
        partial void OnAfterNoteCreated(Models.RecoDb.Note item);

        public async Task<Models.RecoDb.Note> CreateNote(Models.RecoDb.Note note)
        {
            OnNoteCreated(note);

            var existingItem = Context.Notes
                              .Where(i => i.ID == note.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Notes.Add(note);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(note).State = EntityState.Detached;
                note.Claim = null;
                note.Parameter = null;
                throw;
            }

            OnAfterNoteCreated(note);

            return note;
        }
        public async Task ExportNoteRolesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noteroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noteroles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoteRolesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noteroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noteroles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoteRolesRead(ref IQueryable<Models.RecoDb.NoteRole> items);

        public async Task<IQueryable<Models.RecoDb.NoteRole>> GetNoteRoles(Query query = null)
        {
            var items = Context.NoteRoles.AsQueryable();

            items = items.Include(i => i.Note);

            items = items.Include(i => i.Role);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoteRolesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoteRoleCreated(Models.RecoDb.NoteRole item);
        partial void OnAfterNoteRoleCreated(Models.RecoDb.NoteRole item);

        public async Task<Models.RecoDb.NoteRole> CreateNoteRole(Models.RecoDb.NoteRole noteRole)
        {
            OnNoteRoleCreated(noteRole);

            var existingItem = Context.NoteRoles
                              .Where(i => i.Id == noteRole.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoteRoles.Add(noteRole);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noteRole).State = EntityState.Detached;
                noteRole.Note = null;
                noteRole.Role = null;
                throw;
            }

            OnAfterNoteRoleCreated(noteRole);

            return noteRole;
        }
        public async Task ExportNoticeOfClaimsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimsRead(ref IQueryable<Models.RecoDb.NoticeOfClaim> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaim>> GetNoticeOfClaims(Query query = null)
        {
            var items = Context.NoticeOfClaims.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Claim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoticeOfClaimCreated(Models.RecoDb.NoticeOfClaim item);
        partial void OnAfterNoticeOfClaimCreated(Models.RecoDb.NoticeOfClaim item);

        public async Task<Models.RecoDb.NoticeOfClaim> CreateNoticeOfClaim(Models.RecoDb.NoticeOfClaim noticeOfClaim)
        {
            OnNoticeOfClaimCreated(noticeOfClaim);

            var existingItem = Context.NoticeOfClaims
                              .Where(i => i.NoticeOfClaimID == noticeOfClaim.NoticeOfClaimID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoticeOfClaims.Add(noticeOfClaim);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noticeOfClaim).State = EntityState.Detached;
                noticeOfClaim.Parameter = null;
                noticeOfClaim.Parameter1 = null;
                noticeOfClaim.Claim = null;
                throw;
            }

            OnAfterNoticeOfClaimCreated(noticeOfClaim);

            return noticeOfClaim;
        }
        public async Task ExportNoticeOfClaimBrokeragesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimbrokerages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimbrokerages/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimBrokeragesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimbrokerages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimbrokerages/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimBrokeragesRead(ref IQueryable<Models.RecoDb.NoticeOfClaimBrokerage> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaimBrokerage>> GetNoticeOfClaimBrokerages(Query query = null)
        {
            var items = Context.NoticeOfClaimBrokerages.AsQueryable();

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimBrokeragesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoticeOfClaimBrokerageCreated(Models.RecoDb.NoticeOfClaimBrokerage item);
        partial void OnAfterNoticeOfClaimBrokerageCreated(Models.RecoDb.NoticeOfClaimBrokerage item);

        public async Task<Models.RecoDb.NoticeOfClaimBrokerage> CreateNoticeOfClaimBrokerage(Models.RecoDb.NoticeOfClaimBrokerage noticeOfClaimBrokerage)
        {
            OnNoticeOfClaimBrokerageCreated(noticeOfClaimBrokerage);

            var existingItem = Context.NoticeOfClaimBrokerages
                              .Where(i => i.BrokerageID == noticeOfClaimBrokerage.BrokerageID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoticeOfClaimBrokerages.Add(noticeOfClaimBrokerage);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noticeOfClaimBrokerage).State = EntityState.Detached;
                noticeOfClaimBrokerage.NoticeOfClaim = null;
                noticeOfClaimBrokerage.Parameter = null;
                noticeOfClaimBrokerage.Parameter1 = null;
                throw;
            }

            OnAfterNoticeOfClaimBrokerageCreated(noticeOfClaimBrokerage);

            return noticeOfClaimBrokerage;
        }
        public async Task ExportNoticeOfClaimClaimantsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimclaimants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimclaimants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimClaimantsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimclaimants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimclaimants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimClaimantsRead(ref IQueryable<Models.RecoDb.NoticeOfClaimClaimant> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaimClaimant>> GetNoticeOfClaimClaimants(Query query = null)
        {
            var items = Context.NoticeOfClaimClaimants.AsQueryable();

            items = items.Include(i => i.NoticeOfClaim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimClaimantsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoticeOfClaimClaimantCreated(Models.RecoDb.NoticeOfClaimClaimant item);
        partial void OnAfterNoticeOfClaimClaimantCreated(Models.RecoDb.NoticeOfClaimClaimant item);

        public async Task<Models.RecoDb.NoticeOfClaimClaimant> CreateNoticeOfClaimClaimant(Models.RecoDb.NoticeOfClaimClaimant noticeOfClaimClaimant)
        {
            OnNoticeOfClaimClaimantCreated(noticeOfClaimClaimant);

            var existingItem = Context.NoticeOfClaimClaimants
                              .Where(i => i.ID == noticeOfClaimClaimant.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoticeOfClaimClaimants.Add(noticeOfClaimClaimant);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noticeOfClaimClaimant).State = EntityState.Detached;
                noticeOfClaimClaimant.NoticeOfClaim = null;
                throw;
            }

            OnAfterNoticeOfClaimClaimantCreated(noticeOfClaimClaimant);

            return noticeOfClaimClaimant;
        }
        public async Task ExportNoticeOfClaimFilesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimfiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimfiles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimFilesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimfiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimfiles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimFilesRead(ref IQueryable<Models.RecoDb.NoticeOfClaimFile> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaimFile>> GetNoticeOfClaimFiles(Query query = null)
        {
            var items = Context.NoticeOfClaimFiles.AsQueryable();

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimFilesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoticeOfClaimFileCreated(Models.RecoDb.NoticeOfClaimFile item);
        partial void OnAfterNoticeOfClaimFileCreated(Models.RecoDb.NoticeOfClaimFile item);

        public async Task<Models.RecoDb.NoticeOfClaimFile> CreateNoticeOfClaimFile(Models.RecoDb.NoticeOfClaimFile noticeOfClaimFile)
        {
            OnNoticeOfClaimFileCreated(noticeOfClaimFile);

            var existingItem = Context.NoticeOfClaimFiles
                              .Where(i => i.FileID == noticeOfClaimFile.FileID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoticeOfClaimFiles.Add(noticeOfClaimFile);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noticeOfClaimFile).State = EntityState.Detached;
                noticeOfClaimFile.NoticeOfClaim = null;
                noticeOfClaimFile.Parameter = null;
                throw;
            }

            OnAfterNoticeOfClaimFileCreated(noticeOfClaimFile);

            return noticeOfClaimFile;
        }
        public async Task ExportNoticeOfClaimListsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimlists/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimListsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimlists/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimListsRead(ref IQueryable<Models.RecoDb.NoticeOfClaimList> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaimList>> GetNoticeOfClaimLists(Query query = null)
        {
            var items = Context.NoticeOfClaimLists.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimListsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportNoticeOfClaimPurchasersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimpurchasers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimpurchasers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimPurchasersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimpurchasers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimpurchasers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimPurchasersRead(ref IQueryable<Models.RecoDb.NoticeOfClaimPurchaser> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaimPurchaser>> GetNoticeOfClaimPurchasers(Query query = null)
        {
            var items = Context.NoticeOfClaimPurchasers.AsQueryable();

            items = items.Include(i => i.NoticeOfClaim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimPurchasersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoticeOfClaimPurchaserCreated(Models.RecoDb.NoticeOfClaimPurchaser item);
        partial void OnAfterNoticeOfClaimPurchaserCreated(Models.RecoDb.NoticeOfClaimPurchaser item);

        public async Task<Models.RecoDb.NoticeOfClaimPurchaser> CreateNoticeOfClaimPurchaser(Models.RecoDb.NoticeOfClaimPurchaser noticeOfClaimPurchaser)
        {
            OnNoticeOfClaimPurchaserCreated(noticeOfClaimPurchaser);

            var existingItem = Context.NoticeOfClaimPurchasers
                              .Where(i => i.PurchaserID == noticeOfClaimPurchaser.PurchaserID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoticeOfClaimPurchasers.Add(noticeOfClaimPurchaser);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noticeOfClaimPurchaser).State = EntityState.Detached;
                noticeOfClaimPurchaser.NoticeOfClaim = null;
                throw;
            }

            OnAfterNoticeOfClaimPurchaserCreated(noticeOfClaimPurchaser);

            return noticeOfClaimPurchaser;
        }
        public async Task ExportNoticeOfClaimRegistrantsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimregistrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimregistrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimRegistrantsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimregistrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimregistrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimRegistrantsRead(ref IQueryable<Models.RecoDb.NoticeOfClaimRegistrant> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaimRegistrant>> GetNoticeOfClaimRegistrants(Query query = null)
        {
            var items = Context.NoticeOfClaimRegistrants.AsQueryable();

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.NoticeOfClaimBrokerage);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimRegistrantsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoticeOfClaimRegistrantCreated(Models.RecoDb.NoticeOfClaimRegistrant item);
        partial void OnAfterNoticeOfClaimRegistrantCreated(Models.RecoDb.NoticeOfClaimRegistrant item);

        public async Task<Models.RecoDb.NoticeOfClaimRegistrant> CreateNoticeOfClaimRegistrant(Models.RecoDb.NoticeOfClaimRegistrant noticeOfClaimRegistrant)
        {
            OnNoticeOfClaimRegistrantCreated(noticeOfClaimRegistrant);

            var existingItem = Context.NoticeOfClaimRegistrants
                              .Where(i => i.NOCRegistrantID == noticeOfClaimRegistrant.NOCRegistrantID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoticeOfClaimRegistrants.Add(noticeOfClaimRegistrant);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noticeOfClaimRegistrant).State = EntityState.Detached;
                noticeOfClaimRegistrant.NoticeOfClaim = null;
                noticeOfClaimRegistrant.NoticeOfClaimBrokerage = null;
                noticeOfClaimRegistrant.Parameter = null;
                noticeOfClaimRegistrant.Parameter1 = null;
                throw;
            }

            OnAfterNoticeOfClaimRegistrantCreated(noticeOfClaimRegistrant);

            return noticeOfClaimRegistrant;
        }
        public async Task ExportNoticeOfClaimTradesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimtrades/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimtrades/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimTradesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimtrades/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimtrades/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimTradesRead(ref IQueryable<Models.RecoDb.NoticeOfClaimTrade> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaimTrade>> GetNoticeOfClaimTrades(Query query = null)
        {
            var items = Context.NoticeOfClaimTrades.AsQueryable();

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimTradesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoticeOfClaimTradeCreated(Models.RecoDb.NoticeOfClaimTrade item);
        partial void OnAfterNoticeOfClaimTradeCreated(Models.RecoDb.NoticeOfClaimTrade item);

        public async Task<Models.RecoDb.NoticeOfClaimTrade> CreateNoticeOfClaimTrade(Models.RecoDb.NoticeOfClaimTrade noticeOfClaimTrade)
        {
            OnNoticeOfClaimTradeCreated(noticeOfClaimTrade);

            var existingItem = Context.NoticeOfClaimTrades
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimTrade.NoticeOfClaimID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoticeOfClaimTrades.Add(noticeOfClaimTrade);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noticeOfClaimTrade).State = EntityState.Detached;
                noticeOfClaimTrade.NoticeOfClaim = null;
                noticeOfClaimTrade.Parameter = null;
                throw;
            }

            OnAfterNoticeOfClaimTradeCreated(noticeOfClaimTrade);

            return noticeOfClaimTrade;
        }
        public async Task ExportNoticeOfClaimVendorsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimvendors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimvendors/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportNoticeOfClaimVendorsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/noticeofclaimvendors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/noticeofclaimvendors/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnNoticeOfClaimVendorsRead(ref IQueryable<Models.RecoDb.NoticeOfClaimVendor> items);

        public async Task<IQueryable<Models.RecoDb.NoticeOfClaimVendor>> GetNoticeOfClaimVendors(Query query = null)
        {
            var items = Context.NoticeOfClaimVendors.AsQueryable();

            items = items.Include(i => i.NoticeOfClaim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnNoticeOfClaimVendorsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnNoticeOfClaimVendorCreated(Models.RecoDb.NoticeOfClaimVendor item);
        partial void OnAfterNoticeOfClaimVendorCreated(Models.RecoDb.NoticeOfClaimVendor item);

        public async Task<Models.RecoDb.NoticeOfClaimVendor> CreateNoticeOfClaimVendor(Models.RecoDb.NoticeOfClaimVendor noticeOfClaimVendor)
        {
            OnNoticeOfClaimVendorCreated(noticeOfClaimVendor);

            var existingItem = Context.NoticeOfClaimVendors
                              .Where(i => i.VendorID == noticeOfClaimVendor.VendorID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.NoticeOfClaimVendors.Add(noticeOfClaimVendor);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(noticeOfClaimVendor).State = EntityState.Detached;
                noticeOfClaimVendor.NoticeOfClaim = null;
                throw;
            }

            OnAfterNoticeOfClaimVendorCreated(noticeOfClaimVendor);

            return noticeOfClaimVendor;
        }
        public async Task ExportOccurrencesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOccurrencesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOccurrencesRead(ref IQueryable<Models.RecoDb.Occurrence> items);

        public async Task<IQueryable<Models.RecoDb.Occurrence>> GetOccurrences(Query query = null)
        {
            var items = Context.Occurrences.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Brokerage);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.Receiver);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Parameter3);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOccurrencesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOccurrenceCreated(Models.RecoDb.Occurrence item);
        partial void OnAfterOccurrenceCreated(Models.RecoDb.Occurrence item);

        public async Task<Models.RecoDb.Occurrence> CreateOccurrence(Models.RecoDb.Occurrence occurrence)
        {
            OnOccurrenceCreated(occurrence);

            var existingItem = Context.Occurrences
                              .Where(i => i.ID == occurrence.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Occurrences.Add(occurrence);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(occurrence).State = EntityState.Detached;
                occurrence.Parameter = null;
                occurrence.Brokerage = null;
                occurrence.Parameter1 = null;
                occurrence.Parameter2 = null;
                occurrence.Receiver = null;
                occurrence.ServiceProvider = null;
                occurrence.Parameter3 = null;
                throw;
            }

            OnAfterOccurrenceCreated(occurrence);

            return occurrence;
        }
        public async Task ExportOccurrenceClaimTradesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrenceclaimtrades/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrenceclaimtrades/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOccurrenceClaimTradesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrenceclaimtrades/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrenceclaimtrades/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOccurrenceClaimTradesRead(ref IQueryable<Models.RecoDb.OccurrenceClaimTrade> items);

        public async Task<IQueryable<Models.RecoDb.OccurrenceClaimTrade>> GetOccurrenceClaimTrades(Query query = null)
        {
            var items = Context.OccurrenceClaimTrades.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOccurrenceClaimTradesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportOccurrenceClaimantsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrenceclaimants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrenceclaimants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOccurrenceClaimantsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrenceclaimants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrenceclaimants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOccurrenceClaimantsRead(ref IQueryable<Models.RecoDb.OccurrenceClaimant> items);

        public async Task<IQueryable<Models.RecoDb.OccurrenceClaimant>> GetOccurrenceClaimants(Query query = null)
        {
            var items = Context.OccurrenceClaimants.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOccurrenceClaimantsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportOccurrenceDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrencedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrencedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOccurrenceDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrencedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrencedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOccurrenceDetailsRead(ref IQueryable<Models.RecoDb.OccurrenceDetail> items);

        public async Task<IQueryable<Models.RecoDb.OccurrenceDetail>> GetOccurrenceDetails(Query query = null)
        {
            var items = Context.OccurrenceDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOccurrenceDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportOccurrenceTotalIncurredByCategoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrencetotalincurredbycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrencetotalincurredbycategories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOccurrenceTotalIncurredByCategoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/occurrencetotalincurredbycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/occurrencetotalincurredbycategories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOccurrenceTotalIncurredByCategoriesRead(ref IQueryable<Models.RecoDb.OccurrenceTotalIncurredByCategory> items);

        public async Task<IQueryable<Models.RecoDb.OccurrenceTotalIncurredByCategory>> GetOccurrenceTotalIncurredByCategories(Query query = null)
        {
            var items = Context.OccurrenceTotalIncurredByCategories.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOccurrenceTotalIncurredByCategoriesRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportOpenClaimsByLawFirmReportsToExcel(int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/openclaimsbylawfirmreports/excel(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/openclaimsbylawfirmreports/excel(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportOpenClaimsByLawFirmReportsToCSV(int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/openclaimsbylawfirmreports/csv(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/openclaimsbylawfirmreports/csv(ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.OpenClaimsByLawFirmReport>> GetOpenClaimsByLawFirmReports(int? ProgramID, Query query = null)
      {
          OnOpenClaimsByLawFirmReportsDefaultParams(ref ProgramID);

          var items = Context.OpenClaimsByLawFirmReports.FromSqlRaw("EXEC [dbo].[OpenClaimsByLawFirmReport] @ProgramID={0}", ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnOpenClaimsByLawFirmReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnOpenClaimsByLawFirmReportsDefaultParams(ref int? ProgramID);

      partial void OnOpenClaimsByLawFirmReportsInvoke(ref IQueryable<Models.RecoDb.OpenClaimsByLawFirmReport> items);

      public async Task ExportOpenClaimsReportsToExcel(int? ProgramID, string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/openclaimsreports/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/openclaimsreports/excel(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportOpenClaimsReportsToCSV(int? ProgramID, string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/openclaimsreports/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/openclaimsreports/csv(ProgramID={ProgramID}, ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.OpenClaimsReport>> GetOpenClaimsReports(int? ProgramID, string ReportDate, Query query = null)
      {
          OnOpenClaimsReportsDefaultParams(ref ProgramID, ref ReportDate);

          var items = Context.OpenClaimsReports.FromSqlRaw("EXEC [dbo].[OpenClaimsReport] @ProgramID={0}, @ReportDate={1}", ProgramID, string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnOpenClaimsReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnOpenClaimsReportsDefaultParams(ref int? ProgramID, ref string ReportDate);

      partial void OnOpenClaimsReportsInvoke(ref IQueryable<Models.RecoDb.OpenClaimsReport> items);
        public async Task ExportOpenFilesByLawyersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/openfilesbylawyers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/openfilesbylawyers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOpenFilesByLawyersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/openfilesbylawyers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/openfilesbylawyers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOpenFilesByLawyersRead(ref IQueryable<Models.RecoDb.OpenFilesByLawyer> items);

        public async Task<IQueryable<Models.RecoDb.OpenFilesByLawyer>> GetOpenFilesByLawyers(Query query = null)
        {
            var items = Context.OpenFilesByLawyers.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOpenFilesByLawyersRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportOpenStatusHistoriesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/openstatushistories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/openstatushistories/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOpenStatusHistoriesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/openstatushistories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/openstatushistories/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOpenStatusHistoriesRead(ref IQueryable<Models.RecoDb.OpenStatusHistory> items);

        public async Task<IQueryable<Models.RecoDb.OpenStatusHistory>> GetOpenStatusHistories(Query query = null)
        {
            var items = Context.OpenStatusHistories.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOpenStatusHistoriesRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportOtherPartiesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/otherparties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/otherparties/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportOtherPartiesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/otherparties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/otherparties/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnOtherPartiesRead(ref IQueryable<Models.RecoDb.OtherParty> items);

        public async Task<IQueryable<Models.RecoDb.OtherParty>> GetOtherParties(Query query = null)
        {
            var items = Context.OtherParties.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Parameter3);

            items = items.Include(i => i.Brokerage);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnOtherPartiesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnOtherPartyCreated(Models.RecoDb.OtherParty item);
        partial void OnAfterOtherPartyCreated(Models.RecoDb.OtherParty item);

        public async Task<Models.RecoDb.OtherParty> CreateOtherParty(Models.RecoDb.OtherParty otherParty)
        {
            OnOtherPartyCreated(otherParty);

            var existingItem = Context.OtherParties
                              .Where(i => i.ID == otherParty.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.OtherParties.Add(otherParty);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(otherParty).State = EntityState.Detached;
                otherParty.Claim = null;
                otherParty.Registrant = null;
                otherParty.Parameter = null;
                otherParty.Parameter1 = null;
                otherParty.Parameter2 = null;
                otherParty.ServiceProvider = null;
                otherParty.Parameter3 = null;
                otherParty.Brokerage = null;
                throw;
            }

            OnAfterOtherPartyCreated(otherParty);

            return otherParty;
        }
        public async Task ExportParamTypesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/paramtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/paramtypes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportParamTypesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/paramtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/paramtypes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnParamTypesRead(ref IQueryable<Models.RecoDb.ParamType> items);

        public async Task<IQueryable<Models.RecoDb.ParamType>> GetParamTypes(Query query = null)
        {
            var items = Context.ParamTypes.AsQueryable();

            items = items.Include(i => i.ParamType1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnParamTypesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnParamTypeCreated(Models.RecoDb.ParamType item);
        partial void OnAfterParamTypeCreated(Models.RecoDb.ParamType item);

        public async Task<Models.RecoDb.ParamType> CreateParamType(Models.RecoDb.ParamType paramType)
        {
            OnParamTypeCreated(paramType);

            var existingItem = Context.ParamTypes
                              .Where(i => i.ParamTypeID == paramType.ParamTypeID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ParamTypes.Add(paramType);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(paramType).State = EntityState.Detached;
                paramType.ParamType1 = null;
                throw;
            }

            OnAfterParamTypeCreated(paramType);

            return paramType;
        }
        public async Task ExportParametersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/parameters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/parameters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportParametersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/parameters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/parameters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnParametersRead(ref IQueryable<Models.RecoDb.Parameter> items);

        public async Task<IQueryable<Models.RecoDb.Parameter>> GetParameters(Query query = null)
        {
            var items = Context.Parameters.AsQueryable();

            items = items.Include(i => i.ParamType);

            items = items.Include(i => i.ParamType1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnParametersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnParameterCreated(Models.RecoDb.Parameter item);
        partial void OnAfterParameterCreated(Models.RecoDb.Parameter item);

        public async Task<Models.RecoDb.Parameter> CreateParameter(Models.RecoDb.Parameter parameter)
        {
            OnParameterCreated(parameter);

            var existingItem = Context.Parameters
                              .Where(i => i.ParameterID == parameter.ParameterID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Parameters.Add(parameter);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(parameter).State = EntityState.Detached;
                parameter.ParamType = null;
                parameter.ParamType1 = null;
                throw;
            }

            OnAfterParameterCreated(parameter);

            return parameter;
        }
        public async Task ExportParameterDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/parameterdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/parameterdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportParameterDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/parameterdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/parameterdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnParameterDetailsRead(ref IQueryable<Models.RecoDb.ParameterDetail> items);

        public async Task<IQueryable<Models.RecoDb.ParameterDetail>> GetParameterDetails(Query query = null)
        {
            var items = Context.ParameterDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnParameterDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportPeriodPaymentBreakdownsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/periodpaymentbreakdowns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/periodpaymentbreakdowns/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPeriodPaymentBreakdownsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/periodpaymentbreakdowns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/periodpaymentbreakdowns/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPeriodPaymentBreakdownsRead(ref IQueryable<Models.RecoDb.PeriodPaymentBreakdown> items);

        public async Task<IQueryable<Models.RecoDb.PeriodPaymentBreakdown>> GetPeriodPaymentBreakdowns(Query query = null)
        {
            var items = Context.PeriodPaymentBreakdowns.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPeriodPaymentBreakdownsRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportPolicySummariesToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/policysummaries/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/policysummaries/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportPolicySummariesToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/policysummaries/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/policysummaries/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.PolicySummary>> GetPolicySummaries(string ReportDate, int? ProgramID, Query query = null)
      {
          OnPolicySummariesDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.PolicySummaries.FromSqlRaw("EXEC [dbo].[PolicySummary] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnPolicySummariesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnPolicySummariesDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnPolicySummariesInvoke(ref IQueryable<Models.RecoDb.PolicySummary> items);
        public async Task ExportPostalCodesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/postalcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/postalcodes/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPostalCodesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/postalcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/postalcodes/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPostalCodesRead(ref IQueryable<Models.RecoDb.PostalCode> items);

        public async Task<IQueryable<Models.RecoDb.PostalCode>> GetPostalCodes(Query query = null)
        {
            var items = Context.PostalCodes.AsQueryable();

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPostalCodesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnPostalCodeCreated(Models.RecoDb.PostalCode item);
        partial void OnAfterPostalCodeCreated(Models.RecoDb.PostalCode item);

        public async Task<Models.RecoDb.PostalCode> CreatePostalCode(Models.RecoDb.PostalCode postalCode)
        {
            OnPostalCodeCreated(postalCode);

            var existingItem = Context.PostalCodes
                              .Where(i => i.PostalCode1 == postalCode.PostalCode1)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.PostalCodes.Add(postalCode);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(postalCode).State = EntityState.Detached;
                postalCode.Parameter = null;
                throw;
            }

            OnAfterPostalCodeCreated(postalCode);

            return postalCode;
        }
        public async Task ExportPostalCodeDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/postalcodedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/postalcodedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportPostalCodeDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/postalcodedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/postalcodedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnPostalCodeDetailsRead(ref IQueryable<Models.RecoDb.PostalCodeDetail> items);

        public async Task<IQueryable<Models.RecoDb.PostalCodeDetail>> GetPostalCodeDetails(Query query = null)
        {
            var items = Context.PostalCodeDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnPostalCodeDetailsRead(ref items);

            return await Task.FromResult(items);
        }
      public async Task<int> ProcessInvoicePayments(int? InvoiceUploadID, int? FirmID, string TransactionDate, string Comments, string EnteredBy)
      {
          OnProcessInvoicePaymentsDefaultParams(ref InvoiceUploadID, ref FirmID, ref TransactionDate, ref Comments, ref EnteredBy);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@InvoiceUploadID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = InvoiceUploadID},
              new SqlParameter("@FirmID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = FirmID},
              new SqlParameter("@TransactionDate", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value =  string.IsNullOrEmpty(TransactionDate) ? DBNull.Value : (object)DateTime.Parse(TransactionDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@Comments", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = Comments},
              new SqlParameter("@EnteredBy", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = EnteredBy},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ProcessInvoicePayment] @InvoiceUploadID, @FirmID, @TransactionDate, @Comments, @EnteredBy", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnProcessInvoicePaymentsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnProcessInvoicePaymentsDefaultParams(ref int? InvoiceUploadID, ref int? FirmID, ref string TransactionDate, ref string Comments, ref string EnteredBy);
      partial void OnProcessInvoicePaymentsInvoke(ref int result);
      public async Task<int> ProcessPayments(int? TransactionID)
      {
          OnProcessPaymentsDefaultParams(ref TransactionID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@TransactionID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = TransactionID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ProcessPayment] @TransactionID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnProcessPaymentsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnProcessPaymentsDefaultParams(ref int? TransactionID);
      partial void OnProcessPaymentsInvoke(ref int result);

      public async Task ExportProvincialCourtActionsReportsToExcel(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/provincialcourtactionsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/provincialcourtactionsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportProvincialCourtActionsReportsToCSV(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/provincialcourtactionsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/provincialcourtactionsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ProvincialCourtActionsReport>> GetProvincialCourtActionsReports(string StartDate, string EndDate, Query query = null)
      {
          OnProvincialCourtActionsReportsDefaultParams(ref StartDate, ref EndDate);

          var items = Context.ProvincialCourtActionsReports.FromSqlRaw("EXEC [dbo].[ProvincialCourtActionsReport] @StartDate={0}, @EndDate={1}", string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnProvincialCourtActionsReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnProvincialCourtActionsReportsDefaultParams(ref string StartDate, ref string EndDate);

      partial void OnProvincialCourtActionsReportsInvoke(ref IQueryable<Models.RecoDb.ProvincialCourtActionsReport> items);

      public async Task ExportQueensBenchActionsReportsToExcel(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/queensbenchactionsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/queensbenchactionsreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportQueensBenchActionsReportsToCSV(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/queensbenchactionsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/queensbenchactionsreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.QueensBenchActionsReport>> GetQueensBenchActionsReports(string StartDate, string EndDate, Query query = null)
      {
          OnQueensBenchActionsReportsDefaultParams(ref StartDate, ref EndDate);

          var items = Context.QueensBenchActionsReports.FromSqlRaw("EXEC [dbo].[QueensBenchActionsReport] @StartDate={0}, @EndDate={1}", string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnQueensBenchActionsReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnQueensBenchActionsReportsDefaultParams(ref string StartDate, ref string EndDate);

      partial void OnQueensBenchActionsReportsInvoke(ref IQueryable<Models.RecoDb.QueensBenchActionsReport> items);
        public async Task ExportReceiversToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/receivers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/receivers/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportReceiversToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/receivers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/receivers/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnReceiversRead(ref IQueryable<Models.RecoDb.Receiver> items);

        public async Task<IQueryable<Models.RecoDb.Receiver>> GetReceivers(Query query = null)
        {
            var items = Context.Receivers.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnReceiversRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnReceiverCreated(Models.RecoDb.Receiver item);
        partial void OnAfterReceiverCreated(Models.RecoDb.Receiver item);

        public async Task<Models.RecoDb.Receiver> CreateReceiver(Models.RecoDb.Receiver receiver)
        {
            OnReceiverCreated(receiver);

            var existingItem = Context.Receivers
                              .Where(i => i.ID == receiver.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Receivers.Add(receiver);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(receiver).State = EntityState.Detached;
                receiver.Parameter = null;
                receiver.Parameter1 = null;
                throw;
            }

            OnAfterReceiverCreated(receiver);

            return receiver;
        }

      public async Task ExportRecoLloydsBordereausToExcel(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/recolloydsbordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/recolloydsbordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportRecoLloydsBordereausToCSV(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/recolloydsbordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/recolloydsbordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.RecoLloydsBordereau>> GetRecoLloydsBordereaus(string ReportDate, Query query = null)
      {
          OnRecoLloydsBordereausDefaultParams(ref ReportDate);

          var items = Context.RecoLloydsBordereaus.FromSqlRaw("EXEC [dbo].[RECOLloydsBordereau] @ReportDate={0}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnRecoLloydsBordereausInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnRecoLloydsBordereausDefaultParams(ref string ReportDate);

      partial void OnRecoLloydsBordereausInvoke(ref IQueryable<Models.RecoDb.RecoLloydsBordereau> items);
        public async Task ExportRefactorLogsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/refactorlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/refactorlogs/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRefactorLogsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/refactorlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/refactorlogs/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRefactorLogsRead(ref IQueryable<Models.RecoDb.RefactorLog> items);

        public async Task<IQueryable<Models.RecoDb.RefactorLog>> GetRefactorLogs(Query query = null)
        {
            var items = Context.RefactorLogs.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRefactorLogsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRefactorLogCreated(Models.RecoDb.RefactorLog item);
        partial void OnAfterRefactorLogCreated(Models.RecoDb.RefactorLog item);

        public async Task<Models.RecoDb.RefactorLog> CreateRefactorLog(Models.RecoDb.RefactorLog refactorLog)
        {
            OnRefactorLogCreated(refactorLog);

            var existingItem = Context.RefactorLogs
                              .Where(i => i.OperationKey == refactorLog.OperationKey)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.RefactorLogs.Add(refactorLog);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(refactorLog).State = EntityState.Detached;
                throw;
            }

            OnAfterRefactorLogCreated(refactorLog);

            return refactorLog;
        }
        public async Task ExportRegistrantsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/registrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/registrants/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRegistrantsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/registrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/registrants/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRegistrantsRead(ref IQueryable<Models.RecoDb.Registrant> items);

        public async Task<IQueryable<Models.RecoDb.Registrant>> GetRegistrants(Query query = null)
        {
            var items = Context.Registrants.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Brokerage);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRegistrantsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRegistrantCreated(Models.RecoDb.Registrant item);
        partial void OnAfterRegistrantCreated(Models.RecoDb.Registrant item);

        public async Task<Models.RecoDb.Registrant> CreateRegistrant(Models.RecoDb.Registrant registrant)
        {
            OnRegistrantCreated(registrant);

            var existingItem = Context.Registrants
                              .Where(i => i.ID == registrant.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Registrants.Add(registrant);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(registrant).State = EntityState.Detached;
                registrant.Parameter = null;
                registrant.Parameter1 = null;
                registrant.Brokerage = null;
                throw;
            }

            OnAfterRegistrantCreated(registrant);

            return registrant;
        }
      public async Task<int> RemoveCrossReferences(int? BaseClaimID, int? XRefClaimID)
      {
          OnRemoveCrossReferencesDefaultParams(ref BaseClaimID, ref XRefClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@BaseClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = BaseClaimID},
              new SqlParameter("@XRefClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = XRefClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[RemoveCrossReference] @BaseClaimID, @XRefClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnRemoveCrossReferencesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnRemoveCrossReferencesDefaultParams(ref int? BaseClaimID, ref int? XRefClaimID);
      partial void OnRemoveCrossReferencesInvoke(ref int result);
      public async Task<int> RemoveFutureCounselDiaries(int? ClaimID)
      {
          OnRemoveFutureCounselDiariesDefaultParams(ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[RemoveFutureCounselDiaries] @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnRemoveFutureCounselDiariesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnRemoveFutureCounselDiariesDefaultParams(ref int? ClaimID);
      partial void OnRemoveFutureCounselDiariesInvoke(ref int result);
      public async Task<int> RemoveFutureDiaries(int? ClaimID)
      {
          OnRemoveFutureDiariesDefaultParams(ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[RemoveFutureDiaries] @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnRemoveFutureDiariesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnRemoveFutureDiariesDefaultParams(ref int? ClaimID);
      partial void OnRemoveFutureDiariesInvoke(ref int result);

      public async Task<int> ReorderAllClaimOrders()
      {
          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
          };

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ReorderAllClaimOrders]", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnReorderAllClaimOrdersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnReorderAllClaimOrdersInvoke(ref int result);
      public async Task<int> ReorderClaimantOrders(int? ClaimID)
      {
          OnReorderClaimantOrdersDefaultParams(ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ReorderClaimantOrder] @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnReorderClaimantOrdersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnReorderClaimantOrdersDefaultParams(ref int? ClaimID);
      partial void OnReorderClaimantOrdersInvoke(ref int result);
      public async Task<int> ReorderExpertOrders(int? ClaimID)
      {
          OnReorderExpertOrdersDefaultParams(ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ReorderExpertOrder] @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnReorderExpertOrdersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnReorderExpertOrdersDefaultParams(ref int? ClaimID);
      partial void OnReorderExpertOrdersInvoke(ref int result);
      public async Task<int> ReorderInsuredOrders(int? ClaimID)
      {
          OnReorderInsuredOrdersDefaultParams(ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ReorderInsuredOrder] @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnReorderInsuredOrdersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnReorderInsuredOrdersDefaultParams(ref int? ClaimID);
      partial void OnReorderInsuredOrdersInvoke(ref int result);
      public async Task<int> ReorderOtherPartiesOrders(int? ClaimID)
      {
          OnReorderOtherPartiesOrdersDefaultParams(ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ReorderOtherPartiesOrder] @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnReorderOtherPartiesOrdersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnReorderOtherPartiesOrdersDefaultParams(ref int? ClaimID);
      partial void OnReorderOtherPartiesOrdersInvoke(ref int result);
      public async Task<int> ReorderTradesOrders(int? ClaimID)
      {
          OnReorderTradesOrdersDefaultParams(ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[ReorderTradesOrder] @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnReorderTradesOrdersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnReorderTradesOrdersDefaultParams(ref int? ClaimID);
      partial void OnReorderTradesOrdersInvoke(ref int result);

      public async Task ExportReserveChangeHistoriesToExcel(string StartDate, string EndDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/reservechangehistories/excel(StartDate='{StartDate}', EndDate='{EndDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/reservechangehistories/excel(StartDate='{StartDate}', EndDate='{EndDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportReserveChangeHistoriesToCSV(string StartDate, string EndDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/reservechangehistories/csv(StartDate='{StartDate}', EndDate='{EndDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/reservechangehistories/csv(StartDate='{StartDate}', EndDate='{EndDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ReserveChangeHistoryModel>> GetReserveChangeHistories(string StartDate, string EndDate, int? ProgramID, Query query = null)
      {
          OnReserveChangeHistoriesDefaultParams(ref StartDate, ref EndDate, ref ProgramID);

          var items = Context.ReserveChangeHistories.FromSqlRaw("EXEC [dbo].[ReserveChangeHistory] @StartDate={0}, @EndDate={1}, @ProgramID={2}", string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnReserveChangeHistoriesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnReserveChangeHistoriesDefaultParams(ref string StartDate, ref string EndDate, ref int? ProgramID);

      partial void OnReserveChangeHistoriesInvoke(ref IQueryable<Models.RecoDb.ReserveChangeHistoryModel> items);
        public async Task ExportRolesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/roles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/roles/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportRolesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/roles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/roles/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnRolesRead(ref IQueryable<Models.RecoDb.Role> items);

        public async Task<IQueryable<Models.RecoDb.Role>> GetRoles(Query query = null)
        {
            var items = Context.Roles.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnRolesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnRoleCreated(Models.RecoDb.Role item);
        partial void OnAfterRoleCreated(Models.RecoDb.Role item);

        public async Task<Models.RecoDb.Role> CreateRole(Models.RecoDb.Role role)
        {
            OnRoleCreated(role);

            var existingItem = Context.Roles
                              .Where(i => i.Id == role.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Roles.Add(role);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(role).State = EntityState.Detached;
                throw;
            }

            OnAfterRoleCreated(role);

            return role;
        }

      public async Task ExportSalesClassificationBreakdownByPolicyYearAndTradeTypesToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/salesclassificationbreakdownbypolicyyearandtradetypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/salesclassificationbreakdownbypolicyyearandtradetypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportSalesClassificationBreakdownByPolicyYearAndTradeTypesToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/salesclassificationbreakdownbypolicyyearandtradetypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/salesclassificationbreakdownbypolicyyearandtradetypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.SalesClassificationBreakdownByPolicyYearAndTradeType>> GetSalesClassificationBreakdownByPolicyYearAndTradeTypes(string ReportDate, int? ProgramID, Query query = null)
      {
          OnSalesClassificationBreakdownByPolicyYearAndTradeTypesDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.SalesClassificationBreakdownByPolicyYearAndTradeTypes.FromSqlRaw("EXEC [dbo].[SalesClassificationBreakdownByPolicyYearAndTradeType] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnSalesClassificationBreakdownByPolicyYearAndTradeTypesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnSalesClassificationBreakdownByPolicyYearAndTradeTypesDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnSalesClassificationBreakdownByPolicyYearAndTradeTypesInvoke(ref IQueryable<Models.RecoDb.SalesClassificationBreakdownByPolicyYearAndTradeType> items);

      public async Task ExportSalesClassificationBreakdownByTradeTypesToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/salesclassificationbreakdownbytradetypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/salesclassificationbreakdownbytradetypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportSalesClassificationBreakdownByTradeTypesToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/salesclassificationbreakdownbytradetypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/salesclassificationbreakdownbytradetypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.SalesClassificationBreakdownByTradeType>> GetSalesClassificationBreakdownByTradeTypes(string ReportDate, int? ProgramID, Query query = null)
      {
          OnSalesClassificationBreakdownByTradeTypesDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.SalesClassificationBreakdownByTradeTypes.FromSqlRaw("EXEC [dbo].[SalesClassificationBreakdownByTradeType] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnSalesClassificationBreakdownByTradeTypesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnSalesClassificationBreakdownByTradeTypesDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnSalesClassificationBreakdownByTradeTypesInvoke(ref IQueryable<Models.RecoDb.SalesClassificationBreakdownByTradeType> items);
        public async Task ExportSentLettersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/sentletters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/sentletters/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSentLettersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/sentletters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/sentletters/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSentLettersRead(ref IQueryable<Models.RecoDb.SentLetter> items);

        public async Task<IQueryable<Models.RecoDb.SentLetter>> GetSentLetters(Query query = null)
        {
            var items = Context.SentLetters.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSentLettersRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSentLetterCreated(Models.RecoDb.SentLetter item);
        partial void OnAfterSentLetterCreated(Models.RecoDb.SentLetter item);

        public async Task<Models.RecoDb.SentLetter> CreateSentLetter(Models.RecoDb.SentLetter sentLetter)
        {
            OnSentLetterCreated(sentLetter);

            var existingItem = Context.SentLetters
                              .Where(i => i.ClaimID == sentLetter.ClaimID && i.DateLetterSent == sentLetter.DateLetterSent && i.LetterTypeID == sentLetter.LetterTypeID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SentLetters.Add(sentLetter);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(sentLetter).State = EntityState.Detached;
                sentLetter.Claim = null;
                sentLetter.Parameter = null;
                throw;
            }

            OnAfterSentLetterCreated(sentLetter);

            return sentLetter;
        }
        public async Task ExportServiceProvidersToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/serviceproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/serviceproviders/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportServiceProvidersToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/serviceproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/serviceproviders/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnServiceProvidersRead(ref IQueryable<Models.RecoDb.ServiceProvider> items);

        public async Task<IQueryable<Models.RecoDb.ServiceProvider>> GetServiceProviders(Query query = null)
        {
            var items = Context.ServiceProviders.AsQueryable();

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Firm);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.AsLegalAssistant);

            items = items.Include(i => i.AsDefenseCounsel);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnServiceProvidersRead(ref items);

            return await Task.FromResult(items);
        }

        public async Task<IQueryable<Models.RecoDb.LegalAssistants>> GetDefenseCounselsForLegalAssistance(int id)
        {
            var items = Context.LegalAssistants.AsNoTracking()
                              .Include(e => e.DefenseCounsel)
                              .Where(i => i.LegalAssistantID == id);

            return await Task.FromResult(items);
        }

        partial void OnServiceProviderCreated(Models.RecoDb.ServiceProvider item);
        partial void OnAfterServiceProviderCreated(Models.RecoDb.ServiceProvider item);

        public async Task<Models.RecoDb.ServiceProvider> CreateServiceProvider(Models.RecoDb.ServiceProvider serviceProvider)
        {
            OnServiceProviderCreated(serviceProvider);

            var existingItem = Context.ServiceProviders
                              .Where(i => i.ID == serviceProvider.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ServiceProviders.Add(serviceProvider);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(serviceProvider).State = EntityState.Detached;
                serviceProvider.Parameter = null;
                serviceProvider.Parameter1 = null;
                serviceProvider.Firm = null;
                serviceProvider.Parameter2 = null;
                throw;
            }

            OnAfterServiceProviderCreated(serviceProvider);

            return serviceProvider;
        }

      public async Task ExportServiceProviderBordereausToExcel(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/serviceproviderbordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/serviceproviderbordereaus/excel(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportServiceProviderBordereausToCSV(string ReportDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/serviceproviderbordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/serviceproviderbordereaus/csv(ReportDate='{ReportDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.ServiceProviderBordereau>> GetServiceProviderBordereaus(string ReportDate, Query query = null)
      {
          OnServiceProviderBordereausDefaultParams(ref ReportDate);

          var items = Context.ServiceProviderBordereaus.FromSqlRaw("EXEC [dbo].[ServiceProviderBordereau] @ReportDate={0}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnServiceProviderBordereausInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnServiceProviderBordereausDefaultParams(ref string ReportDate);

      partial void OnServiceProviderBordereausInvoke(ref IQueryable<Models.RecoDb.ServiceProviderBordereau> items);
        public async Task ExportServiceProviderClaimPreferencesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/serviceproviderclaimpreferences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/serviceproviderclaimpreferences/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportServiceProviderClaimPreferencesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/serviceproviderclaimpreferences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/serviceproviderclaimpreferences/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnServiceProviderClaimPreferencesRead(ref IQueryable<Models.RecoDb.ServiceProviderClaimPreference> items);

        public async Task<IQueryable<Models.RecoDb.ServiceProviderClaimPreference>> GetServiceProviderClaimPreferences(Query query = null)
        {
            var items = Context.ServiceProviderClaimPreferences.AsQueryable();

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Claim);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnServiceProviderClaimPreferencesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnServiceProviderClaimPreferenceCreated(Models.RecoDb.ServiceProviderClaimPreference item);
        partial void OnAfterServiceProviderClaimPreferenceCreated(Models.RecoDb.ServiceProviderClaimPreference item);

        public async Task<Models.RecoDb.ServiceProviderClaimPreference> CreateServiceProviderClaimPreference(Models.RecoDb.ServiceProviderClaimPreference serviceProviderClaimPreference)
        {
            OnServiceProviderClaimPreferenceCreated(serviceProviderClaimPreference);

            var existingItem = Context.ServiceProviderClaimPreferences
                              .Where(i => i.ServiceProviderID == serviceProviderClaimPreference.ServiceProviderID && i.ClaimID == serviceProviderClaimPreference.ClaimID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.ServiceProviderClaimPreferences.Add(serviceProviderClaimPreference);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(serviceProviderClaimPreference).State = EntityState.Detached;
                serviceProviderClaimPreference.ServiceProvider = null;
                serviceProviderClaimPreference.Claim = null;
                throw;
            }

            OnAfterServiceProviderClaimPreferenceCreated(serviceProviderClaimPreference);

            return serviceProviderClaimPreference;
        }
        public async Task ExportServiceProviderDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/serviceproviderdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/serviceproviderdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportServiceProviderDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/serviceproviderdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/serviceproviderdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnServiceProviderDetailsRead(ref IQueryable<Models.RecoDb.ServiceProviderDetail> items);

        public async Task<IQueryable<Models.RecoDb.ServiceProviderDetail>> GetServiceProviderDetails(Query query = null)
        {
            var items = Context.ServiceProviderDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnServiceProviderDetailsRead(ref items);

            return await Task.FromResult(items);
        }
      public async Task<int> SetAutoReserves(int? ClaimID, string UserID)
      {
          OnSetAutoReservesDefaultParams(ref ClaimID, ref UserID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[SetAutoReserve] @ClaimID, @UserID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSetAutoReservesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSetAutoReservesDefaultParams(ref int? ClaimID, ref string UserID);
      partial void OnSetAutoReservesInvoke(ref int result);
      public async Task<int> SetAutoResizes(int? ClaimID, string UserID)
      {
          OnSetAutoResizesDefaultParams(ref ClaimID, ref UserID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[SetAutoResize] @ClaimID, @UserID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSetAutoResizesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSetAutoResizesDefaultParams(ref int? ClaimID, ref string UserID);
      partial void OnSetAutoResizesInvoke(ref int result);
      public async Task<int> SetCppAutoReserves(int? ClaimID, string UserID)
      {
          OnSetCppAutoReservesDefaultParams(ref ClaimID, ref UserID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[SetCPPAutoReserve] @ClaimID, @UserID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSetCppAutoReservesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSetCppAutoReservesDefaultParams(ref int? ClaimID, ref string UserID);
      partial void OnSetCppAutoReservesInvoke(ref int result);
      public async Task<int> SetProgramManagerAsReports(int? ClaimID)
      {
          OnSetProgramManagerAsReportsDefaultParams(ref ClaimID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[SetProgramManagerAsReport] @ClaimID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSetProgramManagerAsReportsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSetProgramManagerAsReportsDefaultParams(ref int? ClaimID);
      partial void OnSetProgramManagerAsReportsInvoke(ref int result);
      public async Task<int> SpMSforeachWorkers(string command1, string replacechar, string command2, string command3, int? worker_type)
      {
          OnSpMSforeachWorkersDefaultParams(ref command1, ref replacechar, ref command2, ref command3, ref worker_type);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@command1", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = command1},
              new SqlParameter("@replacechar", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = replacechar},
              new SqlParameter("@command2", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = command2},
              new SqlParameter("@command3", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = command3},
              new SqlParameter("@worker_type", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = worker_type},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_MSforeach_worker] @command1, @replacechar, @command2, @command3, @worker_type", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSpMSforeachWorkersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpMSforeachWorkersDefaultParams(ref string command1, ref string replacechar, ref string command2, ref string command3, ref int? worker_type);
      partial void OnSpMSforeachWorkersInvoke(ref int result);
      public async Task<int> SpMSforeachtables(string command1, string replacechar, string command2, string command3, string whereand, string precommand, string postcommand)
      {
          OnSpMSforeachtablesDefaultParams(ref command1, ref replacechar, ref command2, ref command3, ref whereand, ref precommand, ref postcommand);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@command1", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = command1},
              new SqlParameter("@replacechar", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = replacechar},
              new SqlParameter("@command2", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = command2},
              new SqlParameter("@command3", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = command3},
              new SqlParameter("@whereand", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = whereand},
              new SqlParameter("@precommand", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = precommand},
              new SqlParameter("@postcommand", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = postcommand},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[sp_MSforeachtable] @command1, @replacechar, @command2, @command3, @whereand, @precommand, @postcommand", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnSpMSforeachtablesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnSpMSforeachtablesDefaultParams(ref string command1, ref string replacechar, ref string command2, ref string command3, ref string whereand, ref string precommand, ref string postcommand);
      partial void OnSpMSforeachtablesInvoke(ref int result);
        public async Task ExportStandardEmailAddressesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/standardemailaddresses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/standardemailaddresses/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportStandardEmailAddressesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/standardemailaddresses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/standardemailaddresses/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnStandardEmailAddressesRead(ref IQueryable<Models.RecoDb.StandardEmailAddress> items);

        public async Task<IQueryable<Models.RecoDb.StandardEmailAddress>> GetStandardEmailAddresses(Query query = null)
        {
            var items = Context.StandardEmailAddresses.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnStandardEmailAddressesRead(ref items);

            return await Task.FromResult(items);
        }
      public async Task<int> StoreClaimAuditTrails(int? ClaimID, string UserID)
      {
          OnStoreClaimAuditTrailsDefaultParams(ref ClaimID, ref UserID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[StoreClaimAuditTrail] @ClaimID, @UserID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnStoreClaimAuditTrailsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnStoreClaimAuditTrailsDefaultParams(ref int? ClaimID, ref string UserID);
      partial void OnStoreClaimAuditTrailsInvoke(ref int result);
        public async Task ExportSystemNoticesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/systemnotices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/systemnotices/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSystemNoticesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/systemnotices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/systemnotices/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSystemNoticesRead(ref IQueryable<Models.RecoDb.SystemNotice> items);

        public async Task<IQueryable<Models.RecoDb.SystemNotice>> GetSystemNotices(Query query = null)
        {
            var items = Context.SystemNotices.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSystemNoticesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSystemNoticeCreated(Models.RecoDb.SystemNotice item);
        partial void OnAfterSystemNoticeCreated(Models.RecoDb.SystemNotice item);

        public async Task<Models.RecoDb.SystemNotice> CreateSystemNotice(Models.RecoDb.SystemNotice systemNotice)
        {
            OnSystemNoticeCreated(systemNotice);

            var existingItem = Context.SystemNotices
                              .Where(i => i.SystemNoticeID == systemNotice.SystemNoticeID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SystemNotices.Add(systemNotice);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(systemNotice).State = EntityState.Detached;
                throw;
            }

            OnAfterSystemNoticeCreated(systemNotice);

            return systemNotice;
        }
        public async Task ExportSystemNoticeReadsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/systemnoticereads/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/systemnoticereads/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSystemNoticeReadsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/systemnoticereads/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/systemnoticereads/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSystemNoticeReadsRead(ref IQueryable<Models.RecoDb.SystemNoticeRead> items);

        public async Task<IQueryable<Models.RecoDb.SystemNoticeRead>> GetSystemNoticeReads(Query query = null)
        {
            var items = Context.SystemNoticeReads.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSystemNoticeReadsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSystemNoticeReadCreated(Models.RecoDb.SystemNoticeRead item);
        partial void OnAfterSystemNoticeReadCreated(Models.RecoDb.SystemNoticeRead item);

        public async Task<Models.RecoDb.SystemNoticeRead> CreateSystemNoticeRead(Models.RecoDb.SystemNoticeRead systemNoticeRead)
        {
            OnSystemNoticeReadCreated(systemNoticeRead);

            var existingItem = Context.SystemNoticeReads
                              .Where(i => i.UserID == systemNoticeRead.UserID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SystemNoticeReads.Add(systemNoticeRead);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(systemNoticeRead).State = EntityState.Detached;
                throw;
            }

            OnAfterSystemNoticeReadCreated(systemNoticeRead);

            return systemNoticeRead;
        }
        public async Task ExportSystemTemplatesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/systemtemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/systemtemplates/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportSystemTemplatesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/systemtemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/systemtemplates/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnSystemTemplatesRead(ref IQueryable<Models.RecoDb.SystemTemplate> items);

        public async Task<IQueryable<Models.RecoDb.SystemTemplate>> GetSystemTemplates(Query query = null)
        {
            var items = Context.SystemTemplates.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnSystemTemplatesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnSystemTemplateCreated(Models.RecoDb.SystemTemplate item);
        partial void OnAfterSystemTemplateCreated(Models.RecoDb.SystemTemplate item);

        public async Task<Models.RecoDb.SystemTemplate> CreateSystemTemplate(Models.RecoDb.SystemTemplate systemTemplate)
        {
            OnSystemTemplateCreated(systemTemplate);

            var existingItem = Context.SystemTemplates
                              .Where(i => i.TemplateID == systemTemplate.TemplateID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.SystemTemplates.Add(systemTemplate);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(systemTemplate).State = EntityState.Detached;
                throw;
            }

            OnAfterSystemTemplateCreated(systemTemplate);

            return systemTemplate;
        }
        public async Task ExportTemplateDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/templatedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/templatedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTemplateDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/templatedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/templatedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTemplateDetailsRead(ref IQueryable<Models.RecoDb.TemplateDetail> items);

        public async Task<IQueryable<Models.RecoDb.TemplateDetail>> GetTemplateDetails(Query query = null)
        {
            var items = Context.TemplateDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTemplateDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportTokenCachesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/tokencaches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/tokencaches/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTokenCachesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/tokencaches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/tokencaches/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTokenCachesRead(ref IQueryable<Models.RecoDb.TokenCache> items);

        public async Task<IQueryable<Models.RecoDb.TokenCache>> GetTokenCaches(Query query = null)
        {
            var items = Context.TokenCaches.AsQueryable();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTokenCachesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTokenCacheCreated(Models.RecoDb.TokenCache item);
        partial void OnAfterTokenCacheCreated(Models.RecoDb.TokenCache item);

        public async Task<Models.RecoDb.TokenCache> CreateTokenCache(Models.RecoDb.TokenCache tokenCache)
        {
            OnTokenCacheCreated(tokenCache);

            var existingItem = Context.TokenCaches
                              .Where(i => i.Id == tokenCache.Id)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TokenCaches.Add(tokenCache);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(tokenCache).State = EntityState.Detached;
                throw;
            }

            OnAfterTokenCacheCreated(tokenCache);

            return tokenCache;
        }

      public async Task ExportTotalClaimsByAllegationAndLossCausesToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbyallegationandlosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbyallegationandlosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalClaimsByAllegationAndLossCausesToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbyallegationandlosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbyallegationandlosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalClaimsByAllegationAndLossCause>> GetTotalClaimsByAllegationAndLossCauses(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalClaimsByAllegationAndLossCausesDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalClaimsByAllegationAndLossCauses.FromSqlRaw("EXEC [dbo].[TotalClaimsByAllegationAndLossCause] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalClaimsByAllegationAndLossCausesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalClaimsByAllegationAndLossCausesDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalClaimsByAllegationAndLossCausesInvoke(ref IQueryable<Models.RecoDb.TotalClaimsByAllegationAndLossCause> items);

      public async Task ExportTotalClaimsByBoardJuridictionsToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbyboardjuridictions/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbyboardjuridictions/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalClaimsByBoardJuridictionsToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbyboardjuridictions/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbyboardjuridictions/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalClaimsByBoardJuridiction>> GetTotalClaimsByBoardJuridictions(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalClaimsByBoardJuridictionsDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalClaimsByBoardJuridictions.FromSqlRaw("EXEC [dbo].[TotalClaimsByBoardJuridiction] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalClaimsByBoardJuridictionsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalClaimsByBoardJuridictionsDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalClaimsByBoardJuridictionsInvoke(ref IQueryable<Models.RecoDb.TotalClaimsByBoardJuridiction> items);

      public async Task ExportTotalClaimsByClaimTypeAndLossCausesToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbyclaimtypeandlosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbyclaimtypeandlosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalClaimsByClaimTypeAndLossCausesToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbyclaimtypeandlosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbyclaimtypeandlosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalClaimsByClaimTypeAndLossCause>> GetTotalClaimsByClaimTypeAndLossCauses(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalClaimsByClaimTypeAndLossCausesDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalClaimsByClaimTypeAndLossCauses.FromSqlRaw("EXEC [dbo].[TotalClaimsByClaimTypeAndLossCause] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalClaimsByClaimTypeAndLossCausesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalClaimsByClaimTypeAndLossCausesDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalClaimsByClaimTypeAndLossCausesInvoke(ref IQueryable<Models.RecoDb.TotalClaimsByClaimTypeAndLossCause> items);

      public async Task ExportTotalClaimsByLitigationTypesToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbylitigationtypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbylitigationtypes/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalClaimsByLitigationTypesToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbylitigationtypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbylitigationtypes/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalClaimsByLitigationType>> GetTotalClaimsByLitigationTypes(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalClaimsByLitigationTypesDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalClaimsByLitigationTypes.FromSqlRaw("EXEC [dbo].[TotalClaimsByLitigationType] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalClaimsByLitigationTypesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalClaimsByLitigationTypesDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalClaimsByLitigationTypesInvoke(ref IQueryable<Models.RecoDb.TotalClaimsByLitigationType> items);

      public async Task ExportTotalClaimsbyAllegationsToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbyallegations/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbyallegations/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalClaimsbyAllegationsToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclaimsbyallegations/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclaimsbyallegations/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalClaimsbyAllegation>> GetTotalClaimsbyAllegations(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalClaimsbyAllegationsDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalClaimsbyAllegations.FromSqlRaw("EXEC [dbo].[TotalClaimsbyAllegations] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalClaimsbyAllegationsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalClaimsbyAllegationsDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalClaimsbyAllegationsInvoke(ref IQueryable<Models.RecoDb.TotalClaimsbyAllegation> items);

      public async Task ExportTotalClosedClaimsWithIndemnityPaidsToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclosedclaimswithindemnitypaids/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclosedclaimswithindemnitypaids/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalClosedClaimsWithIndemnityPaidsToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalclosedclaimswithindemnitypaids/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalclosedclaimswithindemnitypaids/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalClosedClaimsWithIndemnityPaid>> GetTotalClosedClaimsWithIndemnityPaids(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalClosedClaimsWithIndemnityPaidsDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalClosedClaimsWithIndemnityPaids.FromSqlRaw("EXEC [dbo].[TotalClosedClaimsWithIndemnityPaid] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalClosedClaimsWithIndemnityPaidsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalClosedClaimsWithIndemnityPaidsDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalClosedClaimsWithIndemnityPaidsInvoke(ref IQueryable<Models.RecoDb.TotalClosedClaimsWithIndemnityPaid> items);

      public async Task ExportTotalDollarsPaidByLossCausesToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totaldollarspaidbylosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totaldollarspaidbylosscauses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalDollarsPaidByLossCausesToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totaldollarspaidbylosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totaldollarspaidbylosscauses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalDollarsPaidByLossCause>> GetTotalDollarsPaidByLossCauses(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalDollarsPaidByLossCausesDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalDollarsPaidByLossCauses.FromSqlRaw("EXEC [dbo].[TotalDollarsPaidByLossCause] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalDollarsPaidByLossCausesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalDollarsPaidByLossCausesDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalDollarsPaidByLossCausesInvoke(ref IQueryable<Models.RecoDb.TotalDollarsPaidByLossCause> items);

      public async Task ExportTotalIncurredLossesByPolicyYearsToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalincurredlossesbypolicyyears/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalincurredlossesbypolicyyears/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalIncurredLossesByPolicyYearsToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalincurredlossesbypolicyyears/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalincurredlossesbypolicyyears/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalIncurredLossesByPolicyYear>> GetTotalIncurredLossesByPolicyYears(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalIncurredLossesByPolicyYearsDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalIncurredLossesByPolicyYears.FromSqlRaw("EXEC [dbo].[TotalIncurredLossesByPolicyYear] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalIncurredLossesByPolicyYearsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalIncurredLossesByPolicyYearsDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalIncurredLossesByPolicyYearsInvoke(ref IQueryable<Models.RecoDb.TotalIncurredLossesByPolicyYear> items);

      public async Task ExportTotalPaidByClaimStatusesToExcel(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalpaidbyclaimstatuses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalpaidbyclaimstatuses/excel(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTotalPaidByClaimStatusesToCSV(string ReportDate, int? ProgramID, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/totalpaidbyclaimstatuses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/totalpaidbyclaimstatuses/csv(ReportDate='{ReportDate}', ProgramID={ProgramID}, fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TotalPaidByClaimStatus>> GetTotalPaidByClaimStatuses(string ReportDate, int? ProgramID, Query query = null)
      {
          OnTotalPaidByClaimStatusesDefaultParams(ref ReportDate, ref ProgramID);

          var items = Context.TotalPaidByClaimStatuses.FromSqlRaw("EXEC [dbo].[TotalPaidByClaimStatus] @ReportDate={0}, @ProgramID={1}", string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind), ProgramID).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTotalPaidByClaimStatusesInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTotalPaidByClaimStatusesDefaultParams(ref string ReportDate, ref int? ProgramID);

      partial void OnTotalPaidByClaimStatusesInvoke(ref IQueryable<Models.RecoDb.TotalPaidByClaimStatus> items);
        public async Task ExportTradesToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/trades/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/trades/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTradesToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/trades/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/trades/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTradesRead(ref IQueryable<Models.RecoDb.Trade> items);

        public async Task<IQueryable<Models.RecoDb.Trade>> GetTrades(Query query = null)
        {
            var items = Context.Trades.AsQueryable().AsNoTracking();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.Parameter3);

            items = items.Include(i => i.Parameter4);

            items = items.Include(i => i.Parameter5);

            items = items.Include(i => i.Builder);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter6);

            items = items.Include(i => i.Parameter7);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTradesRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTradeCreated(Models.RecoDb.Trade item);
        partial void OnAfterTradeCreated(Models.RecoDb.Trade item);

        public async Task<Models.RecoDb.Trade> CreateTrade(Models.RecoDb.Trade trade)
        {
            OnTradeCreated(trade);

            var existingItem = Context.Trades
                              .Where(i => i.TradeID == trade.TradeID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Trades.Add(trade);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(trade).State = EntityState.Detached;
                trade.Claim = null;
                trade.Parameter = null;
                trade.Parameter1 = null;
                trade.Parameter2 = null;
                trade.Parameter3 = null;
                trade.Parameter4 = null;
                trade.Parameter5 = null;
                trade.Builder = null;
                trade.Registrant = null;
                trade.Parameter6 = null;
                trade.Parameter7 = null;
                throw;
            }

            OnAfterTradeCreated(trade);

            return trade;
        }
        public async Task ExportTradeDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/tradedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/tradedetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTradeDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/tradedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/tradedetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTradeDetailsRead(ref IQueryable<Models.RecoDb.TradeDetail> items);

        public async Task<IQueryable<Models.RecoDb.TradeDetail>> GetTradeDetails(Query query = null)
        {
            var items = Context.TradeDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTradeDetailsRead(ref items);

            return await Task.FromResult(items);
        }
        public async Task ExportTransactionsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/transactions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/transactions/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransactionsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/transactions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/transactions/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransactionsRead(ref IQueryable<Models.RecoDb.Transaction> items);

        public async Task<IQueryable<Models.RecoDb.Transaction>> GetTransactions(Query query = null)
        {
            var items = Context.Transactions.AsQueryable();

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Transaction1);

            items = items.Include(i => i.Firm);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Parameter2);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTransactionsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransactionCreated(Models.RecoDb.Transaction item);
        partial void OnAfterTransactionCreated(Models.RecoDb.Transaction item);

        public async Task<Models.RecoDb.Transaction> CreateTransaction(Models.RecoDb.Transaction transaction)
        {
            OnTransactionCreated(transaction);

            var existingItem = Context.Transactions
                              .Where(i => i.ID == transaction.ID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.Transactions.Add(transaction);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transaction).State = EntityState.Detached;
                transaction.Claim = null;
                transaction.Parameter = null;
                transaction.Parameter1 = null;
                transaction.Transaction1 = null;
                transaction.Firm = null;
                transaction.ServiceProvider = null;
                transaction.Parameter2 = null;
                throw;
            }

            OnAfterTransactionCreated(transaction);

            return transaction;
        }
        public async Task ExportTransactionApprovalLimitsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/transactionapprovallimits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/transactionapprovallimits/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportTransactionApprovalLimitsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/transactionapprovallimits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/transactionapprovallimits/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnTransactionApprovalLimitsRead(ref IQueryable<Models.RecoDb.TransactionApprovalLimit> items);

        public async Task<IQueryable<Models.RecoDb.TransactionApprovalLimit>> GetTransactionApprovalLimits(Query query = null)
        {
            var items = Context.TransactionApprovalLimits.AsQueryable();

            items = items.Include(i => i.TransactionApprovalLimit1);

            items = items.Include(i => i.Parameter);

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnTransactionApprovalLimitsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnTransactionApprovalLimitCreated(Models.RecoDb.TransactionApprovalLimit item);
        partial void OnAfterTransactionApprovalLimitCreated(Models.RecoDb.TransactionApprovalLimit item);

        public async Task<Models.RecoDb.TransactionApprovalLimit> CreateTransactionApprovalLimit(Models.RecoDb.TransactionApprovalLimit transactionApprovalLimit)
        {
            OnTransactionApprovalLimitCreated(transactionApprovalLimit);

            var existingItem = Context.TransactionApprovalLimits
                              .Where(i => i.ApprovalLimitID == transactionApprovalLimit.ApprovalLimitID)
                              .FirstOrDefault();

            if (existingItem != null)
            {
               throw new Exception("Item already available");
            }            

            try
            {
                Context.TransactionApprovalLimits.Add(transactionApprovalLimit);
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(transactionApprovalLimit).State = EntityState.Detached;
                transactionApprovalLimit.TransactionApprovalLimit1 = null;
                transactionApprovalLimit.Parameter = null;
                throw;
            }

            OnAfterTransactionApprovalLimitCreated(transactionApprovalLimit);

            return transactionApprovalLimit;
        }

      public async Task ExportTransactionListReportsToExcel(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/transactionlistreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/transactionlistreports/excel(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportTransactionListReportsToCSV(string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/transactionlistreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/transactionlistreports/csv(StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.TransactionListReport>> GetTransactionListReports(string StartDate, string EndDate, Query query = null)
      {
          OnTransactionListReportsDefaultParams(ref StartDate, ref EndDate);

          var items = Context.TransactionListReports.FromSqlRaw("EXEC [dbo].[TransactionListReport] @StartDate={0}, @EndDate={1}", string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnTransactionListReportsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnTransactionListReportsDefaultParams(ref string StartDate, ref string EndDate);

      partial void OnTransactionListReportsInvoke(ref IQueryable<Models.RecoDb.TransactionListReport> items);
      public async Task<int> UpdateCounselClaimNums(int? ClaimID, string CounselFileNo)
      {
          OnUpdateCounselClaimNumsDefaultParams(ref ClaimID, ref CounselFileNo);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ClaimID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = ClaimID},
              new SqlParameter("@CounselFileNo", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = CounselFileNo},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[UpdateCounselClaimNum] @ClaimID, @CounselFileNo", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnUpdateCounselClaimNumsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUpdateCounselClaimNumsDefaultParams(ref int? ClaimID, ref string CounselFileNo);
      partial void OnUpdateCounselClaimNumsInvoke(ref int result);
      public async Task<int> UpdateFileDetails(int? FileID, string Subject, string Filename, bool? LargeLoss, bool? Sticky, bool? Confidential, bool? VisibleToCounsel, int? FileTypeID, string Comments, string Description)
      {
          OnUpdateFileDetailsDefaultParams(ref FileID, ref Subject, ref Filename, ref LargeLoss, ref Sticky, ref Confidential, ref VisibleToCounsel, ref FileTypeID, ref Comments, ref Description);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@FileID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = FileID},
              new SqlParameter("@Subject", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = Subject},
              new SqlParameter("@Filename", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = Filename},
              new SqlParameter("@LargeLoss", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = LargeLoss},
              new SqlParameter("@Sticky", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = Sticky},
              new SqlParameter("@Confidential", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = Confidential},
              new SqlParameter("@VisibleToCounsel", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = VisibleToCounsel},
              new SqlParameter("@FileTypeID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = FileTypeID},
              new SqlParameter("@Comments", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = Comments},
              new SqlParameter("@Description", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = Description},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[UpdateFileDetails] @FileID, @Subject, @Filename, @LargeLoss, @Sticky, @Confidential, @VisibleToCounsel, @FileTypeID, @Comments, @Description", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnUpdateFileDetailsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUpdateFileDetailsDefaultParams(ref int? FileID, ref string Subject, ref string Filename, ref bool? LargeLoss, ref bool? Sticky, ref bool? Confidential, ref bool? VisibleToCounsel, ref int? FileTypeID, ref string Comments, ref string Description);
      partial void OnUpdateFileDetailsInvoke(ref int result);
      public async Task<int> UpdateJournalEntryNumbers(int? TransactionID, string UserID)
      {
          OnUpdateJournalEntryNumbersDefaultParams(ref TransactionID, ref UserID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@TransactionID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = TransactionID},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[UpdateJournalEntryNumber] @TransactionID, @UserID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnUpdateJournalEntryNumbersInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUpdateJournalEntryNumbersDefaultParams(ref int? TransactionID, ref string UserID);
      partial void OnUpdateJournalEntryNumbersInvoke(ref int result);
      public async Task<int> UpdateReportDates(string ReportDate, string UserID, string StartDate, string ReportJson)
      {
          OnUpdateReportDatesDefaultParams(ref ReportDate, ref UserID, ref StartDate, ref ReportJson);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@ReportDate", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value =  string.IsNullOrEmpty(ReportDate) ? DBNull.Value : (object)DateTime.Parse(ReportDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
              new SqlParameter("@UserID", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = UserID},
              new SqlParameter("@ReportJson", SqlDbType.NVarChar) {Direction = ParameterDirection.Input, Value = ReportJson},
              new SqlParameter("@StartDate", SqlDbType.DateTime) {Direction = ParameterDirection.Input, Value =  string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind)},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[UpdateReportDate] @ReportDate, @UserID, @ReportJson, @StartDate", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnUpdateReportDatesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUpdateReportDatesDefaultParams(ref string ReportDate, ref string UserID, ref string StartDate, ref string ReportJson);
      partial void OnUpdateReportDatesInvoke(ref int result);
      public async Task<int> UpdateUploadedFiles(int? FileID, string Subject, bool? LargeLoss, bool? Sticky, int? FileTypeID, bool? Confidential, string FileDescription, bool? VisibleToCounsel)
      {
          OnUpdateUploadedFilesDefaultParams(ref FileID, ref Subject, ref LargeLoss, ref Sticky, ref FileTypeID, ref Confidential, ref FileDescription, ref VisibleToCounsel);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@FileID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = FileID},
              new SqlParameter("@Subject", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = Subject},
              new SqlParameter("@LargeLoss", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = LargeLoss},
              new SqlParameter("@Sticky", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = Sticky},
              new SqlParameter("@FileTypeID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = FileTypeID},
              new SqlParameter("@Confidential", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = Confidential},
              new SqlParameter("@FileDescription", SqlDbType.VarChar) {Direction = ParameterDirection.Input, Value = FileDescription},
              new SqlParameter("@VisibleToCounsel", SqlDbType.Bit) {Direction = ParameterDirection.Input, Value = VisibleToCounsel},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[UpdateUploadedFile] @FileID, @Subject, @LargeLoss, @Sticky, @FileTypeID, @Confidential, @FileDescription, @VisibleToCounsel", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnUpdateUploadedFilesInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnUpdateUploadedFilesDefaultParams(ref int? FileID, ref string Subject, ref bool? LargeLoss, ref bool? Sticky, ref int? FileTypeID, ref bool? Confidential, ref string FileDescription, ref bool? VisibleToCounsel);
      partial void OnUpdateUploadedFilesInvoke(ref int result);
        public async Task ExportUserDetailsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/userdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/userdetails/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportUserDetailsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/userdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/userdetails/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnUserDetailsRead(ref IQueryable<Models.RecoDb.UserDetail> items);

        public async Task<IQueryable<Models.RecoDb.UserDetail>> GetUserDetails(Query query = null)
        {
            var items = Context.UserDetails.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnUserDetailsRead(ref items);

            return await Task.FromResult(items);
        }

      public async Task ExportVoidPaymentsToExcel(int? ProgramID, string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/voidpayments/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/voidpayments/excel(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task ExportVoidPaymentsToCSV(int? ProgramID, string StartDate, string EndDate, Query query = null, string fileName = null)
      {
          navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/voidpayments/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/voidpayments/csv(ProgramID={ProgramID}, StartDate='{StartDate}', EndDate='{EndDate}', fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
      }

      public async Task<IQueryable<Models.RecoDb.VoidPayment>> GetVoidPayments(int? ProgramID, string StartDate, string EndDate, Query query = null)
      {
          OnVoidPaymentsDefaultParams(ref ProgramID, ref StartDate, ref EndDate);

          var items = Context.VoidPayments.FromSqlRaw("EXEC [dbo].[VoidPayments] @ProgramID={0}, @StartDate={1}, @EndDate={2}", ProgramID, string.IsNullOrEmpty(StartDate) ? DBNull.Value : (object)DateTime.Parse(StartDate, null, System.Globalization.DateTimeStyles.RoundtripKind), string.IsNullOrEmpty(EndDate) ? DBNull.Value : (object)DateTime.Parse(EndDate, null, System.Globalization.DateTimeStyles.RoundtripKind)).ToList().AsQueryable();

          if (query != null)
          {
              if (!string.IsNullOrEmpty(query.Expand))
              {
                  var propertiesToExpand = query.Expand.Split(',');
                  foreach(var p in propertiesToExpand)
                  {
                      items = items.Include(p);
                  }
              }

              if (!string.IsNullOrEmpty(query.Filter))
              {
                  if (query.FilterParameters != null)
                  {
                      items = items.Where(query.Filter, query.FilterParameters);
                  }
                  else
                  {
                      items = items.Where(query.Filter);
                  }
              }

              if (!string.IsNullOrEmpty(query.OrderBy))
              {
                  items = items.OrderBy(query.OrderBy);
              }

              if (query.Skip.HasValue)
              {
                  items = items.Skip(query.Skip.Value);
              }

              if (query.Top.HasValue)
              {
                  items = items.Take(query.Top.Value);
              }
          }
          
          OnVoidPaymentsInvoke(ref items);

          return await Task.FromResult(items);
      }

      partial void OnVoidPaymentsDefaultParams(ref int? ProgramID, ref string StartDate, ref string EndDate);

      partial void OnVoidPaymentsInvoke(ref IQueryable<Models.RecoDb.VoidPayment> items);
      public async Task<int> VoidTransactions(int? TransactionID)
      {
          OnVoidTransactionsDefaultParams(ref TransactionID);

          SqlParameter[] @params =
          {
              new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output},
              new SqlParameter("@TransactionID", SqlDbType.Int) {Direction = ParameterDirection.Input, Value = TransactionID},
          };

          foreach(var p in @params)
          {
              if(p.Direction == ParameterDirection.Input && p.Value == null)
              {
                  p.Value = DBNull.Value;
              }
          }

          Context.Database.ExecuteSqlRaw("EXEC @returnVal=[dbo].[VoidTransaction] @TransactionID", @params);

          int result = Convert.ToInt32(@params[0].Value);

          OnVoidTransactionsInvoke(ref result);

          return await Task.FromResult(result);
      }

      partial void OnVoidTransactionsDefaultParams(ref int? TransactionID);
      partial void OnVoidTransactionsInvoke(ref int result);
        public async Task ExportXRefClaimsToExcel(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/xrefclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/xrefclaims/excel(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        public async Task ExportXRefClaimsToCSV(Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/xrefclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')") : $"export/recodb/xrefclaims/csv(fileName='{(!string.IsNullOrEmpty(fileName) ? UrlEncoder.Default.Encode(fileName) : "Export")}')", true);
        }

        partial void OnXRefClaimsRead(ref IQueryable<Models.RecoDb.XRefClaim> items);

        public async Task<IQueryable<Models.RecoDb.XRefClaim>> GetXRefClaims(Query query = null)
        {
            var items = Context.XRefClaims.AsQueryable();
            items = items.AsNoTracking();

            if (query != null)
            {
                if (!string.IsNullOrEmpty(query.Expand))
                {
                    var propertiesToExpand = query.Expand.Split(',');
                    foreach(var p in propertiesToExpand)
                    {
                        items = items.Include(p);
                    }
                }

                if (!string.IsNullOrEmpty(query.Filter))
                {
                    if (query.FilterParameters != null)
                    {
                        items = items.Where(query.Filter, query.FilterParameters);
                    }
                    else
                    {
                        items = items.Where(query.Filter);
                    }
                }

                if (!string.IsNullOrEmpty(query.OrderBy))
                {
                    items = items.OrderBy(query.OrderBy);
                }

                if (query.Skip.HasValue)
                {
                    items = items.Skip(query.Skip.Value);
                }

                if (query.Top.HasValue)
                {
                    items = items.Take(query.Top.Value);
                }
            }

            OnXRefClaimsRead(ref items);

            return await Task.FromResult(items);
        }

        partial void OnAdministratorDeleted(Models.RecoDb.Administrator item);
        partial void OnAfterAdministratorDeleted(Models.RecoDb.Administrator item);

        public async Task<Models.RecoDb.Administrator> DeleteAdministrator(Guid? id)
        {
            var itemToDelete = Context.Administrators
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAdministratorDeleted(itemToDelete);

            Context.Administrators.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAdministratorDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnAdministratorGet(Models.RecoDb.Administrator item);

        public async Task<Models.RecoDb.Administrator> GetAdministratorById(Guid? id)
        {
            var items = Context.Administrators
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnAdministratorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Administrator> CancelAdministratorChanges(Models.RecoDb.Administrator item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAdministratorUpdated(Models.RecoDb.Administrator item);
        partial void OnAfterAdministratorUpdated(Models.RecoDb.Administrator item);

        public async Task<Models.RecoDb.Administrator> UpdateAdministrator(Guid? id, Models.RecoDb.Administrator administrator)
        {
            OnAdministratorUpdated(administrator);

            var itemToUpdate = Context.Administrators
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(administrator);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterAdministratorUpdated(administrator);

            return administrator;
        }

        partial void OnAppointmentDeleted(Models.RecoDb.Appointment item);
        partial void OnAfterAppointmentDeleted(Models.RecoDb.Appointment item);

        public async Task<Models.RecoDb.Appointment> DeleteAppointment(Guid? id)
        {
            var itemToDelete = Context.Appointments
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAppointmentDeleted(itemToDelete);

            Context.Appointments.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAppointmentDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnAppointmentGet(Models.RecoDb.Appointment item);

        public async Task<Models.RecoDb.Appointment> GetAppointmentById(Guid? id)
        {
            var items = Context.Appointments
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnAppointmentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Appointment> CancelAppointmentChanges(Models.RecoDb.Appointment item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAppointmentUpdated(Models.RecoDb.Appointment item);
        partial void OnAfterAppointmentUpdated(Models.RecoDb.Appointment item);

        public async Task<Models.RecoDb.Appointment> UpdateAppointment(Guid? id, Models.RecoDb.Appointment appointment)
        {
            OnAppointmentUpdated(appointment);

            var itemToUpdate = Context.Appointments
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(appointment);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterAppointmentUpdated(appointment);

            return appointment;
        }

        partial void OnAuditTrailDeleted(Models.RecoDb.AuditTrail item);
        partial void OnAfterAuditTrailDeleted(Models.RecoDb.AuditTrail item);

        public async Task<Models.RecoDb.AuditTrail> DeleteAuditTrail(int? auditTrailId)
        {
            var itemToDelete = Context.AuditTrails
                              .Where(i => i.AuditTrailID == auditTrailId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAuditTrailDeleted(itemToDelete);

            Context.AuditTrails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAuditTrailDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnAuditTrailGet(Models.RecoDb.AuditTrail item);

        public async Task<Models.RecoDb.AuditTrail> GetAuditTrailByAuditTrailId(int? auditTrailId)
        {
            var items = Context.AuditTrails
                              .AsNoTracking()
                              .Where(i => i.AuditTrailID == auditTrailId);

            items = items.Include(i => i.Claim);

            var itemToReturn = items.FirstOrDefault();

            OnAuditTrailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.AuditTrail> CancelAuditTrailChanges(Models.RecoDb.AuditTrail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAuditTrailUpdated(Models.RecoDb.AuditTrail item);
        partial void OnAfterAuditTrailUpdated(Models.RecoDb.AuditTrail item);

        public async Task<Models.RecoDb.AuditTrail> UpdateAuditTrail(int? auditTrailId, Models.RecoDb.AuditTrail auditTrail)
        {
            OnAuditTrailUpdated(auditTrail);

            var itemToUpdate = Context.AuditTrails
                              .Where(i => i.AuditTrailID == auditTrailId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(auditTrail);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterAuditTrailUpdated(auditTrail);

            return auditTrail;
        }

        partial void OnAutoReservingDeleted(Models.RecoDb.AutoReserving item);
        partial void OnAfterAutoReservingDeleted(Models.RecoDb.AutoReserving item);

        public async Task<Models.RecoDb.AutoReserving> DeleteAutoReserving(int? programId, int? claimInitiationId, bool? claimOrIncident)
        {
            var itemToDelete = Context.AutoReservings
                              .Where(i => i.ProgramID == programId && i.ClaimInitiationID == claimInitiationId && i.ClaimOrIncident == claimOrIncident)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnAutoReservingDeleted(itemToDelete);

            Context.AutoReservings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterAutoReservingDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnAutoReservingGet(Models.RecoDb.AutoReserving item);

        public async Task<Models.RecoDb.AutoReserving> GetAutoReservingByProgramIdAndClaimInitiationIdAndClaimOrIncident(int? programId, int? claimInitiationId, bool? claimOrIncident)
        {
            var items = Context.AutoReservings
                              .AsNoTracking()
                              .Where(i => i.ProgramID == programId && i.ClaimInitiationID == claimInitiationId && i.ClaimOrIncident == claimOrIncident);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnAutoReservingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.AutoReserving> CancelAutoReservingChanges(Models.RecoDb.AutoReserving item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnAutoReservingUpdated(Models.RecoDb.AutoReserving item);
        partial void OnAfterAutoReservingUpdated(Models.RecoDb.AutoReserving item);

        public async Task<Models.RecoDb.AutoReserving> UpdateAutoReserving(int? programId, int? claimInitiationId, bool? claimOrIncident, Models.RecoDb.AutoReserving autoReserving)
        {
            OnAutoReservingUpdated(autoReserving);

            var itemToUpdate = Context.AutoReservings
                              .Where(i => i.ProgramID == programId && i.ClaimInitiationID == claimInitiationId && i.ClaimOrIncident == claimOrIncident)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(autoReserving);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterAutoReservingUpdated(autoReserving);

            return autoReserving;
        }

        partial void OnBinaryRoleValueDeleted(Models.RecoDb.BinaryRoleValue item);
        partial void OnAfterBinaryRoleValueDeleted(Models.RecoDb.BinaryRoleValue item);

        public async Task<Models.RecoDb.BinaryRoleValue> DeleteBinaryRoleValue(string roleId)
        {
            var itemToDelete = Context.BinaryRoleValues
                              .Where(i => i.RoleID == roleId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBinaryRoleValueDeleted(itemToDelete);

            Context.BinaryRoleValues.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBinaryRoleValueDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnBinaryRoleValueGet(Models.RecoDb.BinaryRoleValue item);

        public async Task<Models.RecoDb.BinaryRoleValue> GetBinaryRoleValueByRoleId(string roleId)
        {
            var items = Context.BinaryRoleValues
                              .AsNoTracking()
                              .Where(i => i.RoleID == roleId);

            var itemToReturn = items.FirstOrDefault();

            OnBinaryRoleValueGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.BinaryRoleValue> CancelBinaryRoleValueChanges(Models.RecoDb.BinaryRoleValue item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBinaryRoleValueUpdated(Models.RecoDb.BinaryRoleValue item);
        partial void OnAfterBinaryRoleValueUpdated(Models.RecoDb.BinaryRoleValue item);

        public async Task<Models.RecoDb.BinaryRoleValue> UpdateBinaryRoleValue(string roleId, Models.RecoDb.BinaryRoleValue binaryRoleValue)
        {
            OnBinaryRoleValueUpdated(binaryRoleValue);

            var itemToUpdate = Context.BinaryRoleValues
                              .Where(i => i.RoleID == roleId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(binaryRoleValue);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterBinaryRoleValueUpdated(binaryRoleValue);

            return binaryRoleValue;
        }

        partial void OnBrokerageDeleted(Models.RecoDb.Brokerage item);
        partial void OnAfterBrokerageDeleted(Models.RecoDb.Brokerage item);

        public async Task<Models.RecoDb.Brokerage> DeleteBrokerage(int? brokerageId)
        {
            var itemToDelete = Context.Brokerages
                              .Where(i => i.BrokerageID == brokerageId)
                              .Include(i => i.Claimants)
                              .Include(i => i.BrokerageContacts)
                              .Include(i => i.Occurrences)
                              .Include(i => i.Insureds)
                              .Include(i => i.Claims)
                              .Include(i => i.Registrants)
                              .Include(i => i.OtherParties)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBrokerageDeleted(itemToDelete);

            Context.Brokerages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBrokerageDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnBrokerageGet(Models.RecoDb.Brokerage item);

        public async Task<Models.RecoDb.Brokerage> GetBrokerageByBrokerageId(int? brokerageId)
        {
            var items = Context.Brokerages
                              .AsNoTracking()
                              .Where(i => i.BrokerageID == brokerageId);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Administrator);

            var itemToReturn = items.FirstOrDefault();

            OnBrokerageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Brokerage> CancelBrokerageChanges(Models.RecoDb.Brokerage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBrokerageUpdated(Models.RecoDb.Brokerage item);
        partial void OnAfterBrokerageUpdated(Models.RecoDb.Brokerage item);

        public async Task<Models.RecoDb.Brokerage> UpdateBrokerage(int? brokerageId, Models.RecoDb.Brokerage brokerage)
        {
            OnBrokerageUpdated(brokerage);

            var itemToUpdate = Context.Brokerages
                              .Where(i => i.BrokerageID == brokerageId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(brokerage);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterBrokerageUpdated(brokerage);

            return brokerage;
        }

        partial void OnBrokerageContactDeleted(Models.RecoDb.BrokerageContact item);
        partial void OnAfterBrokerageContactDeleted(Models.RecoDb.BrokerageContact item);

        public async Task<Models.RecoDb.BrokerageContact> DeleteBrokerageContact(int? brokerageContactId)
        {
            var itemToDelete = Context.BrokerageContacts
                              .Where(i => i.BrokerageContactID == brokerageContactId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBrokerageContactDeleted(itemToDelete);

            Context.BrokerageContacts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBrokerageContactDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnBrokerageContactGet(Models.RecoDb.BrokerageContact item);

        public async Task<Models.RecoDb.BrokerageContact> GetBrokerageContactByBrokerageContactId(int? brokerageContactId)
        {
            var items = Context.BrokerageContacts
                              .AsNoTracking()
                              .Where(i => i.BrokerageContactID == brokerageContactId);

            items = items.Include(i => i.Brokerage);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnBrokerageContactGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.BrokerageContact> CancelBrokerageContactChanges(Models.RecoDb.BrokerageContact item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBrokerageContactUpdated(Models.RecoDb.BrokerageContact item);
        partial void OnAfterBrokerageContactUpdated(Models.RecoDb.BrokerageContact item);

        public async Task<Models.RecoDb.BrokerageContact> UpdateBrokerageContact(int? brokerageContactId, Models.RecoDb.BrokerageContact brokerageContact)
        {
            OnBrokerageContactUpdated(brokerageContact);

            var itemToUpdate = Context.BrokerageContacts
                              .Where(i => i.BrokerageContactID == brokerageContactId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(brokerageContact);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterBrokerageContactUpdated(brokerageContact);

            return brokerageContact;
        }

        partial void OnBuilderDeleted(Models.RecoDb.Builder item);
        partial void OnAfterBuilderDeleted(Models.RecoDb.Builder item);

        public async Task<Models.RecoDb.Builder> DeleteBuilder(Guid? id)
        {
            var itemToDelete = Context.Builders
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnBuilderDeleted(itemToDelete);

            Context.Builders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterBuilderDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnBuilderGet(Models.RecoDb.Builder item);

        public async Task<Models.RecoDb.Builder> GetBuilderById(Guid? id)
        {
            var items = Context.Builders
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnBuilderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Builder> CancelBuilderChanges(Models.RecoDb.Builder item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnBuilderUpdated(Models.RecoDb.Builder item);
        partial void OnAfterBuilderUpdated(Models.RecoDb.Builder item);

        public async Task<Models.RecoDb.Builder> UpdateBuilder(Guid? id, Models.RecoDb.Builder builder)
        {
            OnBuilderUpdated(builder);

            var itemToUpdate = Context.Builders
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(builder);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterBuilderUpdated(builder);

            return builder;
        }

        partial void OnCdiNoticeOfClaimDetailDeleted(Models.RecoDb.CdiNoticeOfClaimDetail item);
        partial void OnAfterCdiNoticeOfClaimDetailDeleted(Models.RecoDb.CdiNoticeOfClaimDetail item);

        public async Task<Models.RecoDb.CdiNoticeOfClaimDetail> DeleteCdiNoticeOfClaimDetail(int? id)
        {
            var itemToDelete = Context.CdiNoticeOfClaimDetails
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCdiNoticeOfClaimDetailDeleted(itemToDelete);

            Context.CdiNoticeOfClaimDetails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCdiNoticeOfClaimDetailDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCdiNoticeOfClaimDetailGet(Models.RecoDb.CdiNoticeOfClaimDetail item);

        public async Task<Models.RecoDb.CdiNoticeOfClaimDetail> GetCdiNoticeOfClaimDetailById(int? id)
        {
            var items = Context.CdiNoticeOfClaimDetails
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnCdiNoticeOfClaimDetailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.CdiNoticeOfClaimDetail> CancelCdiNoticeOfClaimDetailChanges(Models.RecoDb.CdiNoticeOfClaimDetail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCdiNoticeOfClaimDetailUpdated(Models.RecoDb.CdiNoticeOfClaimDetail item);
        partial void OnAfterCdiNoticeOfClaimDetailUpdated(Models.RecoDb.CdiNoticeOfClaimDetail item);

        public async Task<Models.RecoDb.CdiNoticeOfClaimDetail> UpdateCdiNoticeOfClaimDetail(int? id, Models.RecoDb.CdiNoticeOfClaimDetail cdiNoticeOfClaimDetail)
        {
            OnCdiNoticeOfClaimDetailUpdated(cdiNoticeOfClaimDetail);

            var itemToUpdate = Context.CdiNoticeOfClaimDetails
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cdiNoticeOfClaimDetail);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCdiNoticeOfClaimDetailUpdated(cdiNoticeOfClaimDetail);

            return cdiNoticeOfClaimDetail;
        }

        partial void OnCdpClaimDetailDeleted(Models.RecoDb.CdpClaimDetail item);
        partial void OnAfterCdpClaimDetailDeleted(Models.RecoDb.CdpClaimDetail item);

        public async Task<Models.RecoDb.CdpClaimDetail> DeleteCdpClaimDetail(int? claimId)
        {
            var itemToDelete = Context.CdpClaimDetails
                              .Where(i => i.ClaimID == claimId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCdpClaimDetailDeleted(itemToDelete);

            Context.CdpClaimDetails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCdpClaimDetailDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCdpClaimDetailGet(Models.RecoDb.CdpClaimDetail item);

        public async Task<Models.RecoDb.CdpClaimDetail> GetCdpClaimDetailByClaimId(int? claimId)
        {
            var items = Context.CdpClaimDetails
                              .AsNoTracking()
                              .Where(i => i.ClaimID == claimId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Claim1);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Claim2);

            var itemToReturn = items.FirstOrDefault();

            OnCdpClaimDetailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.CdpClaimDetail> CancelCdpClaimDetailChanges(Models.RecoDb.CdpClaimDetail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCdpClaimDetailUpdated(Models.RecoDb.CdpClaimDetail item);
        partial void OnAfterCdpClaimDetailUpdated(Models.RecoDb.CdpClaimDetail item);

        public async Task<Models.RecoDb.CdpClaimDetail> UpdateCdpClaimDetail(int? claimId, Models.RecoDb.CdpClaimDetail cdpClaimDetail)
        {
            OnCdpClaimDetailUpdated(cdpClaimDetail);

            var itemToUpdate = Context.CdpClaimDetails
                              .Where(i => i.ClaimID == claimId)
                              .Include(cdp => cdp.Claim.Claimant)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cdpClaimDetail);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCdpClaimDetailUpdated(cdpClaimDetail);

            return cdpClaimDetail;
        }

        partial void OnClaimDeleted(Models.RecoDb.Claim item);
        partial void OnAfterClaimDeleted(Models.RecoDb.Claim item);

        public async Task<Models.RecoDb.Claim> DeleteClaim(Guid? id)
        {
            var itemToDelete = Context.Claims
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimDeleted(itemToDelete);

            Context.Claims.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimGet(Models.RecoDb.Claim item);

        public async Task<Models.RecoDb.Claim> GetClaimById(Guid? id)
        {
            var items = Context.Claims
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.ServiceProvider1);

            items = items.Include(i => i.ServiceProvider2);

            items = items.Include(i => i.ServiceProvider3);

            items = items.Include(i => i.Brokerage);

            items = items.Include(i => i.Parameter3);

            items = items.Include(i => i.Parameter4);

            items = items.Include(i => i.Parameter5);

            items = items.Include(i => i.Occurrence);

            items = items.Include(i => i.ServiceProvider4);

            items = items.Include(i => i.Parameter6);

            items = items.Include(i => i.Parameter7);

            items = items.Include(i => i.Parameter8);

            items = items.Include(i => i.ServiceProvider5);

            items = items.Include(i => i.Parameter9);

            items = items.Include(i => i.Claimant);

            items = items.Include(i => i.Claim1);

            items = items.Include(i => i.Parameter10);

            var itemToReturn = items.FirstOrDefault();

            OnClaimGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Claim> CancelClaimChanges(Models.RecoDb.Claim item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimUpdated(Models.RecoDb.Claim item);
        partial void OnAfterClaimUpdated(Models.RecoDb.Claim item);

        public async Task<Models.RecoDb.Claim> UpdateClaim(Guid? id, Models.RecoDb.Claim claim)
        {
            OnClaimUpdated(claim);

            var itemToUpdate = Context.Claims
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claim);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimUpdated(claim);

            return claim;
        }

        partial void OnClaimFileReportingDeleted(Models.RecoDb.ClaimFileReporting item);
        partial void OnAfterClaimFileReportingDeleted(Models.RecoDb.ClaimFileReporting item);

        public async Task<Models.RecoDb.ClaimFileReporting> DeleteClaimFileReporting(int? fileReportId)
        {
            var itemToDelete = Context.ClaimFileReportings
                              .Where(i => i.FileReportID == fileReportId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimFileReportingDeleted(itemToDelete);

            Context.ClaimFileReportings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimFileReportingDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimFileReportingGet(Models.RecoDb.ClaimFileReporting item);

        public async Task<Models.RecoDb.ClaimFileReporting> GetClaimFileReportingByFileReportId(int? fileReportId)
        {
            var items = Context.ClaimFileReportings
                              .AsNoTracking()
                              .Where(i => i.FileReportID == fileReportId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.ServiceProvider);

            var itemToReturn = items.FirstOrDefault();

            OnClaimFileReportingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ClaimFileReporting> CancelClaimFileReportingChanges(Models.RecoDb.ClaimFileReporting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimFileReportingUpdated(Models.RecoDb.ClaimFileReporting item);
        partial void OnAfterClaimFileReportingUpdated(Models.RecoDb.ClaimFileReporting item);

        public async Task<Models.RecoDb.ClaimFileReporting> UpdateClaimFileReporting(int? fileReportId, Models.RecoDb.ClaimFileReporting claimFileReporting)
        {
            OnClaimFileReportingUpdated(claimFileReporting);

            var itemToUpdate = Context.ClaimFileReportings
                              .Where(i => i.FileReportID == fileReportId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claimFileReporting);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimFileReportingUpdated(claimFileReporting);

            return claimFileReporting;
        }

        partial void OnClaimLitigationDateDeleted(Models.RecoDb.ClaimLitigationDate item);
        partial void OnAfterClaimLitigationDateDeleted(Models.RecoDb.ClaimLitigationDate item);

        public async Task<Models.RecoDb.ClaimLitigationDate> DeleteClaimLitigationDate(int? litigationDateId)
        {
            var itemToDelete = Context.ClaimLitigationDates
                              .Where(i => i.LitigationDateID == litigationDateId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimLitigationDateDeleted(itemToDelete);

            Context.ClaimLitigationDates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimLitigationDateDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimLitigationDateGet(Models.RecoDb.ClaimLitigationDate item);

        public async Task<Models.RecoDb.ClaimLitigationDate> GetClaimLitigationDateByLitigationDateId(int? litigationDateId)
        {
            var items = Context.ClaimLitigationDates
                              .AsNoTracking()
                              .Where(i => i.LitigationDateID == litigationDateId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnClaimLitigationDateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ClaimLitigationDate> CancelClaimLitigationDateChanges(Models.RecoDb.ClaimLitigationDate item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimLitigationDateUpdated(Models.RecoDb.ClaimLitigationDate item);
        partial void OnAfterClaimLitigationDateUpdated(Models.RecoDb.ClaimLitigationDate item);

        public async Task<Models.RecoDb.ClaimLitigationDate> UpdateClaimLitigationDate(int? litigationDateId, Models.RecoDb.ClaimLitigationDate claimLitigationDate)
        {
            OnClaimLitigationDateUpdated(claimLitigationDate);

            var itemToUpdate = Context.ClaimLitigationDates
                              .Where(i => i.LitigationDateID == litigationDateId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claimLitigationDate);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimLitigationDateUpdated(claimLitigationDate);

            return claimLitigationDate;
        }

        partial void OnClaimReportDeleted(Models.RecoDb.ClaimReport item);
        partial void OnAfterClaimReportDeleted(Models.RecoDb.ClaimReport item);

        public async Task<Models.RecoDb.ClaimReport> DeleteClaimReport(int? claimReportId)
        {
            var itemToDelete = Context.ClaimReports
                              .Where(i => i.ClaimReportID == claimReportId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimReportDeleted(itemToDelete);

            Context.ClaimReports.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimReportDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimReportGet(Models.RecoDb.ClaimReport item);

        public async Task<Models.RecoDb.ClaimReport> GetClaimReportByClaimReportId(int? claimReportId)
        {
            var items = Context.ClaimReports
                              .AsNoTracking()
                              .Where(i => i.ClaimReportID == claimReportId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Firm);

            var itemToReturn = items.FirstOrDefault();

            OnClaimReportGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ClaimReport> CancelClaimReportChanges(Models.RecoDb.ClaimReport item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimReportUpdated(Models.RecoDb.ClaimReport item);
        partial void OnAfterClaimReportUpdated(Models.RecoDb.ClaimReport item);

        public async Task<Models.RecoDb.ClaimReport> UpdateClaimReport(int? claimReportId, Models.RecoDb.ClaimReport claimReport)
        {
            OnClaimReportUpdated(claimReport);

            var itemToUpdate = Context.ClaimReports
                              .Where(i => i.ClaimReportID == claimReportId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claimReport);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimReportUpdated(claimReport);

            return claimReport;
        }

        partial void OnClaimStatusHistoryDeleted(Models.RecoDb.ClaimStatusHistory item);
        partial void OnAfterClaimStatusHistoryDeleted(Models.RecoDb.ClaimStatusHistory item);

        public async Task<Models.RecoDb.ClaimStatusHistory> DeleteClaimStatusHistory(int? claimStatusId)
        {
            var itemToDelete = Context.ClaimStatusHistories
                              .Where(i => i.ClaimStatusID == claimStatusId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimStatusHistoryDeleted(itemToDelete);

            Context.ClaimStatusHistories.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimStatusHistoryDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimStatusHistoryGet(Models.RecoDb.ClaimStatusHistory item);

        public async Task<Models.RecoDb.ClaimStatusHistory> GetClaimStatusHistoryByClaimStatusId(int? claimStatusId)
        {
            var items = Context.ClaimStatusHistories
                              .AsNoTracking()
                              .Where(i => i.ClaimStatusID == claimStatusId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnClaimStatusHistoryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ClaimStatusHistory> CancelClaimStatusHistoryChanges(Models.RecoDb.ClaimStatusHistory item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimStatusHistoryUpdated(Models.RecoDb.ClaimStatusHistory item);
        partial void OnAfterClaimStatusHistoryUpdated(Models.RecoDb.ClaimStatusHistory item);

        public async Task<Models.RecoDb.ClaimStatusHistory> UpdateClaimStatusHistory(int? claimStatusId, Models.RecoDb.ClaimStatusHistory claimStatusHistory)
        {
            OnClaimStatusHistoryUpdated(claimStatusHistory);

            var itemToUpdate = Context.ClaimStatusHistories
                              .Where(i => i.ClaimStatusID == claimStatusId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claimStatusHistory);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimStatusHistoryUpdated(claimStatusHistory);

            return claimStatusHistory;
        }

        partial void OnClaimantDeleted(Models.RecoDb.Claimant item);
        partial void OnAfterClaimantDeleted(Models.RecoDb.Claimant item);

        public async Task<Models.RecoDb.Claimant> DeleteClaimant(Guid? id)
        {
            var itemToDelete = Context.Claimants
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimantDeleted(itemToDelete);

            Context.Claimants.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimantDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimantGet(Models.RecoDb.Claimant item);

        public async Task<Models.RecoDb.Claimant> GetClaimantById(Guid? id)
        {
            var items = Context.Claimants
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.ClaimantSolicitor);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.Brokerage);

            var itemToReturn = items.FirstOrDefault();

            OnClaimantGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Claimant> CancelClaimantChanges(Models.RecoDb.Claimant item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimantUpdated(Models.RecoDb.Claimant item);
        partial void OnAfterClaimantUpdated(Models.RecoDb.Claimant item);

        public async Task<Models.RecoDb.Claimant> UpdateClaimant(Guid? id, Models.RecoDb.Claimant claimant)
        {
            OnClaimantUpdated(claimant);

            var itemToUpdate = Context.Claimants
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claimant);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimantUpdated(claimant);

            return claimant;
        }

        partial void OnClaimantLitigationRoleDeleted(Models.RecoDb.ClaimantLitigationRole item);
        partial void OnAfterClaimantLitigationRoleDeleted(Models.RecoDb.ClaimantLitigationRole item);

        public async Task<Models.RecoDb.ClaimantLitigationRole> DeleteClaimantLitigationRole(int? claimantId, int? litigationRole)
        {
            var itemToDelete = Context.ClaimantLitigationRoles
                              .Where(i => i.ClaimantID == claimantId && i.LitigationRole == litigationRole)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimantLitigationRoleDeleted(itemToDelete);

            Context.ClaimantLitigationRoles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimantLitigationRoleDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimantLitigationRoleGet(Models.RecoDb.ClaimantLitigationRole item);

        public async Task<Models.RecoDb.ClaimantLitigationRole> GetClaimantLitigationRoleByClaimantIdAndLitigationRole(int? claimantId, int? litigationRole)
        {
            var items = Context.ClaimantLitigationRoles
                              .AsNoTracking()
                              .Where(i => i.ClaimantID == claimantId && i.LitigationRole == litigationRole);

            items = items.Include(i => i.Claimant);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnClaimantLitigationRoleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ClaimantLitigationRole> CancelClaimantLitigationRoleChanges(Models.RecoDb.ClaimantLitigationRole item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimantLitigationRoleUpdated(Models.RecoDb.ClaimantLitigationRole item);
        partial void OnAfterClaimantLitigationRoleUpdated(Models.RecoDb.ClaimantLitigationRole item);

        public async Task<Models.RecoDb.ClaimantLitigationRole> UpdateClaimantLitigationRole(int? claimantId, int? litigationRole, Models.RecoDb.ClaimantLitigationRole claimantLitigationRole)
        {
            OnClaimantLitigationRoleUpdated(claimantLitigationRole);

            var itemToUpdate = Context.ClaimantLitigationRoles
                              .Where(i => i.ClaimantID == claimantId && i.LitigationRole == litigationRole)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claimantLitigationRole);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimantLitigationRoleUpdated(claimantLitigationRole);

            return claimantLitigationRole;
        }

        partial void OnClaimantPaymentsReceivedDeleted(Models.RecoDb.ClaimantPaymentsReceived item);
        partial void OnAfterClaimantPaymentsReceivedDeleted(Models.RecoDb.ClaimantPaymentsReceived item);

        public async Task<Models.RecoDb.ClaimantPaymentsReceived> DeleteClaimantPaymentsReceived(int? claimantId, DateTime? paymentReceivedDate)
        {
            var itemToDelete = Context.ClaimantPaymentsReceiveds
                              .Where(i => i.ClaimantID == claimantId && i.PaymentReceivedDate == paymentReceivedDate)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimantPaymentsReceivedDeleted(itemToDelete);

            Context.ClaimantPaymentsReceiveds.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimantPaymentsReceivedDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimantPaymentsReceivedGet(Models.RecoDb.ClaimantPaymentsReceived item);

        public async Task<Models.RecoDb.ClaimantPaymentsReceived> GetClaimantPaymentsReceivedByClaimantIdAndPaymentReceivedDate(int? claimantId, DateTime? paymentReceivedDate)
        {
            var items = Context.ClaimantPaymentsReceiveds
                              .AsNoTracking()
                              .Where(i => i.ClaimantID == claimantId && i.PaymentReceivedDate == paymentReceivedDate);

            items = items.Include(i => i.Claimant);

            var itemToReturn = items.FirstOrDefault();

            OnClaimantPaymentsReceivedGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ClaimantPaymentsReceived> CancelClaimantPaymentsReceivedChanges(Models.RecoDb.ClaimantPaymentsReceived item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimantPaymentsReceivedUpdated(Models.RecoDb.ClaimantPaymentsReceived item);
        partial void OnAfterClaimantPaymentsReceivedUpdated(Models.RecoDb.ClaimantPaymentsReceived item);

        public async Task<Models.RecoDb.ClaimantPaymentsReceived> UpdateClaimantPaymentsReceived(int? claimantId, DateTime? paymentReceivedDate, Models.RecoDb.ClaimantPaymentsReceived claimantPaymentsReceived)
        {
            OnClaimantPaymentsReceivedUpdated(claimantPaymentsReceived);

            var itemToUpdate = Context.ClaimantPaymentsReceiveds
                              .Where(i => i.ClaimantID == claimantId && i.PaymentReceivedDate == paymentReceivedDate)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claimantPaymentsReceived);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimantPaymentsReceivedUpdated(claimantPaymentsReceived);

            return claimantPaymentsReceived;
        }

        partial void OnClaimantSolicitorDeleted(Models.RecoDb.ClaimantSolicitor item);
        partial void OnAfterClaimantSolicitorDeleted(Models.RecoDb.ClaimantSolicitor item);

        public async Task<Models.RecoDb.ClaimantSolicitor> DeleteClaimantSolicitor(Guid? id)
        {
            var itemToDelete = Context.ClaimantSolicitors
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnClaimantSolicitorDeleted(itemToDelete);

            Context.ClaimantSolicitors.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterClaimantSolicitorDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnClaimantSolicitorGet(Models.RecoDb.ClaimantSolicitor item);

        public async Task<Models.RecoDb.ClaimantSolicitor> GetClaimantSolicitorById(Guid? id)
        {
            var items = Context.ClaimantSolicitors
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnClaimantSolicitorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ClaimantSolicitor> CancelClaimantSolicitorChanges(Models.RecoDb.ClaimantSolicitor item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnClaimantSolicitorUpdated(Models.RecoDb.ClaimantSolicitor item);
        partial void OnAfterClaimantSolicitorUpdated(Models.RecoDb.ClaimantSolicitor item);

        public async Task<Models.RecoDb.ClaimantSolicitor> UpdateClaimantSolicitor(Guid? id, Models.RecoDb.ClaimantSolicitor claimantSolicitor)
        {
            OnClaimantSolicitorUpdated(claimantSolicitor);

            var itemToUpdate = Context.ClaimantSolicitors
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(claimantSolicitor);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterClaimantSolicitorUpdated(claimantSolicitor);

            return claimantSolicitor;
        }

        partial void OnCommissionInstallmentDeleted(Models.RecoDb.CommissionInstallment item);
        partial void OnAfterCommissionInstallmentDeleted(Models.RecoDb.CommissionInstallment item);

        public async Task<Models.RecoDb.CommissionInstallment> DeleteCommissionInstallment(int? commissionInstallmentId)
        {
            var itemToDelete = Context.CommissionInstallments
                              .Where(i => i.CommissionInstallmentID == commissionInstallmentId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCommissionInstallmentDeleted(itemToDelete);

            Context.CommissionInstallments.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCommissionInstallmentDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCommissionInstallmentGet(Models.RecoDb.CommissionInstallment item);

        public async Task<Models.RecoDb.CommissionInstallment> GetCommissionInstallmentByCommissionInstallmentId(int? commissionInstallmentId)
        {
            var items = Context.CommissionInstallments
                              .AsNoTracking()
                              .Where(i => i.CommissionInstallmentID == commissionInstallmentId);

            items = items.Include(i => i.Trade);

            var itemToReturn = items.FirstOrDefault();

            OnCommissionInstallmentGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.CommissionInstallment> CancelCommissionInstallmentChanges(Models.RecoDb.CommissionInstallment item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCommissionInstallmentUpdated(Models.RecoDb.CommissionInstallment item);
        partial void OnAfterCommissionInstallmentUpdated(Models.RecoDb.CommissionInstallment item);

        public async Task<Models.RecoDb.CommissionInstallment> UpdateCommissionInstallment(int? commissionInstallmentId, Models.RecoDb.CommissionInstallment commissionInstallment)
        {
            OnCommissionInstallmentUpdated(commissionInstallment);

            var itemToUpdate = Context.CommissionInstallments
                              .Where(i => i.CommissionInstallmentID == commissionInstallmentId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(commissionInstallment);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCommissionInstallmentUpdated(commissionInstallment);

            return commissionInstallment;
        }

        partial void OnCostAwardDeleted(Models.RecoDb.CostAward item);
        partial void OnAfterCostAwardDeleted(Models.RecoDb.CostAward item);

        public async Task<Models.RecoDb.CostAward> DeleteCostAward(int? costAwardId)
        {
            var itemToDelete = Context.CostAwards
                              .Where(i => i.CostAwardID == costAwardId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCostAwardDeleted(itemToDelete);

            Context.CostAwards.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCostAwardDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCostAwardGet(Models.RecoDb.CostAward item);

        public async Task<Models.RecoDb.CostAward> GetCostAwardByCostAwardId(int? costAwardId)
        {
            var items = Context.CostAwards
                              .AsNoTracking()
                              .Where(i => i.CostAwardID == costAwardId);

            items = items.Include(i => i.Claim);

            var itemToReturn = items.FirstOrDefault();

            OnCostAwardGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.CostAward> CancelCostAwardChanges(Models.RecoDb.CostAward item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCostAwardUpdated(Models.RecoDb.CostAward item);
        partial void OnAfterCostAwardUpdated(Models.RecoDb.CostAward item);

        public async Task<Models.RecoDb.CostAward> UpdateCostAward(int? costAwardId, Models.RecoDb.CostAward costAward)
        {
            OnCostAwardUpdated(costAward);

            var itemToUpdate = Context.CostAwards
                              .Where(i => i.CostAwardID == costAwardId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(costAward);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCostAwardUpdated(costAward);

            return costAward;
        }

        partial void OnCourtDateDeleted(Models.RecoDb.CourtDate item);
        partial void OnAfterCourtDateDeleted(Models.RecoDb.CourtDate item);

        public async Task<Models.RecoDb.CourtDate> DeleteCourtDate(int? courtDateId)
        {
            var itemToDelete = Context.CourtDates
                              .Where(i => i.CourtDateID == courtDateId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCourtDateDeleted(itemToDelete);

            Context.CourtDates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCourtDateDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCourtDateGet(Models.RecoDb.CourtDate item);

        public async Task<Models.RecoDb.CourtDate> GetCourtDateByCourtDateId(int? courtDateId)
        {
            var items = Context.CourtDates
                              .AsNoTracking()
                              .Where(i => i.CourtDateID == courtDateId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.ServiceProvider);

            var itemToReturn = items.FirstOrDefault();

            OnCourtDateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.CourtDate> CancelCourtDateChanges(Models.RecoDb.CourtDate item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCourtDateUpdated(Models.RecoDb.CourtDate item);
        partial void OnAfterCourtDateUpdated(Models.RecoDb.CourtDate item);

        public async Task<Models.RecoDb.CourtDate> UpdateCourtDate(int? courtDateId, Models.RecoDb.CourtDate courtDate)
        {
            OnCourtDateUpdated(courtDate);

            var itemToUpdate = Context.CourtDates
                              .Where(i => i.CourtDateID == courtDateId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(courtDate);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCourtDateUpdated(courtDate);

            return courtDate;
        }

        partial void OnCppNoticeOfClaimsDetailDeleted(Models.RecoDb.CppNoticeOfClaimsDetail item);
        partial void OnAfterCppNoticeOfClaimsDetailDeleted(Models.RecoDb.CppNoticeOfClaimsDetail item);

        public async Task<Models.RecoDb.CppNoticeOfClaimsDetail> DeleteCppNoticeOfClaimsDetail(int? noticeOfClaimDetailsId)
        {
            var itemToDelete = Context.CppNoticeOfClaimsDetails
                              .Where(i => i.NoticeOfClaimDetailsID == noticeOfClaimDetailsId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCppNoticeOfClaimsDetailDeleted(itemToDelete);

            Context.CppNoticeOfClaimsDetails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCppNoticeOfClaimsDetailDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCppNoticeOfClaimsDetailGet(Models.RecoDb.CppNoticeOfClaimsDetail item);

        public async Task<Models.RecoDb.CppNoticeOfClaimsDetail> GetCppNoticeOfClaimsDetailByNoticeOfClaimDetailsId(int? noticeOfClaimDetailsId)
        {
            var items = Context.CppNoticeOfClaimsDetails
                              .AsNoTracking()
                              .Where(i => i.NoticeOfClaimDetailsID == noticeOfClaimDetailsId);

            var itemToReturn = items.FirstOrDefault();

            OnCppNoticeOfClaimsDetailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.CppNoticeOfClaimsDetail> CancelCppNoticeOfClaimsDetailChanges(Models.RecoDb.CppNoticeOfClaimsDetail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCppNoticeOfClaimsDetailUpdated(Models.RecoDb.CppNoticeOfClaimsDetail item);
        partial void OnAfterCppNoticeOfClaimsDetailUpdated(Models.RecoDb.CppNoticeOfClaimsDetail item);

        public async Task<Models.RecoDb.CppNoticeOfClaimsDetail> UpdateCppNoticeOfClaimsDetail(int? noticeOfClaimDetailsId, Models.RecoDb.CppNoticeOfClaimsDetail cppNoticeOfClaimsDetail)
        {
            OnCppNoticeOfClaimsDetailUpdated(cppNoticeOfClaimsDetail);

            var itemToUpdate = Context.CppNoticeOfClaimsDetails
                              .Where(i => i.NoticeOfClaimDetailsID == noticeOfClaimDetailsId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(cppNoticeOfClaimsDetail);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCppNoticeOfClaimsDetailUpdated(cppNoticeOfClaimsDetail);

            return cppNoticeOfClaimsDetail;
        }

        partial void OnCrossReferencedClaimDeleted(Models.RecoDb.CrossReferencedClaim item);
        partial void OnAfterCrossReferencedClaimDeleted(Models.RecoDb.CrossReferencedClaim item);

        public async Task<Models.RecoDb.CrossReferencedClaim> DeleteCrossReferencedClaim(int? claimId, int? xRefClaimId)
        {
            var itemToDelete = Context.CrossReferencedClaims
                              .Where(i => i.ClaimID == claimId && i.XRefClaimID == xRefClaimId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnCrossReferencedClaimDeleted(itemToDelete);

            Context.CrossReferencedClaims.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterCrossReferencedClaimDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnCrossReferencedClaimGet(Models.RecoDb.CrossReferencedClaim item);

        public async Task<Models.RecoDb.CrossReferencedClaim> GetCrossReferencedClaimByClaimIdAndXRefClaimId(int? claimId, int? xRefClaimId)
        {
            var items = Context.CrossReferencedClaims
                              .AsNoTracking()
                              .Where(i => i.ClaimID == claimId && i.XRefClaimID == xRefClaimId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Claim1);

            var itemToReturn = items.FirstOrDefault();

            OnCrossReferencedClaimGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.CrossReferencedClaim> CancelCrossReferencedClaimChanges(Models.RecoDb.CrossReferencedClaim item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnCrossReferencedClaimUpdated(Models.RecoDb.CrossReferencedClaim item);
        partial void OnAfterCrossReferencedClaimUpdated(Models.RecoDb.CrossReferencedClaim item);

        public async Task<Models.RecoDb.CrossReferencedClaim> UpdateCrossReferencedClaim(int? claimId, int? xRefClaimId, Models.RecoDb.CrossReferencedClaim crossReferencedClaim)
        {
            OnCrossReferencedClaimUpdated(crossReferencedClaim);

            var itemToUpdate = Context.CrossReferencedClaims
                              .Where(i => i.ClaimID == claimId && i.XRefClaimID == xRefClaimId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(crossReferencedClaim);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterCrossReferencedClaimUpdated(crossReferencedClaim);

            return crossReferencedClaim;
        }

        partial void OnDiaryDeleted(Models.RecoDb.Diary item);
        partial void OnAfterDiaryDeleted(Models.RecoDb.Diary item);

        public async Task<Models.RecoDb.Diary> DeleteDiary(Guid? id)
        {
            var itemToDelete = Context.Diaries
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDiaryDeleted(itemToDelete);

            Context.Diaries.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDiaryDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnDiaryGet(Models.RecoDb.Diary item);

        public async Task<Models.RecoDb.Diary> GetDiaryById(Guid? id)
        {
            var items = Context.Diaries
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnDiaryGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Diary> CancelDiaryChanges(Models.RecoDb.Diary item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDiaryUpdated(Models.RecoDb.Diary item);
        partial void OnAfterDiaryUpdated(Models.RecoDb.Diary item);

        public async Task<Models.RecoDb.Diary> UpdateDiary(Guid? id, Models.RecoDb.Diary diary)
        {
            OnDiaryUpdated(diary);

            var itemToUpdate = Context.Diaries
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(diary);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterDiaryUpdated(diary);

            return diary;
        }

        partial void OnDiaryTemplateDeleted(Models.RecoDb.DiaryTemplate item);
        partial void OnAfterDiaryTemplateDeleted(Models.RecoDb.DiaryTemplate item);

        public async Task<Models.RecoDb.DiaryTemplate> DeleteDiaryTemplate(int? diaryTemplateId)
        {
            var itemToDelete = Context.DiaryTemplates
                              .Where(i => i.DiaryTemplateID == diaryTemplateId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnDiaryTemplateDeleted(itemToDelete);

            Context.DiaryTemplates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterDiaryTemplateDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnDiaryTemplateGet(Models.RecoDb.DiaryTemplate item);

        public async Task<Models.RecoDb.DiaryTemplate> GetDiaryTemplateByDiaryTemplateId(int? diaryTemplateId)
        {
            var items = Context.DiaryTemplates
                              .AsNoTracking()
                              .Where(i => i.DiaryTemplateID == diaryTemplateId);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnDiaryTemplateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.DiaryTemplate> CancelDiaryTemplateChanges(Models.RecoDb.DiaryTemplate item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnDiaryTemplateUpdated(Models.RecoDb.DiaryTemplate item);
        partial void OnAfterDiaryTemplateUpdated(Models.RecoDb.DiaryTemplate item);

        public async Task<Models.RecoDb.DiaryTemplate> UpdateDiaryTemplate(int? diaryTemplateId, Models.RecoDb.DiaryTemplate diaryTemplate)
        {
            OnDiaryTemplateUpdated(diaryTemplate);

            var itemToUpdate = Context.DiaryTemplates
                              .Where(i => i.DiaryTemplateID == diaryTemplateId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(diaryTemplate);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterDiaryTemplateUpdated(diaryTemplate);

            return diaryTemplate;
        }

        partial void OnEmailFolderDeleted(Models.RecoDb.EmailFolder item);
        partial void OnAfterEmailFolderDeleted(Models.RecoDb.EmailFolder item);

        public async Task<Models.RecoDb.EmailFolder> DeleteEmailFolder(string id)
        {
            var itemToDelete = Context.EmailFolders
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEmailFolderDeleted(itemToDelete);

            Context.EmailFolders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEmailFolderDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEmailFolderGet(Models.RecoDb.EmailFolder item);

        public async Task<Models.RecoDb.EmailFolder> GetEmailFolderById(string id)
        {
            var items = Context.EmailFolders
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.EmailFolder1);

            var itemToReturn = items.FirstOrDefault();

            OnEmailFolderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.EmailFolder> CancelEmailFolderChanges(Models.RecoDb.EmailFolder item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEmailFolderUpdated(Models.RecoDb.EmailFolder item);
        partial void OnAfterEmailFolderUpdated(Models.RecoDb.EmailFolder item);

        public async Task<Models.RecoDb.EmailFolder> UpdateEmailFolder(string id, Models.RecoDb.EmailFolder emailFolder)
        {
            OnEmailFolderUpdated(emailFolder);

            var itemToUpdate = Context.EmailFolders
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(emailFolder);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterEmailFolderUpdated(emailFolder);

            return emailFolder;
        }

        partial void OnEmailLinkFileDeleted(Models.RecoDb.EmailLinkFile item);
        partial void OnAfterEmailLinkFileDeleted(Models.RecoDb.EmailLinkFile item);

        public async Task<Models.RecoDb.EmailLinkFile> DeleteEmailLinkFile(int? id)
        {
            var itemToDelete = Context.EmailLinkFiles
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEmailLinkFileDeleted(itemToDelete);

            Context.EmailLinkFiles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEmailLinkFileDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEmailLinkFileGet(Models.RecoDb.EmailLinkFile item);

        public async Task<Models.RecoDb.EmailLinkFile> GetEmailLinkFileById(int? id)
        {
            var items = Context.EmailLinkFiles
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnEmailLinkFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.EmailLinkFile> CancelEmailLinkFileChanges(Models.RecoDb.EmailLinkFile item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEmailLinkFileUpdated(Models.RecoDb.EmailLinkFile item);
        partial void OnAfterEmailLinkFileUpdated(Models.RecoDb.EmailLinkFile item);

        public async Task<Models.RecoDb.EmailLinkFile> UpdateEmailLinkFile(int? id, Models.RecoDb.EmailLinkFile emailLinkFile)
        {
            OnEmailLinkFileUpdated(emailLinkFile);

            var itemToUpdate = Context.EmailLinkFiles
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(emailLinkFile);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterEmailLinkFileUpdated(emailLinkFile);

            return emailLinkFile;
        }

        partial void OnEmailMessageDeleted(Models.RecoDb.EmailMessage item);
        partial void OnAfterEmailMessageDeleted(Models.RecoDb.EmailMessage item);

        public async Task<Models.RecoDb.EmailMessage> DeleteEmailMessage(string id)
        {
            var itemToDelete = Context.EmailMessages
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEmailMessageDeleted(itemToDelete);

            Context.EmailMessages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEmailMessageDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEmailMessageGet(Models.RecoDb.EmailMessage item);

        public async Task<Models.RecoDb.EmailMessage> GetEmailMessageById(string id)
        {
            var items = Context.EmailMessages
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.EmailFolder);

            var itemToReturn = items.FirstOrDefault();

            OnEmailMessageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.EmailMessage> CancelEmailMessageChanges(Models.RecoDb.EmailMessage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEmailMessageUpdated(Models.RecoDb.EmailMessage item);
        partial void OnAfterEmailMessageUpdated(Models.RecoDb.EmailMessage item);

        public async Task<Models.RecoDb.EmailMessage> UpdateEmailMessage(string id, Models.RecoDb.EmailMessage emailMessage)
        {
            OnEmailMessageUpdated(emailMessage);

            var itemToUpdate = Context.EmailMessages
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(emailMessage);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterEmailMessageUpdated(emailMessage);

            return emailMessage;
        }

        partial void OnEoClaimDetailDeleted(Models.RecoDb.EoClaimDetail item);
        partial void OnAfterEoClaimDetailDeleted(Models.RecoDb.EoClaimDetail item);

        public async Task<Models.RecoDb.EoClaimDetail> DeleteEoClaimDetail(int? claimId)
        {
            var itemToDelete = Context.EoClaimDetails
                              .Where(i => i.ClaimID == claimId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEoClaimDetailDeleted(itemToDelete);

            Context.EoClaimDetails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEoClaimDetailDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEoClaimDetailGet(Models.RecoDb.EoClaimDetail item);

        public async Task<Models.RecoDb.EoClaimDetail> GetEoClaimDetailByClaimId(int? claimId)
        {
            var items = Context.EoClaimDetails
                              .AsNoTracking()
                              .Where(i => i.ClaimID == claimId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.ServiceProvider1);

            items = items.Include(i => i.ServiceProvider2);

            items = items.Include(i => i.ServiceProvider3);

            items = items.Include(i => i.ServiceProvider4);

            items = items.Include(i => i.Parameter3);

            items = items.Include(i => i.Parameter4);

            items = items.Include(i => i.Parameter5);

            items = items.Include(i => i.Parameter6);

            items = items.Include(i => i.Parameter7);

            items = items.Include(i => i.Parameter8);

            items = items.Include(i => i.Parameter9);

            items = items.Include(i => i.Parameter10);

            items = items.Include(i => i.Parameter11);

            items = items.Include(i => i.Parameter12);

            items = items.Include(i => i.Parameter13);

            items = items.Include(i => i.Parameter14);

            items = items.Include(i => i.Parameter15);

            items = items.Include(i => i.Parameter16);

            var itemToReturn = items.FirstOrDefault();

            OnEoClaimDetailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.EoClaimDetail> CancelEoClaimDetailChanges(Models.RecoDb.EoClaimDetail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEoClaimDetailUpdated(Models.RecoDb.EoClaimDetail item);
        partial void OnAfterEoClaimDetailUpdated(Models.RecoDb.EoClaimDetail item);

        public async Task<Models.RecoDb.EoClaimDetail> UpdateEoClaimDetail(int? claimId, Models.RecoDb.EoClaimDetail eoClaimDetail)
        {
            OnEoClaimDetailUpdated(eoClaimDetail);

            var itemToUpdate = Context.EoClaimDetails
                              .Where(i => i.ClaimID == claimId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(eoClaimDetail);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterEoClaimDetailUpdated(eoClaimDetail);

            return eoClaimDetail;
        }

        partial void OnEoNoticeOfClaimsDetailDeleted(Models.RecoDb.EoNoticeOfClaimsDetail item);
        partial void OnAfterEoNoticeOfClaimsDetailDeleted(Models.RecoDb.EoNoticeOfClaimsDetail item);

        public async Task<Models.RecoDb.EoNoticeOfClaimsDetail> DeleteEoNoticeOfClaimsDetail(int? noticeOfClaimId)
        {
            var itemToDelete = Context.EoNoticeOfClaimsDetails
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnEoNoticeOfClaimsDetailDeleted(itemToDelete);

            Context.EoNoticeOfClaimsDetails.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterEoNoticeOfClaimsDetailDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnEoNoticeOfClaimsDetailGet(Models.RecoDb.EoNoticeOfClaimsDetail item);

        public async Task<Models.RecoDb.EoNoticeOfClaimsDetail> GetEoNoticeOfClaimsDetailByNoticeOfClaimId(int? noticeOfClaimId)
        {
            var items = Context.EoNoticeOfClaimsDetails
                              .AsNoTracking()
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId);

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnEoNoticeOfClaimsDetailGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.EoNoticeOfClaimsDetail> CancelEoNoticeOfClaimsDetailChanges(Models.RecoDb.EoNoticeOfClaimsDetail item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnEoNoticeOfClaimsDetailUpdated(Models.RecoDb.EoNoticeOfClaimsDetail item);
        partial void OnAfterEoNoticeOfClaimsDetailUpdated(Models.RecoDb.EoNoticeOfClaimsDetail item);

        public async Task<Models.RecoDb.EoNoticeOfClaimsDetail> UpdateEoNoticeOfClaimsDetail(int? noticeOfClaimId, Models.RecoDb.EoNoticeOfClaimsDetail eoNoticeOfClaimsDetail)
        {
            OnEoNoticeOfClaimsDetailUpdated(eoNoticeOfClaimsDetail);

            var itemToUpdate = Context.EoNoticeOfClaimsDetails
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(eoNoticeOfClaimsDetail);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterEoNoticeOfClaimsDetailUpdated(eoNoticeOfClaimsDetail);

            return eoNoticeOfClaimsDetail;
        }

        partial void OnErrorLogDeleted(Models.RecoDb.ErrorLog item);
        partial void OnAfterErrorLogDeleted(Models.RecoDb.ErrorLog item);

        public async Task<Models.RecoDb.ErrorLog> DeleteErrorLog(int? errorLogId)
        {
            var itemToDelete = Context.ErrorLogs
                              .Where(i => i.ErrorLogID == errorLogId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnErrorLogDeleted(itemToDelete);

            Context.ErrorLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterErrorLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnErrorLogGet(Models.RecoDb.ErrorLog item);

        public async Task<Models.RecoDb.ErrorLog> GetErrorLogByErrorLogId(int? errorLogId)
        {
            var items = Context.ErrorLogs
                              .AsNoTracking()
                              .Where(i => i.ErrorLogID == errorLogId);

            items = items.Include(i => i.Claim);

            var itemToReturn = items.FirstOrDefault();

            OnErrorLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ErrorLog> CancelErrorLogChanges(Models.RecoDb.ErrorLog item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnErrorLogUpdated(Models.RecoDb.ErrorLog item);
        partial void OnAfterErrorLogUpdated(Models.RecoDb.ErrorLog item);

        public async Task<Models.RecoDb.ErrorLog> UpdateErrorLog(int? errorLogId, Models.RecoDb.ErrorLog errorLog)
        {
            OnErrorLogUpdated(errorLog);

            var itemToUpdate = Context.ErrorLogs
                              .Where(i => i.ErrorLogID == errorLogId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(errorLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterErrorLogUpdated(errorLog);

            return errorLog;
        }

        partial void OnExpertDeleted(Models.RecoDb.Expert item);
        partial void OnAfterExpertDeleted(Models.RecoDb.Expert item);

        public async Task<Models.RecoDb.Expert> DeleteExpert(int? expertId)
        {
            var itemToDelete = Context.Experts
                              .Where(i => i.ExpertID == expertId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnExpertDeleted(itemToDelete);

            Context.Experts.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterExpertDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnExpertGet(Models.RecoDb.Expert item);

        public async Task<Models.RecoDb.Expert> GetExpertByExpertId(int? expertId)
        {
            var items = Context.Experts
                              .AsNoTracking()
                              .Where(i => i.ExpertID == expertId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.Firm);

            var itemToReturn = items.FirstOrDefault();

            OnExpertGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Expert> CancelExpertChanges(Models.RecoDb.Expert item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnExpertUpdated(Models.RecoDb.Expert item);
        partial void OnAfterExpertUpdated(Models.RecoDb.Expert item);

        public async Task<Models.RecoDb.Expert> UpdateExpert(int? expertId, Models.RecoDb.Expert expert)
        {
            OnExpertUpdated(expert);

            var itemToUpdate = Context.Experts
                              .Where(i => i.ExpertID == expertId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(expert);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterExpertUpdated(expert);

            return expert;
        }

        partial void OnFileDeleted(Models.RecoDb.File item);
        partial void OnAfterFileDeleted(Models.RecoDb.File item);

        public async Task<Models.RecoDb.File> DeleteFile(Guid? id)
        {
            var itemToDelete = Context.Files
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFileDeleted(itemToDelete);

            Context.Files.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFileDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnFileGet(Models.RecoDb.File item);

        public async Task<Models.RecoDb.File> GetFileById(Guid? id)
        {
            var items = Context.Files
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.File> CancelFileChanges(Models.RecoDb.File item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFileUpdated(Models.RecoDb.File item);
        partial void OnAfterFileUpdated(Models.RecoDb.File item);

        public async Task<Models.RecoDb.File> UpdateFile(Guid? id, Models.RecoDb.File file)
        {
            OnFileUpdated(file);

            var itemToUpdate = Context.Files
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(file);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterFileUpdated(file);

            return file;
        }

        partial void OnFilesRoleDeleted(Models.RecoDb.FilesRole item);
        partial void OnAfterFilesRoleDeleted(Models.RecoDb.FilesRole item);

        public async Task<Models.RecoDb.FilesRole> DeleteFilesRole(int? id)
        {
            var itemToDelete = Context.FilesRoles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFilesRoleDeleted(itemToDelete);

            Context.FilesRoles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFilesRoleDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnFilesRoleGet(Models.RecoDb.FilesRole item);

        public async Task<Models.RecoDb.FilesRole> GetFilesRoleById(int? id)
        {
            var items = Context.FilesRoles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Role);

            var itemToReturn = items.FirstOrDefault();

            OnFilesRoleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.FilesRole> CancelFilesRoleChanges(Models.RecoDb.FilesRole item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFilesRoleUpdated(Models.RecoDb.FilesRole item);
        partial void OnAfterFilesRoleUpdated(Models.RecoDb.FilesRole item);

        public async Task<Models.RecoDb.FilesRole> UpdateFilesRole(int? id, Models.RecoDb.FilesRole filesRole)
        {
            OnFilesRoleUpdated(filesRole);

            var itemToUpdate = Context.FilesRoles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(filesRole);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterFilesRoleUpdated(filesRole);

            return filesRole;
        }

        partial void OnFirmDeleted(Models.RecoDb.Firm item);
        partial void OnAfterFirmDeleted(Models.RecoDb.Firm item);

        public async Task<Models.RecoDb.Firm> DeleteFirm(Guid? id)
        {
            var itemToDelete = Context.Firms
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnFirmDeleted(itemToDelete);

            Context.Firms.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterFirmDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnFirmGet(Models.RecoDb.Firm item);

        public async Task<Models.RecoDb.Firm> GetFirmById(Guid? id)
        {
            var items = Context.Firms
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnFirmGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Firm> CancelFirmChanges(Models.RecoDb.Firm item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnFirmUpdated(Models.RecoDb.Firm item);
        partial void OnAfterFirmUpdated(Models.RecoDb.Firm item);

        public async Task<Models.RecoDb.Firm> UpdateFirm(Guid? id, Models.RecoDb.Firm firm)
        {
            OnFirmUpdated(firm);

            var itemToUpdate = Context.Firms
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(firm);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterFirmUpdated(firm);

            return firm;
        }

        partial void OnGeneralSettingDeleted(Models.RecoDb.GeneralSetting item);
        partial void OnAfterGeneralSettingDeleted(Models.RecoDb.GeneralSetting item);

        public async Task<Models.RecoDb.GeneralSetting> DeleteGeneralSetting(Guid? id)
        {
            var itemToDelete = Context.GeneralSettings
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnGeneralSettingDeleted(itemToDelete);

            Context.GeneralSettings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterGeneralSettingDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnGeneralSettingGet(Models.RecoDb.GeneralSetting item);

        public async Task<Models.RecoDb.GeneralSetting> GetGeneralSettingById(Guid? id)
        {
            var items = Context.GeneralSettings
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            var itemToReturn = items.FirstOrDefault();

            OnGeneralSettingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.GeneralSetting> CancelGeneralSettingChanges(Models.RecoDb.GeneralSetting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnGeneralSettingUpdated(Models.RecoDb.GeneralSetting item);
        partial void OnAfterGeneralSettingUpdated(Models.RecoDb.GeneralSetting item);

        public async Task<Models.RecoDb.GeneralSetting> UpdateGeneralSetting(Guid? id, Models.RecoDb.GeneralSetting generalSetting)
        {
            OnGeneralSettingUpdated(generalSetting);

            var itemToUpdate = Context.GeneralSettings
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(generalSetting);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterGeneralSettingUpdated(generalSetting);

            return generalSetting;
        }

        partial void OnInsuredDeleted(Models.RecoDb.Insured item);
        partial void OnAfterInsuredDeleted(Models.RecoDb.Insured item);

        public async Task<Models.RecoDb.Insured> DeleteInsured(Guid? id)
        {
            var itemToDelete = Context.Insureds
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInsuredDeleted(itemToDelete);

            Context.Insureds.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInsuredDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInsuredGet(Models.RecoDb.Insured item);

        public async Task<Models.RecoDb.Insured> GetInsuredById(Guid? id)
        {
            var items = Context.Insureds
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Brokerage);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnInsuredGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Insured> CancelInsuredChanges(Models.RecoDb.Insured item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInsuredUpdated(Models.RecoDb.Insured item);
        partial void OnAfterInsuredUpdated(Models.RecoDb.Insured item);

        public async Task<Models.RecoDb.Insured> UpsertInsured(Guid? id, Models.RecoDb.Insured insured)
        {
            OnInsuredUpdated(insured);

            var itemToUpdate = Context.Insureds
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
                Context.Add(insured);
            }
            else
            {
                var entryToUpdate = Context.Entry(itemToUpdate);
                entryToUpdate.CurrentValues.SetValues(insured);
                entryToUpdate.State = EntityState.Modified;
            }
            Context.SaveChanges();       

            OnAfterInsuredUpdated(insured);

            return insured;
        }

        partial void OnInsuredLitigationRoleDeleted(Models.RecoDb.InsuredLitigationRole item);
        partial void OnAfterInsuredLitigationRoleDeleted(Models.RecoDb.InsuredLitigationRole item);

        public async Task<Models.RecoDb.InsuredLitigationRole> DeleteInsuredLitigationRole(int? insuredId, int? litigationRoleId)
        {
            var itemToDelete = Context.InsuredLitigationRoles
                              .Where(i => i.InsuredID == insuredId && i.LitigationRoleID == litigationRoleId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInsuredLitigationRoleDeleted(itemToDelete);

            Context.InsuredLitigationRoles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInsuredLitigationRoleDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInsuredLitigationRoleGet(Models.RecoDb.InsuredLitigationRole item);

        public async Task<Models.RecoDb.InsuredLitigationRole> GetInsuredLitigationRoleByInsuredIdAndLitigationRoleId(int? insuredId, int? litigationRoleId)
        {
            var items = Context.InsuredLitigationRoles
                              .AsNoTracking()
                              .Where(i => i.InsuredID == insuredId && i.LitigationRoleID == litigationRoleId);

            items = items.Include(i => i.Insured);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnInsuredLitigationRoleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.InsuredLitigationRole> CancelInsuredLitigationRoleChanges(Models.RecoDb.InsuredLitigationRole item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInsuredLitigationRoleUpdated(Models.RecoDb.InsuredLitigationRole item);
        partial void OnAfterInsuredLitigationRoleUpdated(Models.RecoDb.InsuredLitigationRole item);

        public async Task<Models.RecoDb.InsuredLitigationRole> UpdateInsuredLitigationRole(int? insuredId, int? litigationRoleId, Models.RecoDb.InsuredLitigationRole insuredLitigationRole)
        {
            OnInsuredLitigationRoleUpdated(insuredLitigationRole);

            var itemToUpdate = Context.InsuredLitigationRoles
                              .Where(i => i.InsuredID == insuredId && i.LitigationRoleID == litigationRoleId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(insuredLitigationRole);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterInsuredLitigationRoleUpdated(insuredLitigationRole);

            return insuredLitigationRole;
        }

        partial void OnInvoiceUploadDeleted(Models.RecoDb.InvoiceUpload item);
        partial void OnAfterInvoiceUploadDeleted(Models.RecoDb.InvoiceUpload item);

        public async Task<Models.RecoDb.InvoiceUpload> DeleteInvoiceUpload(int? invoiceUploadId)
        {
            var itemToDelete = Context.InvoiceUploads
                              .Where(i => i.InvoiceUploadID == invoiceUploadId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInvoiceUploadDeleted(itemToDelete);

            Context.InvoiceUploads.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInvoiceUploadDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInvoiceUploadGet(Models.RecoDb.InvoiceUpload item);

        public async Task<Models.RecoDb.InvoiceUpload> GetInvoiceUploadByInvoiceUploadId(int? invoiceUploadId)
        {
            var items = Context.InvoiceUploads
                              .AsNoTracking()
                              .Where(i => i.InvoiceUploadID == invoiceUploadId);

            var itemToReturn = items.FirstOrDefault();

            OnInvoiceUploadGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.InvoiceUpload> CancelInvoiceUploadChanges(Models.RecoDb.InvoiceUpload item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInvoiceUploadUpdated(Models.RecoDb.InvoiceUpload item);
        partial void OnAfterInvoiceUploadUpdated(Models.RecoDb.InvoiceUpload item);

        public async Task<Models.RecoDb.InvoiceUpload> UpdateInvoiceUpload(int? invoiceUploadId, Models.RecoDb.InvoiceUpload invoiceUpload)
        {
            OnInvoiceUploadUpdated(invoiceUpload);

            var itemToUpdate = Context.InvoiceUploads
                              .Where(i => i.InvoiceUploadID == invoiceUploadId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(invoiceUpload);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterInvoiceUploadUpdated(invoiceUpload);

            return invoiceUpload;
        }

        partial void OnInvoiceUploadFileDeleted(Models.RecoDb.InvoiceUploadFile item);
        partial void OnAfterInvoiceUploadFileDeleted(Models.RecoDb.InvoiceUploadFile item);

        public async Task<Models.RecoDb.InvoiceUploadFile> DeleteInvoiceUploadFile(int? fileId)
        {
            var itemToDelete = Context.InvoiceUploadFiles
                              .Where(i => i.FileID == fileId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInvoiceUploadFileDeleted(itemToDelete);

            Context.InvoiceUploadFiles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInvoiceUploadFileDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInvoiceUploadFileGet(Models.RecoDb.InvoiceUploadFile item);

        public async Task<Models.RecoDb.InvoiceUploadFile> GetInvoiceUploadFileByFileId(int? fileId)
        {
            var items = Context.InvoiceUploadFiles
                              .AsNoTracking()
                              .Where(i => i.FileID == fileId);

            items = items.Include(i => i.Firm);

            var itemToReturn = items.FirstOrDefault();

            OnInvoiceUploadFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.InvoiceUploadFile> CancelInvoiceUploadFileChanges(Models.RecoDb.InvoiceUploadFile item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInvoiceUploadFileUpdated(Models.RecoDb.InvoiceUploadFile item);
        partial void OnAfterInvoiceUploadFileUpdated(Models.RecoDb.InvoiceUploadFile item);

        public async Task<Models.RecoDb.InvoiceUploadFile> UpdateInvoiceUploadFile(int? fileId, Models.RecoDb.InvoiceUploadFile invoiceUploadFile)
        {
            OnInvoiceUploadFileUpdated(invoiceUploadFile);

            var itemToUpdate = Context.InvoiceUploadFiles
                              .Where(i => i.FileID == fileId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(invoiceUploadFile);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterInvoiceUploadFileUpdated(invoiceUploadFile);

            return invoiceUploadFile;
        }

        partial void OnInvoiceUploadRowErrorDeleted(Models.RecoDb.InvoiceUploadRowError item);
        partial void OnAfterInvoiceUploadRowErrorDeleted(Models.RecoDb.InvoiceUploadRowError item);

        public async Task<Models.RecoDb.InvoiceUploadRowError> DeleteInvoiceUploadRowError(int? errorId)
        {
            var itemToDelete = Context.InvoiceUploadRowErrors
                              .Where(i => i.ErrorID == errorId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnInvoiceUploadRowErrorDeleted(itemToDelete);

            Context.InvoiceUploadRowErrors.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterInvoiceUploadRowErrorDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnInvoiceUploadRowErrorGet(Models.RecoDb.InvoiceUploadRowError item);

        public async Task<Models.RecoDb.InvoiceUploadRowError> GetInvoiceUploadRowErrorByErrorId(int? errorId)
        {
            var items = Context.InvoiceUploadRowErrors
                              .AsNoTracking()
                              .Where(i => i.ErrorID == errorId);

            var itemToReturn = items.FirstOrDefault();

            OnInvoiceUploadRowErrorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.InvoiceUploadRowError> CancelInvoiceUploadRowErrorChanges(Models.RecoDb.InvoiceUploadRowError item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnInvoiceUploadRowErrorUpdated(Models.RecoDb.InvoiceUploadRowError item);
        partial void OnAfterInvoiceUploadRowErrorUpdated(Models.RecoDb.InvoiceUploadRowError item);

        public async Task<Models.RecoDb.InvoiceUploadRowError> UpdateInvoiceUploadRowError(int? errorId, Models.RecoDb.InvoiceUploadRowError invoiceUploadRowError)
        {
            OnInvoiceUploadRowErrorUpdated(invoiceUploadRowError);

            var itemToUpdate = Context.InvoiceUploadRowErrors
                              .Where(i => i.ErrorID == errorId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(invoiceUploadRowError);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterInvoiceUploadRowErrorUpdated(invoiceUploadRowError);

            return invoiceUploadRowError;
        }

        partial void OnIssueReportingDeleted(Models.RecoDb.IssueReporting item);
        partial void OnAfterIssueReportingDeleted(Models.RecoDb.IssueReporting item);

        public async Task<Models.RecoDb.IssueReporting> DeleteIssueReporting(int? issueReportingId)
        {
            var itemToDelete = Context.IssueReportings
                              .Where(i => i.IssueReportingID == issueReportingId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnIssueReportingDeleted(itemToDelete);

            Context.IssueReportings.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterIssueReportingDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnIssueReportingGet(Models.RecoDb.IssueReporting item);

        public async Task<Models.RecoDb.IssueReporting> GetIssueReportingByIssueReportingId(int? issueReportingId)
        {
            var items = Context.IssueReportings
                              .AsNoTracking()
                              .Where(i => i.IssueReportingID == issueReportingId);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnIssueReportingGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.IssueReporting> CancelIssueReportingChanges(Models.RecoDb.IssueReporting item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnIssueReportingUpdated(Models.RecoDb.IssueReporting item);
        partial void OnAfterIssueReportingUpdated(Models.RecoDb.IssueReporting item);

        public async Task<Models.RecoDb.IssueReporting> UpdateIssueReporting(int? issueReportingId, Models.RecoDb.IssueReporting issueReporting)
        {
            OnIssueReportingUpdated(issueReporting);

            var itemToUpdate = Context.IssueReportings
                              .Where(i => i.IssueReportingID == issueReportingId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(issueReporting);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterIssueReportingUpdated(issueReporting);

            return issueReporting;
        }

        partial void OnLossCauseTagDeleted(Models.RecoDb.LossCauseTag item);
        partial void OnAfterLossCauseTagDeleted(Models.RecoDb.LossCauseTag item);

        public async Task<Models.RecoDb.LossCauseTag> DeleteLossCauseTag(int? claimId, string lossCauseTag1)
        {
            var itemToDelete = Context.LossCauseTags
                              .Where(i => i.ClaimID == claimId && i.LossCauseTag1 == lossCauseTag1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnLossCauseTagDeleted(itemToDelete);

            Context.LossCauseTags.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterLossCauseTagDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnLossCauseTagGet(Models.RecoDb.LossCauseTag item);

        public async Task<Models.RecoDb.LossCauseTag> GetLossCauseTagByClaimIdAndLossCauseTag1(int? claimId, string lossCauseTag1)
        {
            var items = Context.LossCauseTags
                              .AsNoTracking()
                              .Where(i => i.ClaimID == claimId && i.LossCauseTag1 == lossCauseTag1);

            items = items.Include(i => i.Claim);

            var itemToReturn = items.FirstOrDefault();

            OnLossCauseTagGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.LossCauseTag> CancelLossCauseTagChanges(Models.RecoDb.LossCauseTag item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnLossCauseTagUpdated(Models.RecoDb.LossCauseTag item);
        partial void OnAfterLossCauseTagUpdated(Models.RecoDb.LossCauseTag item);

        public async Task<Models.RecoDb.LossCauseTag> UpdateLossCauseTag(int? claimId, string lossCauseTag1, Models.RecoDb.LossCauseTag lossCauseTag)
        {
            OnLossCauseTagUpdated(lossCauseTag);

            var itemToUpdate = Context.LossCauseTags
                              .Where(i => i.ClaimID == claimId && i.LossCauseTag1 == lossCauseTag1)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(lossCauseTag);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterLossCauseTagUpdated(lossCauseTag);

            return lossCauseTag;
        }

        partial void OnNoteDeleted(Models.RecoDb.Note item);
        partial void OnAfterNoteDeleted(Models.RecoDb.Note item);

        public async Task<Models.RecoDb.Note> DeleteNote(Guid? id)
        {
            var itemToDelete = Context.Notes
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoteDeleted(itemToDelete);

            Context.Notes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoteDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoteGet(Models.RecoDb.Note item);

        public async Task<Models.RecoDb.Note> GetNoteById(Guid? id)
        {
            var items = Context.Notes
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnNoteGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Note> CancelNoteChanges(Models.RecoDb.Note item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoteUpdated(Models.RecoDb.Note item);
        partial void OnAfterNoteUpdated(Models.RecoDb.Note item);

        public async Task<Models.RecoDb.Note> UpdateNote(Guid? id, Models.RecoDb.Note note)
        {
            OnNoteUpdated(note);

            var itemToUpdate = Context.Notes
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(note);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoteUpdated(note);

            return note;
        }

        partial void OnNoteRoleDeleted(Models.RecoDb.NoteRole item);
        partial void OnAfterNoteRoleDeleted(Models.RecoDb.NoteRole item);

        public async Task<Models.RecoDb.NoteRole> DeleteNoteRole(int? id)
        {
            var itemToDelete = Context.NoteRoles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoteRoleDeleted(itemToDelete);

            Context.NoteRoles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoteRoleDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoteRoleGet(Models.RecoDb.NoteRole item);

        public async Task<Models.RecoDb.NoteRole> GetNoteRoleById(int? id)
        {
            var items = Context.NoteRoles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            items = items.Include(i => i.Note);

            items = items.Include(i => i.Role);

            var itemToReturn = items.FirstOrDefault();

            OnNoteRoleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoteRole> CancelNoteRoleChanges(Models.RecoDb.NoteRole item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoteRoleUpdated(Models.RecoDb.NoteRole item);
        partial void OnAfterNoteRoleUpdated(Models.RecoDb.NoteRole item);

        public async Task<Models.RecoDb.NoteRole> UpdateNoteRole(int? id, Models.RecoDb.NoteRole noteRole)
        {
            OnNoteRoleUpdated(noteRole);

            var itemToUpdate = Context.NoteRoles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noteRole);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoteRoleUpdated(noteRole);

            return noteRole;
        }

        partial void OnNoticeOfClaimDeleted(Models.RecoDb.NoticeOfClaim item);
        partial void OnAfterNoticeOfClaimDeleted(Models.RecoDb.NoticeOfClaim item);

        public async Task<Models.RecoDb.NoticeOfClaim> DeleteNoticeOfClaim(int? noticeOfClaimId)
        {
            var itemToDelete = Context.NoticeOfClaims
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId)
                              .Include(i => i.EoNoticeOfClaimsDetails)
                              .Include(i => i.NoticeOfClaimTrades)
                              .Include(i => i.NoticeOfClaimBrokerages)
                              .Include(i => i.NoticeOfClaimClaimants)
                              .Include(i => i.NoticeOfClaimRegistrants)
                              .Include(i => i.NoticeOfClaimFiles)
                              .Include(i => i.NoticeOfClaimPurchasers)
                              .Include(i => i.NoticeOfClaimVendors)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoticeOfClaimDeleted(itemToDelete);

            Context.NoticeOfClaims.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoticeOfClaimDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoticeOfClaimGet(Models.RecoDb.NoticeOfClaim item);

        public async Task<Models.RecoDb.NoticeOfClaim> GetNoticeOfClaimByNoticeOfClaimId(int? noticeOfClaimId)
        {
            var items = Context.NoticeOfClaims
                              .AsNoTracking()
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Claim);

            var itemToReturn = items.FirstOrDefault();

            OnNoticeOfClaimGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoticeOfClaim> CancelNoticeOfClaimChanges(Models.RecoDb.NoticeOfClaim item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoticeOfClaimUpdated(Models.RecoDb.NoticeOfClaim item);
        partial void OnAfterNoticeOfClaimUpdated(Models.RecoDb.NoticeOfClaim item);

        public async Task<Models.RecoDb.NoticeOfClaim> UpdateNoticeOfClaim(int? noticeOfClaimId, Models.RecoDb.NoticeOfClaim noticeOfClaim)
        {
            OnNoticeOfClaimUpdated(noticeOfClaim);

            var itemToUpdate = Context.NoticeOfClaims
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noticeOfClaim);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoticeOfClaimUpdated(noticeOfClaim);

            return noticeOfClaim;
        }

        partial void OnNoticeOfClaimBrokerageDeleted(Models.RecoDb.NoticeOfClaimBrokerage item);
        partial void OnAfterNoticeOfClaimBrokerageDeleted(Models.RecoDb.NoticeOfClaimBrokerage item);

        public async Task<Models.RecoDb.NoticeOfClaimBrokerage> DeleteNoticeOfClaimBrokerage(int? brokerageId)
        {
            var itemToDelete = Context.NoticeOfClaimBrokerages
                              .Where(i => i.BrokerageID == brokerageId)
                              .Include(i => i.NoticeOfClaimRegistrants)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoticeOfClaimBrokerageDeleted(itemToDelete);

            Context.NoticeOfClaimBrokerages.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoticeOfClaimBrokerageDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoticeOfClaimBrokerageGet(Models.RecoDb.NoticeOfClaimBrokerage item);

        public async Task<Models.RecoDb.NoticeOfClaimBrokerage> GetNoticeOfClaimBrokerageByBrokerageId(int? brokerageId)
        {
            var items = Context.NoticeOfClaimBrokerages
                              .AsNoTracking()
                              .Where(i => i.BrokerageID == brokerageId);

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnNoticeOfClaimBrokerageGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoticeOfClaimBrokerage> CancelNoticeOfClaimBrokerageChanges(Models.RecoDb.NoticeOfClaimBrokerage item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoticeOfClaimBrokerageUpdated(Models.RecoDb.NoticeOfClaimBrokerage item);
        partial void OnAfterNoticeOfClaimBrokerageUpdated(Models.RecoDb.NoticeOfClaimBrokerage item);

        public async Task<Models.RecoDb.NoticeOfClaimBrokerage> UpdateNoticeOfClaimBrokerage(int? brokerageId, Models.RecoDb.NoticeOfClaimBrokerage noticeOfClaimBrokerage)
        {
            OnNoticeOfClaimBrokerageUpdated(noticeOfClaimBrokerage);

            var itemToUpdate = Context.NoticeOfClaimBrokerages
                              .Where(i => i.BrokerageID == brokerageId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noticeOfClaimBrokerage);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoticeOfClaimBrokerageUpdated(noticeOfClaimBrokerage);

            return noticeOfClaimBrokerage;
        }

        partial void OnNoticeOfClaimClaimantDeleted(Models.RecoDb.NoticeOfClaimClaimant item);
        partial void OnAfterNoticeOfClaimClaimantDeleted(Models.RecoDb.NoticeOfClaimClaimant item);

        public async Task<Models.RecoDb.NoticeOfClaimClaimant> DeleteNoticeOfClaimClaimant(int? id)
        {
            var itemToDelete = Context.NoticeOfClaimClaimants
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoticeOfClaimClaimantDeleted(itemToDelete);

            Context.NoticeOfClaimClaimants.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoticeOfClaimClaimantDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoticeOfClaimClaimantGet(Models.RecoDb.NoticeOfClaimClaimant item);

        public async Task<Models.RecoDb.NoticeOfClaimClaimant> GetNoticeOfClaimClaimantById(int? id)
        {
            var items = Context.NoticeOfClaimClaimants
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.NoticeOfClaim);

            var itemToReturn = items.FirstOrDefault();

            OnNoticeOfClaimClaimantGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoticeOfClaimClaimant> CancelNoticeOfClaimClaimantChanges(Models.RecoDb.NoticeOfClaimClaimant item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoticeOfClaimClaimantUpdated(Models.RecoDb.NoticeOfClaimClaimant item);
        partial void OnAfterNoticeOfClaimClaimantUpdated(Models.RecoDb.NoticeOfClaimClaimant item);

        public async Task<Models.RecoDb.NoticeOfClaimClaimant> UpdateNoticeOfClaimClaimant(int? id, Models.RecoDb.NoticeOfClaimClaimant noticeOfClaimClaimant)
        {
            OnNoticeOfClaimClaimantUpdated(noticeOfClaimClaimant);

            var itemToUpdate = Context.NoticeOfClaimClaimants
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noticeOfClaimClaimant);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoticeOfClaimClaimantUpdated(noticeOfClaimClaimant);

            return noticeOfClaimClaimant;
        }

        partial void OnNoticeOfClaimFileDeleted(Models.RecoDb.NoticeOfClaimFile item);
        partial void OnAfterNoticeOfClaimFileDeleted(Models.RecoDb.NoticeOfClaimFile item);

        public async Task<Models.RecoDb.NoticeOfClaimFile> DeleteNoticeOfClaimFile(int? fileId)
        {
            var itemToDelete = Context.NoticeOfClaimFiles
                              .Where(i => i.FileID == fileId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoticeOfClaimFileDeleted(itemToDelete);

            Context.NoticeOfClaimFiles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoticeOfClaimFileDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoticeOfClaimFileGet(Models.RecoDb.NoticeOfClaimFile item);

        public async Task<Models.RecoDb.NoticeOfClaimFile> GetNoticeOfClaimFileByFileId(int? fileId)
        {
            var items = Context.NoticeOfClaimFiles
                              .AsNoTracking()
                              .Where(i => i.FileID == fileId);

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnNoticeOfClaimFileGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoticeOfClaimFile> CancelNoticeOfClaimFileChanges(Models.RecoDb.NoticeOfClaimFile item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoticeOfClaimFileUpdated(Models.RecoDb.NoticeOfClaimFile item);
        partial void OnAfterNoticeOfClaimFileUpdated(Models.RecoDb.NoticeOfClaimFile item);

        public async Task<Models.RecoDb.NoticeOfClaimFile> UpdateNoticeOfClaimFile(int? fileId, Models.RecoDb.NoticeOfClaimFile noticeOfClaimFile)
        {
            OnNoticeOfClaimFileUpdated(noticeOfClaimFile);

            var itemToUpdate = Context.NoticeOfClaimFiles
                              .Where(i => i.FileID == fileId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noticeOfClaimFile);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoticeOfClaimFileUpdated(noticeOfClaimFile);

            return noticeOfClaimFile;
        }

        partial void OnNoticeOfClaimPurchaserDeleted(Models.RecoDb.NoticeOfClaimPurchaser item);
        partial void OnAfterNoticeOfClaimPurchaserDeleted(Models.RecoDb.NoticeOfClaimPurchaser item);

        public async Task<Models.RecoDb.NoticeOfClaimPurchaser> DeleteNoticeOfClaimPurchaser(int? purchaserId)
        {
            var itemToDelete = Context.NoticeOfClaimPurchasers
                              .Where(i => i.PurchaserID == purchaserId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoticeOfClaimPurchaserDeleted(itemToDelete);

            Context.NoticeOfClaimPurchasers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoticeOfClaimPurchaserDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoticeOfClaimPurchaserGet(Models.RecoDb.NoticeOfClaimPurchaser item);

        public async Task<Models.RecoDb.NoticeOfClaimPurchaser> GetNoticeOfClaimPurchaserByPurchaserId(int? purchaserId)
        {
            var items = Context.NoticeOfClaimPurchasers
                              .AsNoTracking()
                              .Where(i => i.PurchaserID == purchaserId);

            items = items.Include(i => i.NoticeOfClaim);

            var itemToReturn = items.FirstOrDefault();

            OnNoticeOfClaimPurchaserGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoticeOfClaimPurchaser> CancelNoticeOfClaimPurchaserChanges(Models.RecoDb.NoticeOfClaimPurchaser item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoticeOfClaimPurchaserUpdated(Models.RecoDb.NoticeOfClaimPurchaser item);
        partial void OnAfterNoticeOfClaimPurchaserUpdated(Models.RecoDb.NoticeOfClaimPurchaser item);

        public async Task<Models.RecoDb.NoticeOfClaimPurchaser> UpdateNoticeOfClaimPurchaser(int? purchaserId, Models.RecoDb.NoticeOfClaimPurchaser noticeOfClaimPurchaser)
        {
            OnNoticeOfClaimPurchaserUpdated(noticeOfClaimPurchaser);

            var itemToUpdate = Context.NoticeOfClaimPurchasers
                              .Where(i => i.PurchaserID == purchaserId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noticeOfClaimPurchaser);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoticeOfClaimPurchaserUpdated(noticeOfClaimPurchaser);

            return noticeOfClaimPurchaser;
        }

        partial void OnNoticeOfClaimRegistrantDeleted(Models.RecoDb.NoticeOfClaimRegistrant item);
        partial void OnAfterNoticeOfClaimRegistrantDeleted(Models.RecoDb.NoticeOfClaimRegistrant item);

        public async Task<Models.RecoDb.NoticeOfClaimRegistrant> DeleteNoticeOfClaimRegistrant(int? nocRegistrantId)
        {
            var itemToDelete = Context.NoticeOfClaimRegistrants
                              .Where(i => i.NOCRegistrantID == nocRegistrantId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoticeOfClaimRegistrantDeleted(itemToDelete);

            Context.NoticeOfClaimRegistrants.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoticeOfClaimRegistrantDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoticeOfClaimRegistrantGet(Models.RecoDb.NoticeOfClaimRegistrant item);

        public async Task<Models.RecoDb.NoticeOfClaimRegistrant> GetNoticeOfClaimRegistrantByNocRegistrantId(int? nocRegistrantId)
        {
            var items = Context.NoticeOfClaimRegistrants
                              .AsNoTracking()
                              .Where(i => i.NOCRegistrantID == nocRegistrantId);

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.NoticeOfClaimBrokerage);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnNoticeOfClaimRegistrantGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoticeOfClaimRegistrant> CancelNoticeOfClaimRegistrantChanges(Models.RecoDb.NoticeOfClaimRegistrant item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoticeOfClaimRegistrantUpdated(Models.RecoDb.NoticeOfClaimRegistrant item);
        partial void OnAfterNoticeOfClaimRegistrantUpdated(Models.RecoDb.NoticeOfClaimRegistrant item);

        public async Task<Models.RecoDb.NoticeOfClaimRegistrant> UpdateNoticeOfClaimRegistrant(int? nocRegistrantId, Models.RecoDb.NoticeOfClaimRegistrant noticeOfClaimRegistrant)
        {
            OnNoticeOfClaimRegistrantUpdated(noticeOfClaimRegistrant);

            var itemToUpdate = Context.NoticeOfClaimRegistrants
                              .Where(i => i.NOCRegistrantID == nocRegistrantId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noticeOfClaimRegistrant);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoticeOfClaimRegistrantUpdated(noticeOfClaimRegistrant);

            return noticeOfClaimRegistrant;
        }

        partial void OnNoticeOfClaimTradeDeleted(Models.RecoDb.NoticeOfClaimTrade item);
        partial void OnAfterNoticeOfClaimTradeDeleted(Models.RecoDb.NoticeOfClaimTrade item);

        public async Task<Models.RecoDb.NoticeOfClaimTrade> DeleteNoticeOfClaimTrade(int? noticeOfClaimId)
        {
            var itemToDelete = Context.NoticeOfClaimTrades
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoticeOfClaimTradeDeleted(itemToDelete);

            Context.NoticeOfClaimTrades.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoticeOfClaimTradeDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoticeOfClaimTradeGet(Models.RecoDb.NoticeOfClaimTrade item);

        public async Task<Models.RecoDb.NoticeOfClaimTrade> GetNoticeOfClaimTradeByNoticeOfClaimId(int? noticeOfClaimId)
        {
            var items = Context.NoticeOfClaimTrades
                              .AsNoTracking()
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId);

            items = items.Include(i => i.NoticeOfClaim);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnNoticeOfClaimTradeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoticeOfClaimTrade> CancelNoticeOfClaimTradeChanges(Models.RecoDb.NoticeOfClaimTrade item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoticeOfClaimTradeUpdated(Models.RecoDb.NoticeOfClaimTrade item);
        partial void OnAfterNoticeOfClaimTradeUpdated(Models.RecoDb.NoticeOfClaimTrade item);

        public async Task<Models.RecoDb.NoticeOfClaimTrade> UpdateNoticeOfClaimTrade(int? noticeOfClaimId, Models.RecoDb.NoticeOfClaimTrade noticeOfClaimTrade)
        {
            OnNoticeOfClaimTradeUpdated(noticeOfClaimTrade);

            var itemToUpdate = Context.NoticeOfClaimTrades
                              .Where(i => i.NoticeOfClaimID == noticeOfClaimId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noticeOfClaimTrade);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoticeOfClaimTradeUpdated(noticeOfClaimTrade);

            return noticeOfClaimTrade;
        }

        partial void OnNoticeOfClaimVendorDeleted(Models.RecoDb.NoticeOfClaimVendor item);
        partial void OnAfterNoticeOfClaimVendorDeleted(Models.RecoDb.NoticeOfClaimVendor item);

        public async Task<Models.RecoDb.NoticeOfClaimVendor> DeleteNoticeOfClaimVendor(int? vendorId)
        {
            var itemToDelete = Context.NoticeOfClaimVendors
                              .Where(i => i.VendorID == vendorId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnNoticeOfClaimVendorDeleted(itemToDelete);

            Context.NoticeOfClaimVendors.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterNoticeOfClaimVendorDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnNoticeOfClaimVendorGet(Models.RecoDb.NoticeOfClaimVendor item);

        public async Task<Models.RecoDb.NoticeOfClaimVendor> GetNoticeOfClaimVendorByVendorId(int? vendorId)
        {
            var items = Context.NoticeOfClaimVendors
                              .AsNoTracking()
                              .Where(i => i.VendorID == vendorId);

            items = items.Include(i => i.NoticeOfClaim);

            var itemToReturn = items.FirstOrDefault();

            OnNoticeOfClaimVendorGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.NoticeOfClaimVendor> CancelNoticeOfClaimVendorChanges(Models.RecoDb.NoticeOfClaimVendor item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnNoticeOfClaimVendorUpdated(Models.RecoDb.NoticeOfClaimVendor item);
        partial void OnAfterNoticeOfClaimVendorUpdated(Models.RecoDb.NoticeOfClaimVendor item);

        public async Task<Models.RecoDb.NoticeOfClaimVendor> UpdateNoticeOfClaimVendor(int? vendorId, Models.RecoDb.NoticeOfClaimVendor noticeOfClaimVendor)
        {
            OnNoticeOfClaimVendorUpdated(noticeOfClaimVendor);

            var itemToUpdate = Context.NoticeOfClaimVendors
                              .Where(i => i.VendorID == vendorId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(noticeOfClaimVendor);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterNoticeOfClaimVendorUpdated(noticeOfClaimVendor);

            return noticeOfClaimVendor;
        }

        partial void OnOccurrenceDeleted(Models.RecoDb.Occurrence item);
        partial void OnAfterOccurrenceDeleted(Models.RecoDb.Occurrence item);

        public async Task<Models.RecoDb.Occurrence> DeleteOccurrence(Guid? id)
        {
            var itemToDelete = Context.Occurrences
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOccurrenceDeleted(itemToDelete);

            Context.Occurrences.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOccurrenceDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnOccurrenceGet(Models.RecoDb.Occurrence item);

        public async Task<Models.RecoDb.Occurrence> GetOccurrenceById(Guid? id)
        {
            var items = Context.Occurrences
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Brokerage);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.Receiver);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Parameter3);

            var itemToReturn = items.FirstOrDefault();

            OnOccurrenceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Occurrence> CancelOccurrenceChanges(Models.RecoDb.Occurrence item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOccurrenceUpdated(Models.RecoDb.Occurrence item);
        partial void OnAfterOccurrenceUpdated(Models.RecoDb.Occurrence item);

        public async Task<Models.RecoDb.Occurrence> UpdateOccurrence(Guid? id, Models.RecoDb.Occurrence occurrence)
        {
            OnOccurrenceUpdated(occurrence);

            var itemToUpdate = Context.Occurrences
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(occurrence);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterOccurrenceUpdated(occurrence);

            return occurrence;
        }

        partial void OnOtherPartyDeleted(Models.RecoDb.OtherParty item);
        partial void OnAfterOtherPartyDeleted(Models.RecoDb.OtherParty item);

        public async Task<Models.RecoDb.OtherParty> DeleteOtherParty(Guid? id)
        {
            var itemToDelete = Context.OtherParties
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnOtherPartyDeleted(itemToDelete);

            Context.OtherParties.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterOtherPartyDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnOtherPartyGet(Models.RecoDb.OtherParty item);

        public async Task<Models.RecoDb.OtherParty> GetOtherPartyById(Guid? id)
        {
            var items = Context.OtherParties
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Parameter3);

            items = items.Include(i => i.Brokerage);

            var itemToReturn = items.FirstOrDefault();

            OnOtherPartyGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.OtherParty> CancelOtherPartyChanges(Models.RecoDb.OtherParty item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnOtherPartyUpdated(Models.RecoDb.OtherParty item);
        partial void OnAfterOtherPartyUpdated(Models.RecoDb.OtherParty item);

        public async Task<Models.RecoDb.OtherParty> UpdateOtherParty(Guid? id, Models.RecoDb.OtherParty otherParty)
        {
            OnOtherPartyUpdated(otherParty);

            var itemToUpdate = Context.OtherParties
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(otherParty);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterOtherPartyUpdated(otherParty);

            return otherParty;
        }

        partial void OnParamTypeDeleted(Models.RecoDb.ParamType item);
        partial void OnAfterParamTypeDeleted(Models.RecoDb.ParamType item);

        public async Task<Models.RecoDb.ParamType> DeleteParamType(int? paramTypeId)
        {
            var itemToDelete = Context.ParamTypes
                              .Where(i => i.ParamTypeID == paramTypeId)
                              .Include(i => i.ParamTypes1)
                              .Include(i => i.Parameters)
                              .Include(i => i.Parameters1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnParamTypeDeleted(itemToDelete);

            Context.ParamTypes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterParamTypeDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnParamTypeGet(Models.RecoDb.ParamType item);

        public async Task<Models.RecoDb.ParamType> GetParamTypeByParamTypeId(int? paramTypeId)
        {
            var items = Context.ParamTypes
                              .AsNoTracking()
                              .Where(i => i.ParamTypeID == paramTypeId);

            items = items.Include(i => i.ParamType1);

            var itemToReturn = items.FirstOrDefault();

            OnParamTypeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ParamType> CancelParamTypeChanges(Models.RecoDb.ParamType item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnParamTypeUpdated(Models.RecoDb.ParamType item);
        partial void OnAfterParamTypeUpdated(Models.RecoDb.ParamType item);

        public async Task<Models.RecoDb.ParamType> UpdateParamType(int? paramTypeId, Models.RecoDb.ParamType paramType)
        {
            OnParamTypeUpdated(paramType);

            var itemToUpdate = Context.ParamTypes
                              .Where(i => i.ParamTypeID == paramTypeId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(paramType);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterParamTypeUpdated(paramType);

            return paramType;
        }

        partial void OnParameterDeleted(Models.RecoDb.Parameter item);
        partial void OnAfterParameterDeleted(Models.RecoDb.Parameter item);

        public async Task<Models.RecoDb.Parameter> DeleteParameter(int? parameterId)
        {
            var itemToDelete = Context.Parameters
                              .Where(i => i.ParameterID == parameterId)
                              .Include(i => i.Diaries)
                              .Include(i => i.Claimants)
                              .Include(i => i.Claimants1)
                              .Include(i => i.Claimants2)
                              .Include(i => i.EoNoticeOfClaimsDetails)
                              .Include(i => i.Experts)
                              .Include(i => i.Experts1)
                              .Include(i => i.Experts2)
                              .Include(i => i.ServiceProviders)
                              .Include(i => i.ServiceProviders1)
                              .Include(i => i.ServiceProviders2)
                              .Include(i => i.ClaimantLitigationRoles)
                              .Include(i => i.Trades)
                              .Include(i => i.Trades1)
                              .Include(i => i.Trades2)
                              .Include(i => i.Trades3)
                              .Include(i => i.Trades4)
                              .Include(i => i.Trades5)
                              .Include(i => i.Trades6)
                              .Include(i => i.Trades7)
                              .Include(i => i.Brokerages)
                              .Include(i => i.Notes)
                              .Include(i => i.BrokerageContacts)
                              .Include(i => i.ClaimStatusHistories)
                              .Include(i => i.Transactions)
                              .Include(i => i.Transactions1)
                              .Include(i => i.Transactions2)
                              .Include(i => i.ClaimReports)
                              .Include(i => i.Occurrences)
                              .Include(i => i.Occurrences1)
                              .Include(i => i.Occurrences2)
                              .Include(i => i.Occurrences3)
                              .Include(i => i.NoticeOfClaims)
                              .Include(i => i.NoticeOfClaims1)
                              .Include(i => i.TransactionApprovalLimits)
                              .Include(i => i.DiaryTemplates)
                              .Include(i => i.DiaryTemplates1)
                              .Include(i => i.Insureds)
                              .Include(i => i.Insureds1)
                              .Include(i => i.Claims)
                              .Include(i => i.Claims1)
                              .Include(i => i.Claims2)
                              .Include(i => i.Claims3)
                              .Include(i => i.Claims4)
                              .Include(i => i.Claims5)
                              .Include(i => i.Claims6)
                              .Include(i => i.Claims7)
                              .Include(i => i.Claims8)
                              .Include(i => i.Claims9)
                              .Include(i => i.Claims10)
                              .Include(i => i.CdpClaimDetails)
                              .Include(i => i.CdpClaimDetails1)
                              .Include(i => i.ClaimLitigationDates)
                              .Include(i => i.ClaimLitigationDates1)
                              .Include(i => i.AutoReservings)
                              .Include(i => i.AutoReservings1)
                              .Include(i => i.Builders)
                              .Include(i => i.Builders1)
                              .Include(i => i.PostalCodes)
                              .Include(i => i.Registrants)
                              .Include(i => i.Registrants1)
                              .Include(i => i.Firms)
                              .Include(i => i.ClaimantSolicitors)
                              .Include(i => i.ClaimantSolicitors1)
                              .Include(i => i.SentLetters)
                              .Include(i => i.NoticeOfClaimTrades)
                              .Include(i => i.NoticeOfClaimBrokerages)
                              .Include(i => i.NoticeOfClaimBrokerages1)
                              .Include(i => i.InsuredLitigationRoles)
                              .Include(i => i.Administrators)
                              .Include(i => i.Administrators1)
                              .Include(i => i.NoticeOfClaimRegistrants)
                              .Include(i => i.NoticeOfClaimRegistrants1)
                              .Include(i => i.EoClaimDetails)
                              .Include(i => i.EoClaimDetails1)
                              .Include(i => i.EoClaimDetails2)
                              .Include(i => i.EoClaimDetails3)
                              .Include(i => i.EoClaimDetails4)
                              .Include(i => i.EoClaimDetails5)
                              .Include(i => i.EoClaimDetails6)
                              .Include(i => i.EoClaimDetails7)
                              .Include(i => i.EoClaimDetails8)
                              .Include(i => i.EoClaimDetails9)
                              .Include(i => i.EoClaimDetails10)
                              .Include(i => i.EoClaimDetails11)
                              .Include(i => i.EoClaimDetails12)
                              .Include(i => i.EoClaimDetails13)
                              .Include(i => i.EoClaimDetails14)
                              .Include(i => i.EoClaimDetails15)
                              .Include(i => i.EoClaimDetails16)
                              .Include(i => i.CourtDates)
                              .Include(i => i.OtherParties)
                              .Include(i => i.OtherParties1)
                              .Include(i => i.OtherParties2)
                              .Include(i => i.OtherParties3)
                              .Include(i => i.NoticeOfClaimFiles)
                              .Include(i => i.IssueReportings)
                              .Include(i => i.Receivers)
                              .Include(i => i.Receivers1)
                              .Include(i => i.Appointments)
                              .Include(i => i.Appointments1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnParameterDeleted(itemToDelete);

            Context.Parameters.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterParameterDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnParameterGet(Models.RecoDb.Parameter item);

        public async Task<Models.RecoDb.Parameter> GetParameterByParameterId(int? parameterId)
        {
            var items = Context.Parameters
                              .AsNoTracking()
                              .Where(i => i.ParameterID == parameterId);

            items = items.Include(i => i.ParamType);

            items = items.Include(i => i.ParamType1);

            var itemToReturn = items.FirstOrDefault();

            OnParameterGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Parameter> CancelParameterChanges(Models.RecoDb.Parameter item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnParameterUpdated(Models.RecoDb.Parameter item);
        partial void OnAfterParameterUpdated(Models.RecoDb.Parameter item);

        public async Task<Models.RecoDb.Parameter> UpdateParameter(int? parameterId, Models.RecoDb.Parameter parameter)
        {
            OnParameterUpdated(parameter);

            var itemToUpdate = Context.Parameters
                              .Where(i => i.ParameterID == parameterId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(parameter);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterParameterUpdated(parameter);

            return parameter;
        }

        partial void OnPostalCodeDeleted(Models.RecoDb.PostalCode item);
        partial void OnAfterPostalCodeDeleted(Models.RecoDb.PostalCode item);

        public async Task<Models.RecoDb.PostalCode> DeletePostalCode(string postalCode1)
        {
            var itemToDelete = Context.PostalCodes
                              .Where(i => i.PostalCode1 == postalCode1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnPostalCodeDeleted(itemToDelete);

            Context.PostalCodes.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterPostalCodeDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnPostalCodeGet(Models.RecoDb.PostalCode item);

        public async Task<Models.RecoDb.PostalCode> GetPostalCodeByPostalCode1(string postalCode1)
        {
            var items = Context.PostalCodes
                              .AsNoTracking()
                              .Where(i => i.PostalCode1 == postalCode1);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnPostalCodeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.PostalCode> CancelPostalCodeChanges(Models.RecoDb.PostalCode item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnPostalCodeUpdated(Models.RecoDb.PostalCode item);
        partial void OnAfterPostalCodeUpdated(Models.RecoDb.PostalCode item);

        public async Task<Models.RecoDb.PostalCode> UpdatePostalCode(string postalCode1, Models.RecoDb.PostalCode postalCode)
        {
            OnPostalCodeUpdated(postalCode);

            var itemToUpdate = Context.PostalCodes
                              .Where(i => i.PostalCode1 == postalCode1)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(postalCode);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterPostalCodeUpdated(postalCode);

            return postalCode;
        }

        partial void OnReceiverDeleted(Models.RecoDb.Receiver item);
        partial void OnAfterReceiverDeleted(Models.RecoDb.Receiver item);

        public async Task<Models.RecoDb.Receiver> DeleteReceiver(Guid? id)
        {
            var itemToDelete = Context.Receivers
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnReceiverDeleted(itemToDelete);

            Context.Receivers.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterReceiverDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnReceiverGet(Models.RecoDb.Receiver item);

        public async Task<Models.RecoDb.Receiver> GetReceiverById(Guid? id)
        {
            var items = Context.Receivers
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            var itemToReturn = items.FirstOrDefault();

            OnReceiverGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Receiver> CancelReceiverChanges(Models.RecoDb.Receiver item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnReceiverUpdated(Models.RecoDb.Receiver item);
        partial void OnAfterReceiverUpdated(Models.RecoDb.Receiver item);

        public async Task<Models.RecoDb.Receiver> UpdateReceiver(Guid? id, Models.RecoDb.Receiver receiver)
        {
            OnReceiverUpdated(receiver);

            var itemToUpdate = Context.Receivers
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(receiver);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterReceiverUpdated(receiver);

            return receiver;
        }

        partial void OnRefactorLogDeleted(Models.RecoDb.RefactorLog item);
        partial void OnAfterRefactorLogDeleted(Models.RecoDb.RefactorLog item);

        public async Task<Models.RecoDb.RefactorLog> DeleteRefactorLog(Guid? operationKey)
        {
            var itemToDelete = Context.RefactorLogs
                              .Where(i => i.OperationKey == operationKey)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRefactorLogDeleted(itemToDelete);

            Context.RefactorLogs.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRefactorLogDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnRefactorLogGet(Models.RecoDb.RefactorLog item);

        public async Task<Models.RecoDb.RefactorLog> GetRefactorLogByOperationKey(Guid? operationKey)
        {
            var items = Context.RefactorLogs
                              .AsNoTracking()
                              .Where(i => i.OperationKey == operationKey);

            var itemToReturn = items.FirstOrDefault();

            OnRefactorLogGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.RefactorLog> CancelRefactorLogChanges(Models.RecoDb.RefactorLog item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRefactorLogUpdated(Models.RecoDb.RefactorLog item);
        partial void OnAfterRefactorLogUpdated(Models.RecoDb.RefactorLog item);

        public async Task<Models.RecoDb.RefactorLog> UpdateRefactorLog(Guid? operationKey, Models.RecoDb.RefactorLog refactorLog)
        {
            OnRefactorLogUpdated(refactorLog);

            var itemToUpdate = Context.RefactorLogs
                              .Where(i => i.OperationKey == operationKey)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(refactorLog);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterRefactorLogUpdated(refactorLog);

            return refactorLog;
        }

        partial void OnRegistrantDeleted(Models.RecoDb.Registrant item);
        partial void OnAfterRegistrantDeleted(Models.RecoDb.Registrant item);

        public async Task<Models.RecoDb.Registrant> DeleteRegistrant(Guid? id)
        {
            var itemToDelete = Context.Registrants
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRegistrantDeleted(itemToDelete);

            Context.Registrants.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRegistrantDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnRegistrantGet(Models.RecoDb.Registrant item);

        public async Task<Models.RecoDb.Registrant> GetRegistrantById(Guid? id)
        {
            var items = Context.Registrants
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Brokerage);

            var itemToReturn = items.FirstOrDefault();

            OnRegistrantGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Registrant> CancelRegistrantChanges(Models.RecoDb.Registrant item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRegistrantUpdated(Models.RecoDb.Registrant item);
        partial void OnAfterRegistrantUpdated(Models.RecoDb.Registrant item);

        public async Task<Models.RecoDb.Registrant> UpdateRegistrant(Guid? id, Models.RecoDb.Registrant registrant)
        {
            OnRegistrantUpdated(registrant);

            var itemToUpdate = Context.Registrants
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(registrant);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterRegistrantUpdated(registrant);

            return registrant;
        }

        partial void OnRoleDeleted(Models.RecoDb.Role item);
        partial void OnAfterRoleDeleted(Models.RecoDb.Role item);

        public async Task<Models.RecoDb.Role> DeleteRole(int? id)
        {
            var itemToDelete = Context.Roles
                              .Where(i => i.Id == id)
                              .Include(i => i.FilesRoles)
                              .Include(i => i.NoteRoles)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnRoleDeleted(itemToDelete);

            Context.Roles.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterRoleDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnRoleGet(Models.RecoDb.Role item);

        public async Task<Models.RecoDb.Role> GetRoleById(int? id)
        {
            var items = Context.Roles
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            var itemToReturn = items.FirstOrDefault();

            OnRoleGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Role> CancelRoleChanges(Models.RecoDb.Role item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnRoleUpdated(Models.RecoDb.Role item);
        partial void OnAfterRoleUpdated(Models.RecoDb.Role item);

        public async Task<Models.RecoDb.Role> UpdateRole(int? id, Models.RecoDb.Role role)
        {
            OnRoleUpdated(role);

            var itemToUpdate = Context.Roles
                              .Where(i => i.Id == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(role);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterRoleUpdated(role);

            return role;
        }

        partial void OnSentLetterDeleted(Models.RecoDb.SentLetter item);
        partial void OnAfterSentLetterDeleted(Models.RecoDb.SentLetter item);

        public async Task<Models.RecoDb.SentLetter> DeleteSentLetter(int? claimId, DateTime? dateLetterSent, int? letterTypeId)
        {
            var itemToDelete = Context.SentLetters
                              .Where(i => i.ClaimID == claimId && i.DateLetterSent == dateLetterSent && i.LetterTypeID == letterTypeId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSentLetterDeleted(itemToDelete);

            Context.SentLetters.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSentLetterDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSentLetterGet(Models.RecoDb.SentLetter item);

        public async Task<Models.RecoDb.SentLetter> GetSentLetterByClaimIdAndDateLetterSentAndLetterTypeId(int? claimId, DateTime? dateLetterSent, int? letterTypeId)
        {
            var items = Context.SentLetters
                              .AsNoTracking()
                              .Where(i => i.ClaimID == claimId && i.DateLetterSent == dateLetterSent && i.LetterTypeID == letterTypeId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnSentLetterGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.SentLetter> CancelSentLetterChanges(Models.RecoDb.SentLetter item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSentLetterUpdated(Models.RecoDb.SentLetter item);
        partial void OnAfterSentLetterUpdated(Models.RecoDb.SentLetter item);

        public async Task<Models.RecoDb.SentLetter> UpdateSentLetter(int? claimId, DateTime? dateLetterSent, int? letterTypeId, Models.RecoDb.SentLetter sentLetter)
        {
            OnSentLetterUpdated(sentLetter);

            var itemToUpdate = Context.SentLetters
                              .Where(i => i.ClaimID == claimId && i.DateLetterSent == dateLetterSent && i.LetterTypeID == letterTypeId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(sentLetter);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterSentLetterUpdated(sentLetter);

            return sentLetter;
        }

        partial void OnServiceProviderDeleted(Models.RecoDb.ServiceProvider item);
        partial void OnAfterServiceProviderDeleted(Models.RecoDb.ServiceProvider item);

        public async Task<Models.RecoDb.ServiceProvider> DeleteServiceProvider(Guid? id)
        {
            var itemToDelete = Context.ServiceProviders
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnServiceProviderDeleted(itemToDelete);

            Context.ServiceProviders.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterServiceProviderDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnServiceProviderGet(Models.RecoDb.ServiceProvider item);

        public async Task<Models.RecoDb.ServiceProvider> GetServiceProviderById(Guid? id)
        {
            var items = Context.ServiceProviders
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Firm);

            items = items.Include(i => i.Parameter2);

            var itemToReturn = items.FirstOrDefault();

            OnServiceProviderGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ServiceProvider> CancelServiceProviderChanges(Models.RecoDb.ServiceProvider item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnServiceProviderUpdated(Models.RecoDb.ServiceProvider item);
        partial void OnAfterServiceProviderUpdated(Models.RecoDb.ServiceProvider item);

        public async Task<Models.RecoDb.ServiceProvider> UpdateServiceProvider(Guid? id, Models.RecoDb.ServiceProvider serviceProvider)
        {
            OnServiceProviderUpdated(serviceProvider);

            var itemToUpdate = Context.ServiceProviders
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(serviceProvider);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterServiceProviderUpdated(serviceProvider);

            return serviceProvider;
        }

        partial void OnServiceProviderClaimPreferenceDeleted(Models.RecoDb.ServiceProviderClaimPreference item);
        partial void OnAfterServiceProviderClaimPreferenceDeleted(Models.RecoDb.ServiceProviderClaimPreference item);

        public async Task<Models.RecoDb.ServiceProviderClaimPreference> DeleteServiceProviderClaimPreference(int? serviceProviderId, int? claimId)
        {
            var itemToDelete = Context.ServiceProviderClaimPreferences
                              .Where(i => i.ServiceProviderID == serviceProviderId && i.ClaimID == claimId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnServiceProviderClaimPreferenceDeleted(itemToDelete);

            Context.ServiceProviderClaimPreferences.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterServiceProviderClaimPreferenceDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnServiceProviderClaimPreferenceGet(Models.RecoDb.ServiceProviderClaimPreference item);

        public async Task<Models.RecoDb.ServiceProviderClaimPreference> GetServiceProviderClaimPreferenceByServiceProviderIdAndClaimId(int? serviceProviderId, int? claimId)
        {
            var items = Context.ServiceProviderClaimPreferences
                              .AsNoTracking()
                              .Where(i => i.ServiceProviderID == serviceProviderId && i.ClaimID == claimId);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Claim);

            var itemToReturn = items.FirstOrDefault();

            OnServiceProviderClaimPreferenceGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.ServiceProviderClaimPreference> CancelServiceProviderClaimPreferenceChanges(Models.RecoDb.ServiceProviderClaimPreference item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnServiceProviderClaimPreferenceUpdated(Models.RecoDb.ServiceProviderClaimPreference item);
        partial void OnAfterServiceProviderClaimPreferenceUpdated(Models.RecoDb.ServiceProviderClaimPreference item);

        public async Task<Models.RecoDb.ServiceProviderClaimPreference> UpdateServiceProviderClaimPreference(int? serviceProviderId, int? claimId, Models.RecoDb.ServiceProviderClaimPreference serviceProviderClaimPreference)
        {
            OnServiceProviderClaimPreferenceUpdated(serviceProviderClaimPreference);

            var itemToUpdate = Context.ServiceProviderClaimPreferences
                              .Where(i => i.ServiceProviderID == serviceProviderId && i.ClaimID == claimId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(serviceProviderClaimPreference);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterServiceProviderClaimPreferenceUpdated(serviceProviderClaimPreference);

            return serviceProviderClaimPreference;
        }

        partial void OnSystemNoticeDeleted(Models.RecoDb.SystemNotice item);
        partial void OnAfterSystemNoticeDeleted(Models.RecoDb.SystemNotice item);

        public async Task<Models.RecoDb.SystemNotice> DeleteSystemNotice(int? systemNoticeId)
        {
            var itemToDelete = Context.SystemNotices
                              .Where(i => i.SystemNoticeID == systemNoticeId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSystemNoticeDeleted(itemToDelete);

            Context.SystemNotices.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSystemNoticeDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSystemNoticeGet(Models.RecoDb.SystemNotice item);

        public async Task<Models.RecoDb.SystemNotice> GetSystemNoticeBySystemNoticeId(int? systemNoticeId)
        {
            var items = Context.SystemNotices
                              .AsNoTracking()
                              .Where(i => i.SystemNoticeID == systemNoticeId);

            var itemToReturn = items.FirstOrDefault();

            OnSystemNoticeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.SystemNotice> CancelSystemNoticeChanges(Models.RecoDb.SystemNotice item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSystemNoticeUpdated(Models.RecoDb.SystemNotice item);
        partial void OnAfterSystemNoticeUpdated(Models.RecoDb.SystemNotice item);

        public async Task<Models.RecoDb.SystemNotice> UpdateSystemNotice(int? systemNoticeId, Models.RecoDb.SystemNotice systemNotice)
        {
            OnSystemNoticeUpdated(systemNotice);

            var itemToUpdate = Context.SystemNotices
                              .Where(i => i.SystemNoticeID == systemNoticeId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(systemNotice);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterSystemNoticeUpdated(systemNotice);

            return systemNotice;
        }

        partial void OnSystemNoticeReadDeleted(Models.RecoDb.SystemNoticeRead item);
        partial void OnAfterSystemNoticeReadDeleted(Models.RecoDb.SystemNoticeRead item);

        public async Task<Models.RecoDb.SystemNoticeRead> DeleteSystemNoticeRead(string userId)
        {
            var itemToDelete = Context.SystemNoticeReads
                              .Where(i => i.UserID == userId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSystemNoticeReadDeleted(itemToDelete);

            Context.SystemNoticeReads.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSystemNoticeReadDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSystemNoticeReadGet(Models.RecoDb.SystemNoticeRead item);

        public async Task<Models.RecoDb.SystemNoticeRead> GetSystemNoticeReadByUserId(string userId)
        {
            var items = Context.SystemNoticeReads
                              .AsNoTracking()
                              .Where(i => i.UserID == userId);

            var itemToReturn = items.FirstOrDefault();

            OnSystemNoticeReadGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.SystemNoticeRead> CancelSystemNoticeReadChanges(Models.RecoDb.SystemNoticeRead item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSystemNoticeReadUpdated(Models.RecoDb.SystemNoticeRead item);
        partial void OnAfterSystemNoticeReadUpdated(Models.RecoDb.SystemNoticeRead item);

        public async Task<Models.RecoDb.SystemNoticeRead> UpdateSystemNoticeRead(string userId, Models.RecoDb.SystemNoticeRead systemNoticeRead)
        {
            OnSystemNoticeReadUpdated(systemNoticeRead);

            var itemToUpdate = Context.SystemNoticeReads
                              .Where(i => i.UserID == userId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(systemNoticeRead);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterSystemNoticeReadUpdated(systemNoticeRead);

            return systemNoticeRead;
        }

        partial void OnSystemTemplateDeleted(Models.RecoDb.SystemTemplate item);
        partial void OnAfterSystemTemplateDeleted(Models.RecoDb.SystemTemplate item);

        public async Task<Models.RecoDb.SystemTemplate> DeleteSystemTemplate(int? templateId)
        {
            var itemToDelete = Context.SystemTemplates
                              .Where(i => i.TemplateID == templateId)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnSystemTemplateDeleted(itemToDelete);

            Context.SystemTemplates.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterSystemTemplateDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnSystemTemplateGet(Models.RecoDb.SystemTemplate item);

        public async Task<Models.RecoDb.SystemTemplate> GetSystemTemplateByTemplateId(int? templateId)
        {
            var items = Context.SystemTemplates
                              .AsNoTracking()
                              .Where(i => i.TemplateID == templateId);

            var itemToReturn = items.FirstOrDefault();

            OnSystemTemplateGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.SystemTemplate> CancelSystemTemplateChanges(Models.RecoDb.SystemTemplate item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnSystemTemplateUpdated(Models.RecoDb.SystemTemplate item);
        partial void OnAfterSystemTemplateUpdated(Models.RecoDb.SystemTemplate item);

        public async Task<Models.RecoDb.SystemTemplate> UpdateSystemTemplate(int? templateId, Models.RecoDb.SystemTemplate systemTemplate)
        {
            OnSystemTemplateUpdated(systemTemplate);

            var itemToUpdate = Context.SystemTemplates
                              .Where(i => i.TemplateID == templateId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(systemTemplate);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterSystemTemplateUpdated(systemTemplate);

            return systemTemplate;
        }

        partial void OnTokenCacheDeleted(Models.RecoDb.TokenCache item);
        partial void OnAfterTokenCacheDeleted(Models.RecoDb.TokenCache item);

        public async Task<Models.RecoDb.TokenCache> DeleteTokenCache(int? id)
        {
            var itemToDelete = Context.TokenCaches
                              .Where(i => i.Id == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTokenCacheDeleted(itemToDelete);

            Context.TokenCaches.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTokenCacheDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTokenCacheGet(Models.RecoDb.TokenCache item);

        public async Task<Models.RecoDb.TokenCache> GetTokenCacheById(int? id)
        {
            var items = Context.TokenCaches
                              .AsNoTracking()
                              .Where(i => i.Id == id);

            var itemToReturn = items.FirstOrDefault();

            OnTokenCacheGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.TokenCache> CancelTokenCacheChanges(Models.RecoDb.TokenCache item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTokenCacheUpdated(Models.RecoDb.TokenCache item);
        partial void OnAfterTokenCacheUpdated(Models.RecoDb.TokenCache item);

        public async Task<Models.RecoDb.TokenCache> UpdateTokenCache(int? id, Models.RecoDb.TokenCache tokenCache)
        {
            OnTokenCacheUpdated(tokenCache);

            var itemToUpdate = Context.TokenCaches
                              .Where(i => i.Id == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(tokenCache);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTokenCacheUpdated(tokenCache);

            return tokenCache;
        }

        partial void OnTradeDeleted(Models.RecoDb.Trade item);
        partial void OnAfterTradeDeleted(Models.RecoDb.Trade item);

        public async Task<Models.RecoDb.Trade> DeleteTrade(int? tradeId)
        {
            var itemToDelete = Context.Trades
                              .Where(i => i.TradeID == tradeId)
                              .Include(i => i.CommissionInstallments)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTradeDeleted(itemToDelete);

            Context.Trades.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTradeDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTradeGet(Models.RecoDb.Trade item);

        public async Task<Models.RecoDb.Trade> GetTradeByTradeId(int? tradeId)
        {
            var items = Context.Trades
                              .AsNoTracking()
                              .Where(i => i.TradeID == tradeId);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Parameter2);

            items = items.Include(i => i.Parameter3);

            items = items.Include(i => i.Parameter4);

            items = items.Include(i => i.Parameter5);

            items = items.Include(i => i.Builder);

            items = items.Include(i => i.Registrant);

            items = items.Include(i => i.Parameter6);

            items = items.Include(i => i.Parameter7);

            var itemToReturn = items.FirstOrDefault();

            OnTradeGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Trade> CancelTradeChanges(Models.RecoDb.Trade item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTradeUpdated(Models.RecoDb.Trade item);
        partial void OnAfterTradeUpdated(Models.RecoDb.Trade item);

        public async Task<Models.RecoDb.Trade> UpdateTrade(int? tradeId, Models.RecoDb.Trade trade)
        {
            OnTradeUpdated(trade);

            var itemToUpdate = Context.Trades
                              .Include(t=>t.Claim.Claimant)
                              .Where(i => i.TradeID == tradeId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(trade);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTradeUpdated(trade);

            return trade;
        }

        partial void OnTransactionDeleted(Models.RecoDb.Transaction item);
        partial void OnAfterTransactionDeleted(Models.RecoDb.Transaction item);

        public async Task<Models.RecoDb.Transaction> DeleteTransaction(Guid? id)
        {
            var itemToDelete = Context.Transactions
                              .Where(i => i.ID == id)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransactionDeleted(itemToDelete);

            Context.Transactions.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransactionDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTransactionGet(Models.RecoDb.Transaction item);

        public async Task<Models.RecoDb.Transaction> GetTransactionById(Guid? id)
        {
            var items = Context.Transactions
                              .AsNoTracking()
                              .Where(i => i.ID == id);

            items = items.Include(i => i.Claim);

            items = items.Include(i => i.Parameter);

            items = items.Include(i => i.Parameter1);

            items = items.Include(i => i.Transaction1);

            items = items.Include(i => i.Firm);

            items = items.Include(i => i.ServiceProvider);

            items = items.Include(i => i.Parameter2);

            var itemToReturn = items.FirstOrDefault();

            OnTransactionGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.Transaction> CancelTransactionChanges(Models.RecoDb.Transaction item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransactionUpdated(Models.RecoDb.Transaction item);
        partial void OnAfterTransactionUpdated(Models.RecoDb.Transaction item);

        public async Task<Models.RecoDb.Transaction> UpdateTransaction(Guid? id, Models.RecoDb.Transaction transaction)
        {
            OnTransactionUpdated(transaction);

            var itemToUpdate = Context.Transactions
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(transaction);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTransactionUpdated(transaction);

            return transaction;
        }

        partial void OnTransactionApprovalLimitDeleted(Models.RecoDb.TransactionApprovalLimit item);
        partial void OnAfterTransactionApprovalLimitDeleted(Models.RecoDb.TransactionApprovalLimit item);

        public async Task<Models.RecoDb.TransactionApprovalLimit> DeleteTransactionApprovalLimit(int? approvalLimitId)
        {
            var itemToDelete = Context.TransactionApprovalLimits
                              .Where(i => i.ApprovalLimitID == approvalLimitId)
                              .Include(i => i.TransactionApprovalLimits1)
                              .FirstOrDefault();

            if (itemToDelete == null)
            {
               throw new Exception("Item no longer available");
            }

            OnTransactionApprovalLimitDeleted(itemToDelete);

            Context.TransactionApprovalLimits.Remove(itemToDelete);

            try
            {
                Context.SaveChanges();
            }
            catch
            {
                Context.Entry(itemToDelete).State = EntityState.Unchanged;
                throw;
            }

            OnAfterTransactionApprovalLimitDeleted(itemToDelete);

            return itemToDelete;
        }

        partial void OnTransactionApprovalLimitGet(Models.RecoDb.TransactionApprovalLimit item);

        public async Task<Models.RecoDb.TransactionApprovalLimit> GetTransactionApprovalLimitByApprovalLimitId(int? approvalLimitId)
        {
            var items = Context.TransactionApprovalLimits
                              .AsNoTracking()
                              .Where(i => i.ApprovalLimitID == approvalLimitId);

            items = items.Include(i => i.TransactionApprovalLimit1);

            items = items.Include(i => i.Parameter);

            var itemToReturn = items.FirstOrDefault();

            OnTransactionApprovalLimitGet(itemToReturn);

            return await Task.FromResult(itemToReturn);
        }

        public async Task<Models.RecoDb.TransactionApprovalLimit> CancelTransactionApprovalLimitChanges(Models.RecoDb.TransactionApprovalLimit item)
        {
            var entityToCancel = Context.Entry(item);
            if (entityToCancel.State == EntityState.Modified)
            {
              entityToCancel.CurrentValues.SetValues(entityToCancel.OriginalValues);
              entityToCancel.State = EntityState.Unchanged;
            }

            return item;
        }

        partial void OnTransactionApprovalLimitUpdated(Models.RecoDb.TransactionApprovalLimit item);
        partial void OnAfterTransactionApprovalLimitUpdated(Models.RecoDb.TransactionApprovalLimit item);

        public async Task<Models.RecoDb.TransactionApprovalLimit> UpdateTransactionApprovalLimit(int? approvalLimitId, Models.RecoDb.TransactionApprovalLimit transactionApprovalLimit)
        {
            OnTransactionApprovalLimitUpdated(transactionApprovalLimit);

            var itemToUpdate = Context.TransactionApprovalLimits
                              .Where(i => i.ApprovalLimitID == approvalLimitId)
                              .FirstOrDefault();
            if (itemToUpdate == null)
            {
               throw new Exception("Item no longer available");
            }

            var entryToUpdate = Context.Entry(itemToUpdate);
            entryToUpdate.CurrentValues.SetValues(transactionApprovalLimit);
            entryToUpdate.State = EntityState.Modified;
            Context.SaveChanges();       

            OnAfterTransactionApprovalLimitUpdated(transactionApprovalLimit);

            return transactionApprovalLimit;
        }
    }
}
