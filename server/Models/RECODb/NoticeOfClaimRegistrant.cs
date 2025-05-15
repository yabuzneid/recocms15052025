using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoticeOfClaimRegistrants", Schema = "dbo")]
  public partial class NoticeOfClaimRegistrant
  {
    public int NoticeOfClaimID
    {
      get;
      set;
    }
    public NoticeOfClaim NoticeOfClaim { get; set; }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NOCRegistrantID
    {
      get;
      set;
    }
    public int? NoticeOfClaimBrokerageID
    {
      get;
      set;
    }
    public NoticeOfClaimBrokerage NoticeOfClaimBrokerage { get; set; }
    public string RegistrantName
    {
      get;
      set;
    }
    public string RegistrantNo
    {
      get;
      set;
    }
    public string RegistrantMailingAddress
    {
      get;
      set;
    }
    public string RegistrantBusinessAddress
    {
      get;
      set;
    }
    public Int16? YearsOfExperience
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
    public string HomePhoneNum
    {
      get;
      set;
    }
    public string FaxNum
    {
      get;
      set;
    }
    public string EmailAddress
    {
      get;
      set;
    }
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int? BrokerageTransactionRoleID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
  }
}
