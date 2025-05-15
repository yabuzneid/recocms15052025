using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Forms;
using Agno.BlazorInputFile;


namespace RecoCms6.Utility;

public static class FileConversionHelper
{
    public static IFileListEntry ToIFileListEntry(this IBrowserFile browserFile)
    {
        return new FileListEntry
        {
            Name = browserFile.Name,
            Size = browserFile.Size,
            Type = browserFile.ContentType,
            LastModified = browserFile.LastModified.DateTime,
            Data = browserFile.OpenReadStream()
        };
    }
}

public class FileListEntry : IFileListEntry
{
    public async Task<IFileListEntry> ToImageFileAsync(string format, int maxWidth, int maxHeight)
    {
        return this;
    }

    public DateTime LastModified { get; set; }
    public string Name { get; set; }
    public long Size { get; set; }
    public string Type { get; set; }
    public string RelativePath { get; set; }
    public Stream Data { get; set; }
    public event EventHandler OnDataRead;
}
