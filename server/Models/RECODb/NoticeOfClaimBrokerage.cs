using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("NoticeOfClaimBrokerage", Schema = "dbo")]
  public partial class NoticeOfClaimBrokerage
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BrokerageID
    {
      get;
      set;
    }

    public ICollection<NoticeOfClaimRegistrant> NoticeOfClaimRegistrants { get; set; }
    public int? NoticeOfClaimID
    {
      get;
      set;
    }
    public NoticeOfClaim NoticeOfClaim { get; set; }
    public string BrokerageName
    {
      get;
      set;
    }
    public string RegistrantNo
    {
      get;
      set;
    }
    public string BrokerageMailingAddress
    {
      get;
      set;
    }
    public string BrokerOfRecord
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
    public int? PreferredCommunicationMethodID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public string Street1
    {
      get;
      set;
    }
    public string Street2
    {
      get;
      set;
    }
    public string UnitNumber
    {
      get;
      set;
    }
    public int? ProvinceID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
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
  }
}
