using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GetReportDate", Schema = "dbo")]
  public partial class GetReportDate
  {
    public DateTime? StartDate
    {
      get;
      set;
    }
    public DateTime? ReportDate
    {
      get;
      set;
    }
    public string ReportJson
    {
        get;
        set;
    }
  }
}
