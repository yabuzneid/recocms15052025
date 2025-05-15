using Radzen;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecoCms6.Models.RecoDb;
using EFCore.BulkExtensions;

namespace RecoCms6
{
    public partial class RecoDbService
    {
        public async Task<Diary> UpdateDiaryForced(Guid? id, Diary diary)
        {
            OnDiaryUpdated(diary);

            var item = context.Diaries
                              .Where(i => i.ID == id)
                              .FirstOrDefault();
            if (item == null)
            {
                throw new Exception("Item no longer available");
            }
            var entry = context.Entry(item);
            entry.CurrentValues.SetValues(diary);
            entry.State = EntityState.Modified;
            entry.Property(x => x.DiaryID).IsModified = false;

            context.SaveChanges();

            return diary;
        }

        public ClaimReport CloneClaimReport(ClaimReport source)
        {
            var clone = new Models.RecoDb.ClaimReport();
            var dates = new Models.RecoDb.ClaimReport();

            context.Entry(clone).CurrentValues.SetValues(source);
            clone.ClaimReportID = 0;
            clone.DateCreated = dates.DateCreated;
            clone.DateSubmitted = dates.DateSubmitted;
            clone.DateLastModified = dates.DateLastModified;

            return clone;
        }

        //public async Task ExportFullBordereauToExcel(string ReportDate, Query query = null, string fileName = null)
        //{
        //    navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fullbordereau/excel(ReportDate='{Uri.EscapeDataString(ReportDate)}', fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/recodb/fullbordereau/excel(ReportDate='{Uri.EscapeDataString(ReportDate)}', fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        //}

        /// <summary>
        /// Export FullBordereau To CSV
        /// </summary>
        /// <param name="ReportDate"></param>
        /// <param name="query"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task ExportFullBordereauToCSV(string ReportDate, Query query = null, string fileName = null)
        {
            navigationManager.NavigateTo(query != null ? query.ToUrl($"export/recodb/fullbordereau/csv(ReportDate='{Uri.EscapeDataString(ReportDate)}', fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')") : $"export/recodb/fullbordereau/csv(ReportDate='{Uri.EscapeDataString(ReportDate)}', fileName='{(!string.IsNullOrEmpty(fileName) ? fileName : "Export")}')", true);
        }

        /// <summary>
        /// Update existing claimants
        /// </summary>
        /// <param name="claimants"></param>
        /// <returns></returns>
        public async Task<List<Claimant>> UpdateClaimants(List<Claimant> claimants)
        {
            context.BulkUpdate<Claimant>(claimants, new BulkConfig() { PropertiesToExclude = new List<string>() { "ClaimantID" } });

            return claimants;
        }

        /// <summary>
        /// Get Claimants By Id
        /// </summary>
        /// <param name="Ids"></param>
        /// <returns></returns>
        public async Task<List<Claimant>> GetClaimantsByIds(List<Guid> Ids)
        {
            var claimants = Ids.Select(i => new Claimant() { ID = i }).ToList();
            
            context.BulkRead<Claimant>(claimants, new BulkConfig() { });

            return claimants;
        }

        public async Task<List<OtherParty>> GetClaimOtherPartiesByIds(List<int> Ids)
        {
            var otherParties = Ids.Select(i => new OtherParty() { OtherPartyID = i }).ToList();

            context.BulkRead<OtherParty>(otherParties);

            return otherParties;
        }

        public async Task<List<OtherParty>> UpdateClaimOtherPartys(List<OtherParty> otherPartys)
        {
            context.BulkUpdate<OtherParty>(otherPartys, new BulkConfig() { PropertiesToExclude = new List<string>() { "ID"} });

            return otherPartys;
        }

        public List<T> GetEntitiesByIds<T>(List<T> Ids) where T : class
        {
            //var claimants = Ids.Select(i => new Claimant() { ID = i }).ToList();

            context.BulkRead<T>(Ids, new BulkConfig() { });

            return Ids;
        }

        public List<T> UpdateEntities<T>(List<T> entities, List<string> exclude = null) where T : class
        {
            var config = new BulkConfig();

            if (exclude != null)
            {
                config.PropertiesToExclude = exclude;
            }

            context.BulkUpdate<T>(entities, config);

            return entities;
        }

        public void DeleteEntities<T>(List<T> entities, List<string> exclude = null) where T : class
        {
            var config = new BulkConfig();

            if (exclude != null)
            {
                config.PropertiesToExclude = exclude;
            }

            context.BulkDelete<T>(entities, config);
        }

        //partial void OnFilesRead(ref IQueryable<Models.RecoDb.File> items)
        //{
        //    var filesExtended = this.context.Files.ToList();
        //    foreach (var item in items)
        //    {
        //        var fileExtended = filesExtended
        //            .Where(ode => ode.FileID == item.FileID)
        //            .FirstOrDefault();

        //        if (fileExtended != null)
        //        {
        //            item.FilePictureAsString = System.Text.Encoding.Default.GetString(item.StoredDocument);
        //        }
        //    }
        public void BeginTransaction()
        {
            this.Context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            this.Context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            this.Context.Database.RollbackTransaction();
        }
        //}

    }
}