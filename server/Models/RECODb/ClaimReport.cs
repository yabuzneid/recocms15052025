using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
    [Table("ClaimReport", Schema = "dbo")]
    public partial class ClaimReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClaimReportID
        {
            get;
            set;
        }
        public int ClaimID
        {
            get;
            set;
        }
        public Claim Claim { get; set; }
        public DateTime DateCreated
        {
            get;
            set;
        }
        public bool InitialReport
        {
            get;
            set;
        }
        public string SubmittedBy
        {
            get;
            set;
        }

        public string SubmittedOnBehalfOf
        {
            get;
            set;
        }

        public string Facts
        {
            get;
            set;
        }
        public string Coverage
        {
            get;
            set;
        }
        public string Liability
        {
            get;
            set;
        }
        public string Damages
        {
            get;
            set;
        }
        public string EstimatedExpenses
        {
            get;
            set;
        }
        public string EstimatedIndemnity
        {
            get;
            set;
        }
        public string PossibleSubrogation
        {
            get;
            set;
        }
        public string ActionPlan
        {
            get;
            set;
        }
        public DateTime? DateLastModified
        {
            get;
            set;
        }
        public DateTime? DateSubmitted
        {
            get;
            set;
        }
        public bool Incremental
        {
            get;
            set;
        } = true;
        public string ExecutiveSummary
        {
            get;
            set;
        }
        public string Recommendations
        {
            get;
            set;
        }
        public string DamagesClaimed
        {
            get;
            set;
        }
        public int? ClaimReportFlagID
        {
            get;
            set;
        }
        public Parameter Parameter { get; set; }
        public int? HandlingFirmID
        {
            get;
            set;
        }
        public Firm Firm { get; set; }
        public int? FileId { get; set; }
        public File File { get; set; }
    }
}
