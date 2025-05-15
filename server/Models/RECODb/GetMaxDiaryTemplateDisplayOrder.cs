using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("GetMaxDiaryTemplateDisplayOrder", Schema = "dbo")]
  public partial class GetMaxDiaryTemplateDisplayOrder
  {
    public Int16? MaxDisplayOrder
    {
      get;
      set;
    }
  }
}
