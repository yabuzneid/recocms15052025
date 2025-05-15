using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ParameterDetails", Schema = "dbo")]
  public partial class ParameterDetail
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
    public int? ParentParamTypeID
    {
      get;
      set;
    }
    public bool Locked
    {
      get;
      set;
    }
    public decimal? ParamIDAsValue
    {
      get;
      set;
    }
  }
}
