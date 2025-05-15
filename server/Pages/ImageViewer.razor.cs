using System;

namespace RecoCms6.Pages
{
    public partial class ImageViewerComponent
    {

        protected string FileDetails { get; set; }
        protected string URLDetails { get; set; }

        public async void GenerateUrl()
        {
            var recoDbGetFileByIdResult = await RecoDb.GetFileById(new Guid(ID));
            var file = recoDbGetFileByIdResult;

            FileDetails = "data:" + file.ContentType + ";base64," + Convert.ToBase64String(file.StoredDocument);
            URLDetails = "<img src='" + FileDetails + "'/>";
        }
    }
}
