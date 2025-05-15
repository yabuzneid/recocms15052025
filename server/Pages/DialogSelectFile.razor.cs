using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace RecoCms6.Pages
{
    public partial class DialogSelectFileComponent
    {
        protected async System.Threading.Tasks.Task DownloadFileAsync(Models.RecoDb.ClaimFilesByUser file)
        {
            try
            {
                UriHelper.NavigateTo($"/downloadfullfile/FileID={file.FileID}", true);
            }
            catch { }
        }
    }
}
