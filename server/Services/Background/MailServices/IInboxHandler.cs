using MailBee.Mime;
using Microsoft.Graph;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace RecoCms6.Services.Background.MailServices
{
    // not in use currently
    public interface IInboxHandler
    {
        IEnumerable<MailMessage> Messages { get; }
        void LoadInbox(string filter);
        void MoveFromInbox(MailMessage message, string folder);
        void Connect();
        void Disconnect();
    }

    public class Credential
    {
        public string User { get; set; }
        public string Password { get; set; }
    }

    public static class MailFolder
    {
        public const string Inbox = "Inbox";
        public const string Processed = "INBOX/Processed";
        public const string Failed = "INBOX/Failed";
        public const string NonProcessable = "INBOX/Non-Processable";
    }

    public static class MailMessageExtensions
    {
        public static bool TryGetClaimId(this MailMessage message, bool bIsRECO, out string claimId)
        {
            // Warning: The order of the reqex patterns is important
            string[] patterns = new string[]
            {
                @"20\d\d-\d\d\d\d\d",
                @"I20\d\d-\d\d\d\d",
                @"20\d\d-\d\d\d\d",
                @"CP20\d\d-\d\d\d-\d\d\d\.\d\d\d",
                @"CD20\d\d-\d\d\d-\d\d\d\.\d\d\d",
                @"CP20\d\d-\d\d\d-\d\d\d",
                @"CD20\d\d-\d\d\d-\d\d\d"
            };

            if (!bIsRECO)
            {
                patterns = new string[]
                {
                    @"\d\d-\d\d\d",
                    @"I\d\d-\d\d\d([a-z]|[A-Z]){1,2}",
                    @"\d\d-\d\d\d([a-z]|[A-Z]){1,2}",
                    @"I\d\d-\d\d\d"
                };
            }
            foreach (var pattern in patterns)
            {
                var match = Regex.Match(message.Subject, pattern);
                if (match.Success)
                {
                    claimId = match.Value;
                    return true;
                }
            }
            claimId = string.Empty;
            return false;
        }

        public static bool TryGetClaimId(this Message message, bool bIsRECO, out string claimId)
        {
            // Warning: The order of the reqex patterns is important
            string[] patterns = new string[]
            {
                @"20\d\d-\d\d\d\d\d",
                @"I20\d\d-\d\d\d\d",
                @"20\d\d-\d\d\d\d",
                @"CP20\d\d-\d\d\d-\d\d\d\.\d\d\d",
                @"CD20\d\d-\d\d\d-\d\d\d\.\d\d\d",
                @"CP20\d\d-\d\d\d-\d\d\d",
                @"CD20\d\d-\d\d\d-\d\d\d"
            };

            if (!bIsRECO)
            {
                patterns = new string[]
                {
                    @"\d\d-\d\d\d",
                    @"I\d\d-\d\d\d([a-z]|[A-Z]){1,2}",
                    @"\d\d-\d\d\d([a-z]|[A-Z]){1,2}",
                    @"I\d\d-\d\d\d"
                };
            }
            foreach (var pattern in patterns)
            {
                var match = Regex.Match(message.Subject, pattern);
                if (match.Success)
                {
                    claimId = match.Value;
                    return true;
                }
            }
            claimId = string.Empty;
            return false;
        }

    }
}
