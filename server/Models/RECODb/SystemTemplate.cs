using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("SystemTemplates", Schema = "dbo")]
  public partial class SystemTemplate
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int TemplateID
    {
      get;
      set;
    }
    public string TemplateName
    {
      get;
      set;
    }
    public Byte[] TemplateDocument
    {
      get;
      set;
    }
  }
}
