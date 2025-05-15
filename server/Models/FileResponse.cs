using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecoCms6.Models
{
    public class FileResponse
    {
        public Guid ID { get; set; }
        public string Filename { get; set; }
        public long Filesize { get; set; }
        public List<UploadedFileDetail> UploadedFileDetails { get; set; }

    }

    public class UploadedFileDetail
    {
        public Guid ID { get; set; }
        public string Filename { get; set; }
        public string ParentFilename { get; set; }
        public long Filesize { get; set; }
    }
}
