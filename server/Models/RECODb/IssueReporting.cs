using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("IssueReporting", Schema = "dbo")]
  public partial class IssueReporting
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IssueReportingID
    {
      get;
      set;
    }
    public DateTime DateEntered
    {
      get;
      set;
    }
    public string EnteredById
    {
      get;
      set;
    }
    public string Subject
    {
      get;
      set;
    }
    public string Issue
    {
      get;
      set;
    }
    public Byte[] AttachedFile
    {
      get;
      set;
    }
    public string Filename
    {
      get;
      set;
    }
    public int IssueStatusID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
  }
}
