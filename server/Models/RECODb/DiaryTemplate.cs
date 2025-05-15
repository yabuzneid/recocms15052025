using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("DiaryTemplates", Schema = "dbo")]
  public partial class DiaryTemplate
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DiaryTemplateID
    {
      get;
      set;
    }
    public string Title
    {
      get;
      set;
    }
    public string Subject
    {
      get;
      set;
    }
    public string TemplateText
    {
      get;
      set;
    }
    public Int16? DisplayOrder
    {
      get;
      set;
    }
    public int? DefaultSendToID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public int? TemplateTypeID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
  }
}
