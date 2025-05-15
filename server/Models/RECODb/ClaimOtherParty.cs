using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimOtherParties", Schema = "dbo")]
  public partial class ClaimOtherParty
  {
    public int ClaimID
    {
      get;
      set;
    }
    public int OtherPartyID
    {
      get;
      set;
    }

    [Column("Transaction Role")]
    public string TransactionRole
    {
      get;
      set;
    }
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
    public Int16? DisplayOrder
    {
      get;
      set;
    }

    [Column("Communication Method")]
    public string CommunicationMethod
    {
      get;
      set;
    }
    public string Province
    {
      get;
      set;
    }
    public Guid ID
    {
      get;
      set;
    }
  }
}
