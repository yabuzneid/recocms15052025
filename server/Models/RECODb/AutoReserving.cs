using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("AutoReserving", Schema = "dbo")]
  public partial class AutoReserving
  {
    [Key]
    public int ProgramID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    [Key]
    public int ClaimInitiationID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    [Key]
    public bool ClaimOrIncident
    {
      get;
      set;
    }
    public decimal? AdjusterReserve
    {
      get;
      set;
    }
    public decimal? LegalReserve
    {
      get;
      set;
    }
  }
}
