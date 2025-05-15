using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ParamTypes", Schema = "dbo")]
  public partial class ParamType
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ParamTypeID
    {
      get;
      set;
    }

    public ICollection<ParamType> ParamTypes1 { get; set; }
    public ICollection<Parameter> Parameters { get; set; }
    public ICollection<Parameter> Parameters1 { get; set; }
    public string ParamTypeDesc
    {
      get;
      set;
    }
    public int? ParentParamTypeID
    {
      get;
      set;
    }
    public ParamType ParamType1 { get; set; }
  }
}
