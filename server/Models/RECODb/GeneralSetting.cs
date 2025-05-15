using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GeneralSettings", Schema = "dbo")]
  public partial class GeneralSetting
  {
    [Key]
    public Guid ID
    {
      get;
      set;
    }
    public bool OccurrenceMade
    {
      get;
      set;
    } = true;
    public DateTime FiscalYear
    {
      get;
      set;
    }
    public bool SeparateIncidents
    {
      get;
      set;
    }
    public bool ShowLegal
    {
      get;
      set;
    }
    public bool ShowTradeFlags
    {
      get;
      set;
    }
    public string LocationName
    {
      get;
      set;
    }
    public string TradeTypeName
    {
      get;
      set;
    }
    public bool ShowExpense
    {
      get;
      set;
    }
    public bool ShowAdjusting
    {
      get;
      set;
    }
    public bool ShowRecovery
    {
      get;
      set;
    }
    public string ApplicationName
    {
      get;
      set;
    }
    public string ClaimantName
    {
      get;
      set;
    }
    public string ContractYear
    {
      get;
      set;
    }
    public bool Active
    {
      get;
      set;
    }
    public string BrokerOfRecordName
    {
      get;
      set;
    }
    public string IncidentName
    {
      get;
      set;
    }
    public string LossCauseName
    {
      get;
      set;
    }
    public string SubrogationName
    {
      get;
      set;
    }
    public string FloatAccount
    {
      get;
      set;
    }
    public string ClaimInitiation
    {
      get;
      set;
    }
    public string Host
    {
      get;
      set;
    }
    public int? Port
    {
      get;
      set;
    }
    public bool UseSSL
    {
      get;
      set;
    } = true;
    public string SystemEmail
    {
      get;
      set;
    }
    public string SystemNameFrom
    {
      get;
      set;
    }
    public string SystemEmailPassword
    {
      get;
      set;
    }
    public string BindEmailToClaimEmail
    {
      get;
      set;
    }
    public string BindEmailToClaimPassword
    {
      get;
      set;
    }
    public string BindAttachmentsToClaimEmail
    {
      get;
      set;
    }
    public string BindAttachmentsToClaimPassword
    {
      get;
      set;
    }
    public bool AllowAnonymousProcessing
    {
      get;
      set;
    }
    public string ImapHost
    {
      get;
      set;
    }
    public int? ImapPort
    {
      get;
      set;
    }
    public string SystemClientID
    {
      get;
      set;
    }
    public string SystemTenantID
    {
      get;
      set;
    }
    public string SystemSecretKey
    {
      get;
      set;
    }
    public string SystemObjectID
    {
      get;
      set;
    }
    public string BindEmailObjectID
    {
      get;
      set;
    }
    public string BindAttachmentsObjectID
    {
      get;
      set;
    }
  }
}
