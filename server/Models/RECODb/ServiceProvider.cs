using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
    [Table("ServiceProviders", Schema = "dbo")]
  public partial class ServiceProvider
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ServiceProviderID
    {
      get;
      set;
    }

    public ICollection<Expert> Experts { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
    public ICollection<Occurrence> Occurrences { get; set; }
    public ICollection<Claim> Claims { get; set; }
    public ICollection<Claim> Claims1 { get; set; }
    public ICollection<Claim> Claims2 { get; set; }
    public ICollection<Claim> Claims3 { get; set; }
    public ICollection<Claim> Claims4 { get; set; }
    public ICollection<Claim> Claims5 { get; set; }
    public ICollection<ClaimFileReporting> ClaimFileReportings { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails1 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails2 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails3 { get; set; }
    public ICollection<EoClaimDetail> EoClaimDetails4 { get; set; }
    public ICollection<CourtDate> CourtDates { get; set; }
    public ICollection<OtherParty> OtherParties { get; set; }
    public ICollection<ServiceProviderClaimPreference> ServiceProviderClaimPreferences { get; set; }
    public ICollection<LegalAssistants> AsDefenseCounsel { get; set; } = new List<LegalAssistants>();
    public ICollection<LegalAssistants> AsLegalAssistant { get; set; } = new List<LegalAssistants>();

        public string Name
    {
      get;
      set;
    }
    public string Address
    {
      get;
      set;
    }
    public int? ProvinceID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string City
    {
      get;
      set;
    }
    public string PostalCode
    {
      get;
      set;
    }
    public string EmailAddress
    {
      get;
      set;
    }
    public string BusinessPhoneNum
    {
      get;
      set;
    }
    public string CellPhoneNum
    {
      get;
      set;
    }
    public string FaxNum
    {
      get;
      set;
    }
    public string UserID
    {
      get;
      set;
    }
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public int? FirmID
    {
      get;
      set;
    }
    public Firm Firm { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public Guid? IgnoreNullUserID
    {
      get;
      set;
    }
    public int? ServiceProviderRoleID
    {
      get;
      set;
    }
    public Parameter Parameter2 { get; set; }
    public bool? Active
    {
      get;
      set;
    } = true;
    public bool? SubmitPayments
    {
      get;
      set;
    }
    public bool? ViewReports
    {
      get;
      set;
    }
    public bool? FileHandler
    {
      get;
      set;
    }
    public bool? PrimeUser
    {
      get;
      set;
    }
    public bool? AllowedToViewConfidential
    {
      get;
      set;
    }
    public string IPAddress
    {
      get;
      set;
    }
    public DateTime? ReportDate
    {
      get;
      set;
    }
    public string ServiceProviderObjectID
    {
      get;
      set;
    }
    public DateTime? StartDate
    {
      get;
      set;
    }
    public bool? DefaultEmail
    {
      get;
      set;
    }
    public string ReportJson
    {
        get;
        set;
    }
  }
}
