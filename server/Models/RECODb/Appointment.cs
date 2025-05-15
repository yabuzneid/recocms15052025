using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("Appointments", Schema = "dbo")]
  public partial class Appointment
  {
    [Key]
    public Guid ID
    {
      get;
      set;
    }
    public int AppointmentID
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
    public DateTime EntryDate
    {
      get;
      set;
    }
    public int AppointmentType
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
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
    public DateTime StartDate
    {
      get;
      set;
    }
    public DateTime EndDate
    {
      get;
      set;
    }
    public bool AllDay
    {
      get;
      set;
    }
    public int VisibleTo
    {
      get;
      set;
    }
    public string UserID
    {
      get;
      set;
    }
    public string EnteredBy
    {
      get;
      set;
    }
    public string Address
    {
      get;
      set;
    }
    public int? ProvinceID
    {
      get;
      set;
    }
    public Parameter Parameter1 { get; set; }
    public string City
    {
      get;
      set;
    }
    public string PostalCode
    {
      get;
      set;
    }
  }
}
