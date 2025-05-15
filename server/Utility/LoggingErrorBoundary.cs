using Hangfire.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Serilog;
using System;
using System.Threading.Tasks;

namespace RecoCms6.Utility;

public class LoggingErrorBoundary : ErrorBoundary
{
    [Inject]
    private NavigationManager NavigationManager { get; set; }
    [Inject]
    private NotificationService NotificationService { get; set; }
    [Inject]
    protected SecurityService Security { get; set; }


    protected override Task OnErrorAsync(Exception ex)
    {

        NotificationService.Notify(new NotificationMessage
        {
            Severity = NotificationSeverity.Error,
            Summary = "Error!",
            Detail = "Close the notification to refresh the page.",
            Duration = 4000,
            Close = _ => base.Recover()
        });


        Log.Error("Message: {0}.\nEndpoint: {1} {2}.\nStack Trace: {3}.\nUser:{4}.\n",
            ex.Message,
            "GET",
            NavigationManager.Uri,
            ex.StackTrace,
             Security.User.Name);
        return base.OnErrorAsync(ex);
    }
}