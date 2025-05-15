using Agno.BlazorInputFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Models
{
    public class RecoMail
    {
        public RecoMail()
        {
            ClaimFiles = new List<RecoDb.File>();
            Files = new List<IFileListEntry>();
            To = Enumerable.Empty<string>();
            CC = Enumerable.Empty<string>();
            BCC = Enumerable.Empty<string>();
            Subject = string.Empty;
            Message = string.Empty;
        }
        public string Subject { get; set; }
        public string From { get; set; }
        public IEnumerable<string> To { get; set; }
        public IEnumerable<string> CC { get; set; }
        public IEnumerable<string> BCC { get; set; }
        public string Message { get; set; } = string.Empty;
        public List<RecoDb.File> ClaimFiles { get; set; }
        public List<IFileListEntry> Files { get; set; }
        public List<RecoDb.ClaimActivityLog> Notes { get; set; }
        public RecoDb.Claim Claim { get; set; }
        public RecoDb.ClaimList Claimlist { get; set; }
        public RecoDb.Transaction Transaction { get; set; }
        public string ToAsString() => string.Join(",\n", To ?? new List<string>());
        public IEnumerable<string> ToAsList() => To ?? new List<string>();
        public string CCAsString() => string.Join(",\n", CC ?? new List<string>());
        public IEnumerable<string> CCAsList() => CC ?? new List<string>();
        public string BCCAsString() => string.Join(",\n", BCC ?? new List<string>());
        public IEnumerable<string> BCCAsList() => BCC ?? new List<string>();
        public string Filenames() => ClaimFiles == null ? "" : string.Join(",\n", ClaimFiles.Select(x => x.Filename));

        public string NoteSubjects() => Notes == null ? "" : string.Join(",\n", Notes.Select(x => x.Subject));

        public bool HasFiles()
            => ClaimFiles?.Count > 0 || Files?.Count > 0;

    }
}
