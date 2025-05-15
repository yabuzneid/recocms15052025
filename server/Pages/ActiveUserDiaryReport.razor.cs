using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace RecoCms6.Pages
{
    public partial class ActiveUserDiaryReportComponent
    {
        protected async System.Threading.Tasks.Task DownloadFileAsync()
        {
            try
            {
                UriHelper.NavigateTo($"/download/activediaries/UserID={Globals.userdetails.ServiceProviderID}", true);
            }
            catch { }
        }
    }
}
