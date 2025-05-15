using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("ClaimActivityLog", Schema = "dbo")]
  public partial class ClaimActivityLog
  {
    public Guid ID
    {
      get;
      set;
    }
    public int NoteID
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public DateTime EntryDate
    {
      get;
      set;
    }
    public string Subject
    {
      get;
      set;
    }
    public string NoteType
    {
      get;
      set;
    }
    public bool Sticky
    {
      get;
      set;
    }
    public bool LargeLoss
    {
      get;
      set;
    }
    public string Name
    {
      get;
      set;
    }
    public string LogType
    {
      get;
      set;
    }
    public string Details
    {
      get;
      set;
    }
    public bool Confidential
    {
      get;
      set;
    }
    public DateTime AbeyanceDate
    {
      get;
      set;
    }
  }
}
