using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TemplateDetails", Schema = "dbo")]
  public partial class TemplateDetail
  {
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
    public string TemplateType
    {
      get;
      set;
    }
    public string DefaultSendTo
    {
      get;
      set;
    }
  }
}
