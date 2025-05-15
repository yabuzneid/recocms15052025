using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimPrincipals", Schema = "dbo")]
  public partial class ClaimPrincipal
  {
    public int ClaimID
    {
      get;
      set;
    }
    public string Claimants
    {
      get;
      set;
    }
    public string Insureds
    {
      get;
      set;
    }
    public string InsuredRegNo
    {
      get;
      set;
    }
    public string Address
    {
      get;
      set;
    }
    public string Insured1
    {
      get;
      set;
    }
    public string Insured2
    {
      get;
      set;
    }
    public string Insured3
    {
      get;
      set;
    }
    public int? InsuredID1
    {
      get;
      set;
    }
    public int? InsuredID2
    {
      get;
      set;
    }
    public int? InsuredID3
    {
      get;
      set;
    }
    public string Claimant1
    {
      get;
      set;
    }
    public string Claimant2
    {
      get;
      set;
    }
    public string Claimant3
    {
      get;
      set;
    }
    public string FullAddress
    {
      get;
      set;
    }
    public string FullAddress2
    {
      get;
      set;
    }
    public string FullAddress3
    {
      get;
      set;
    }
    public string ReportsTo
    {
      get;
      set;
    }
    public string ClaimantsWithRoles
    {
      get;
      set;
    }
    public string ClaimantSolicitors
    {
      get;
      set;
    }
    public string ClaimantSolicitorFirms
    {
      get;
      set;
    }
    public string InsuredsWithRoles
    {
      get;
      set;
    }
    public string OtherPartyDetails
    {
      get;
      set;
    }
    public decimal? TradePrice
    {
      get;
      set;
    }
    public decimal? DepositAmount
    {
      get;
      set;
    }
    public string Discoveries
    {
      get;
      set;
    }
    public string Mediations
    {
      get;
      set;
    }
    public string Trials
    {
      get;
      set;
    }
    public string Brokerage1
    {
      get;
      set;
    }
    public string BrokerageContactName
    {
      get;
      set;
    }
    public string BrokerageContactPhone
    {
      get;
      set;
    }
    public string BrokerageContactEmail
    {
      get;
      set;
    }
    public string Broker1
    {
      get;
      set;
    }
    public string InsuredTransactionRole1
    {
      get;
      set;
    }
    public string InsuredTransactionRole2
    {
      get;
      set;
    }
    public string InsuredTransactionRole3
    {
      get;
      set;
    }
    public string Builder1
    {
      get;
      set;
    }
    public string ProgramManager
    {
      get;
      set;
    }
    public Guid? ProgramManagerID
    {
      get;
      set;
    }
    public string ReportsToEmail
    {
      get;
      set;
    }
    public int? FilehandlerID
    {
      get;
      set;
    }
    public int? AvgYearsOfExperience
    {
      get;
      set;
    }
    public string RegistrantEmailAddresses
    {
      get;
      set;
    }
    public string ClaimantEmails
    {
      get;
      set;
    }
    public string LossCauseTags
    {
      get;
      set;
    }
    public string UrbanOrRuralDesc
    {
      get;
      set;
    }
  }
}
