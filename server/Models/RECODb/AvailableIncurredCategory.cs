using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("AvailableIncurredCategories", Schema = "dbo")]
  public partial class AvailableIncurredCategory
  {
    public int ParameterID
    {
      get;
      set;
    }
    public string ParamAbbrev
    {
      get;
      set;
    }
    public string ParamDesc
    {
      get;
      set;
    }
    public decimal? ParamValue
    {
      get;
      set;
    }
    public string ParamTypeDesc
    {
      get;
      set;
    }
    public int ParamTypeID
    {
      get;
      set;
    }
    public string ParentParamType
    {
      get;
      set;
    }
    public string ParentParameterDesc
    {
      get;
      set;
    }
    public int? ParentParameterID
    {
      get;
      set;
    }
    public Guid ID
    {
      get;
      set;
    }
    public bool OccurrenceMade
    {
      get;
      set;
    }
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
    public bool? ShowLegal
    {
      get;
      set;
    }
    public bool? ShowTradeFlags
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
    public bool? ShowExpense
    {
      get;
      set;
    }
    public bool? ShowAdjusting
    {
      get;
      set;
    }
    public bool? ShowRecovery
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
  }
}
