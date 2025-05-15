using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("BrokerageContacts", Schema = "dbo")]
  public partial class BrokerageContact
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int BrokerageContactID
    {
      get;
      set;
    }
    public int ClaimID
    {
      get;
      set;
    }
    public int BrokerageID
    {
      get;
      set;
    }
    public Brokerage Brokerage { get; set; }
    public string Name
    {
      get;
      set;
    }
    public string Email
    {
      get;
      set;
    }
    public string PhoneNum
    {
      get;
      set;
    }
    public int? BrokerageRoleID
    {
      get;
      set;
    }
    public Parameter Parameter { get; set; }
  }
}
