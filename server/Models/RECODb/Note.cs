using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Notes", Schema = "dbo")]
  public partial class Note
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid ID
    {
      get;
      set;
    }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int NoteID
    {
      get;
      set;
    }

    public ICollection<NoteRole> NoteRoles { get; set; }
    public int ClaimID
    {
      get;
      set;
    }
    public Claim Claim { get; set; }
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
    public string Details
    {
      get;
      set;
    }
    public int VisibleTo
    {
      get;
      set;
    }
    public string EnteredByID
    {
      get;
      set;
    }
    public int? NoteTypeID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
    public bool LargeLoss
    {
      get;
      set;
    }
    public bool Sticky
    {
      get;
      set;
    }
    public bool Confidential
    {
      get;
      set;
    }
    public bool VisibleToCounsel
    {
      get;
      set;
    }
  }
}
