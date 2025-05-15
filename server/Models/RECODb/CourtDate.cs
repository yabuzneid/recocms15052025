using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("CourtDates", Schema = "dbo")]
  public partial class CourtDate
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CourtDateID
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }

    [Column("CourtDate")]
    public DateTime CourtDate1
    {
      get;
      set;
    }
    public int CourtDateTypeID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int AssignedServiceProviderID
    {
      get;
      set;
    }
    public ServiceProvider ServiceProvider { get; set; }
  }
}
