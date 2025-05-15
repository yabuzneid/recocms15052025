using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using RecoCms6.Models;
using Syncfusion.Blazor.FileManager;
using Syncfusion.Blazor.Inputs;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecoCms6.Shared
{
    public partial class FileUploaderComponent : ComponentBase
    {
        [Parameter]
        public string Url { get; set; }
        [Parameter]
        public Action<FileResponse> UploadCompletedEvent { get; set; }
        public SfUploader FileUploader { get; set; }
        public List<SFFileInfo> Files { get; set; }

        public void OnChange(SelectedEventArgs args)
        {
            if(Files == null)
            {
                Files = new List<SFFileInfo>();
            }

            Files.AddRange(args.FilesData.Select(f => new SFFileInfo() { Name = f.Name, Type = f.Type }));
        }

        public void OnChangeUploader(UploadChangeEventArgs args)
        {
            
        }

        public void OnClear(ClearingEventArgs args)
        {
            Files = new List<SFFileInfo>();
        }


        public void UploadCompleted(Syncfusion.Blazor.Inputs.SuccessEventArgs args)
        {
            var responseJson = args.Response.Headers.Split("\n").First(x => x.Contains("upload-response:"));
            responseJson = responseJson.Substring(responseJson.IndexOf(":") + 1).TrimStart();
            var response = JsonConvert.DeserializeObject<FileResponse>(responseJson);

            if (UploadCompletedEvent != null)
            {
                UploadCompletedEvent.Invoke(response);
            }
        }
    }

    public class SFFileInfo
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
