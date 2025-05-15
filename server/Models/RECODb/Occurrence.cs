using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Occurrences", Schema = "dbo")]
  public partial class Occurrence
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int OccurrenceID
    {
      get;
      set;
    }

    public ICollection<Claim> Claims { get; set; }
    public string OccurrenceNo
    {
      get;
      set;
    }
    public string OccurrenceDescription
    {
      get;
      set;
    }
    public int ProgramID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public DateTime? OccurrenceDate
    {
      get;
      set;
    }
    public decimal? ValueOfTransaction
    {
      get;
      set;
    }
    public decimal? ExpectedPayout
    {
      get;
      set;
    }
    public decimal? AdjustedGrossClaim
    {
      get;
      set;
    }
    public decimal? TotalClaimedAmount
    {
      get;
      set;
    }
    public int? BrokerageID
    {
      get;
      set;
    }
    public Brokerage Brokerage { get; set; }
    public int ContractYearID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public int? OccurrenceReason
    {
      get;
      set;
    }
    public Parameter Parameter2 { get; set; }
    public bool FreezeOrder
    {
      get;
      set;
    }
    public DateTime? FreezeOrderDate
    {
      get;
      set;
    }
    public int? ReceiverID
    {
      get;
      set;
    }
    public Receiver Receiver { get; set; }
    public int? CounselID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
    public string RecoveryAttempts
    {
      get;
      set;
    }
    public int? OccurenceStatusID
    {
      get;
      set;
    }
    public Parameter Parameter3 { get; set; }
    public string BrokerageName
    {
      get;
      set;
    }
    public string BrokerageStreet1
    {
      get;
      set;
    }
    public string BrokerageStreet2
    {
      get;
      set;
    }
    public string BrokerageUnitNumber
    {
      get;
      set;
    }
    public int? BrokerageProvinceID
    {
      get;
      set;
    }
    public string BrokerageCity
    {
      get;
      set;
    }
    public string BrokeragePostalCode
    {
      get;
      set;
    }
    public string BrokerageEmailAddress
    {
      get;
      set;
    }
    public string BrokerageContactPerson
    {
      get;
      set;
    }
    public string BrokerOfRecord
    {
      get;
      set;
    }
    public string BrokeragePhoneNum
    {
      get;
      set;
    }
    public string BrokerageCellNum
    {
      get;
      set;
    }
    public string BrokerageFaxNum
    {
      get;
      set;
    }
    public string BrokerageContactEmail
    {
      get;
      set;
    }
    public string BrokerageContactPhone
    {
      get;
      set;
    }
  }
}
