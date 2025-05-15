using System.Threading;
using System.Threading.Tasks;

namespace RecoCms6.Services.Background.MailServices
{
    /// <summary>
    /// Proper mail handling interface
    /// </summary>
    public interface IAutomaticMailHandler
    {
        Task Process();
    }

    public enum MailHandlerType
    {
        Attachment, Pdf
    }
}