using System;
using System.IO;
using Syncfusion.Pdf;
using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using Syncfusion.XlsIO;
using Syncfusion.XlsIORenderer;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using System.Collections.Generic;
using Microsoft.JSInterop;
using Radzen.Blazor;
using Microsoft.AspNetCore.Components;
using AutoMapper;
using System.Threading.Tasks;
using RecoCms6.Models.RecoDb;

namespace RecoCms6.Pages
{
    public partial class FileViewerComponent
    {
        protected RadzenHtml divPdfViewer;

        [Parameter]
        public RecoCms6.Models.RecoDb.File File { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        protected async System.Threading.Tasks.Task ShowFileAsync(Models.RecoDb.File file)
        {
            string base64 = string.Empty;

            if (file != null)
            {
                using (var stream = new MemoryStream(file.StoredDocument))
                {
                    PdfDocument pdfDocument = new PdfDocument();
                    int fileType;

                    if (file.ContentType != null && fileTypeMap.TryGetValue(file.ContentType.Trim(), out fileType))
                    {
                        switch (fileType)
                        {
                            case (int)FileTypes.Pdf:
                            case (int)FileTypes.Document:
                                base64 = Convert.ToBase64String(file.StoredDocument);
                                break;
                            case (int)FileTypes.AudioVideo:
                                break;
                            case (int)FileTypes.Image:
                                var image = PdfImage.FromStream(stream);
                                PdfPage page = pdfDocument.Pages.Add();
                                page.Graphics.DrawImage(image, new PointF(0, 0));
                                base64 = GetBase64Path(pdfDocument);
                                break;
                            case (int)FileTypes.Word:
                                var wordDoc = new WordDocument(stream, FormatType.Automatic);
                                DocIORenderer wordRenderer = new DocIORenderer();
                                wordRenderer.Settings.ChartRenderingOptions.ImageFormat = Syncfusion.OfficeChart.ExportImageFormat.Jpeg;
                                pdfDocument = wordRenderer.ConvertToPDF(wordDoc);
                                wordRenderer.Dispose();
                                wordDoc.Dispose();
                                base64 = GetBase64Path(pdfDocument);
                                break;
                            case (int)FileTypes.File:
                                break;
                            case (int)FileTypes.Excel:
                                using (ExcelEngine excelEngine = new ExcelEngine())
                                {
                                    IApplication application = excelEngine.Excel;
                                    IWorkbook workbook = application.Workbooks.Open(stream);
                                    XlsIORenderer xlsRenderer = new XlsIORenderer();
                                    pdfDocument = xlsRenderer.ConvertToPDF(workbook);
                                    base64 = GetBase64Path(pdfDocument);
                                }
                                break;
                            default:
                                await DownloadFileAsync(file);
                                break;
                        }
                    }
                    else
                    {
                        await DownloadFileAsync(file);
                    }
                }

                if (!string.IsNullOrEmpty(base64))
                {
                    DocumentPath = "data:application/pdf;base64," + base64;
                }
                else
                    SaveErrorAsync("Unable to get base64", file.ClaimID);
            }
        }

        protected async Task SaveErrorAsync(String message, int claimID)
        {
            try
            {
                var errorLog = new ErrorLog();
                errorLog.ClaimID = claimID;
                errorLog.ErrorMessage = message;
                errorLog.UserID = Security.User.Id;
                await RecoDb.CreateErrorLog(errorLog);
            }
            catch { }
        }

        private static string GetBase64Path(PdfDocument pdfDocument)
        {
            string base64;
            using (MemoryStream pdfStream = new MemoryStream())
            {
                pdfDocument.Save(pdfStream);
                pdfStream.Position = 0;
                base64 = Convert.ToBase64String(pdfStream.ToArray());
            }

            return base64;
        }

        private readonly Dictionary<string, int> fileTypeMap = new Dictionary<string, int>
        {
            {"application/pdf", 522 },
            {"application/msword", 521 },
            {"application/vnd.openxmlformats-officedocument.wordprocessingml.document", 521 },
            {"application/vnd.ms-excel", 523 },
            {"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 523},
            { "image/png", 525},
            { "image/jpeg", 525}
        };

        private async System.Threading.Tasks.Task DownloadFileAsync(Models.RecoDb.File file) {
            //viewerVisible = false;
            await JSRuntime.InvokeAsync<object>("FileSaveAs", file.Filename, $"data:{file.ContentType.Trim()};base64," + Convert.ToBase64String(file.StoredDocument));
        }
    }
}
