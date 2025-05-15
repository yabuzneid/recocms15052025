using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.PdfViewerServer;

namespace RecoCms6.Shared
{
    public partial class PdfViewerComponent : ComponentBase
    {
        [Parameter]
        public string DocumentPath { get; set; }

        public SfPdfViewerServer pdfViewer { get; set; }
    }
}
