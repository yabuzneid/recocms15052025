using RecoCms6.Models.RecoDb;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecoCms6.Models
{
    [Table("LegalAssistants", Schema = "dbo")]
    public class LegalAssistants
    {
        public int DefenseCounselID { get; set; }
        public int LegalAssistantID { get; set; }

        public ServiceProvider DefenseCounsel { get; set; } = null!;
        public ServiceProvider LegalAssistant { get; set; } = null!;
    }

}
