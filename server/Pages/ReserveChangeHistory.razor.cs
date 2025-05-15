using System.Threading.Tasks;

namespace RecoCms6.Pages;

public partial class ReserveChangeHistoryComponent
{
    private async Task DownloadFileAsync()
    {
        try
        {
            var uri = $"/downloadfullfile/reservechangehistory/UserID={Globals.userdetails.ServiceProviderID}?startDate={selectedStartDate}&endDate={selectedReportDate}&programId={selectedProgram}";
            UriHelper.NavigateTo(uri, true);
        }
        catch { }

    }
}