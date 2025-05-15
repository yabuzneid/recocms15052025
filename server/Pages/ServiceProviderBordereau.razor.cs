using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;

namespace RecoCms6.Pages
{
    public partial class ServiceProviderBordereauComponent
    {
        protected async System.Threading.Tasks.Task DownloadFileAsync()
        {
            try
            {
                UriHelper.NavigateTo($"/downloadfullfile/serviceproviderbordereau/UserID={Globals.userdetails.ServiceProviderID}&FirmID={selectedFirmID}", true);
            }
            catch { }
        }
    }
}
