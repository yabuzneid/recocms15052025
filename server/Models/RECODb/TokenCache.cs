using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models.RecoDb
{
  [Table("TokenCache", Schema = "dbo")]
  public partial class TokenCache
  {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id
    {
      get;
      set;
    }
    public string UserId
    {
      get;
      set;
    }
    public string AccessToken
    {
      get;
      set;
    }
    public string RefreshToken
    {
      get;
      set;
    }
    public DateTime ExpiresAt
    {
      get;
      set;
    }
  }
}
