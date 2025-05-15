using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Newtonsoft.Json;
using RecoCms6.Data;
using RecoCms6.Models;

namespace RecoCms6
{
    public partial class UploadController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private readonly RecoDbContext _context;
        protected RecoDbService RecoDb { get; set; }

        public UploadController(IWebHostEnvironment environment, RecoDbContext context)
        {
            this.environment = environment;
            this._context = context;
        }

        public async Task<IActionResult> Download()
        {
            Stream stream = new MemoryStream(DynamicQueryableExtensions.FirstOrDefault(_context.Files)?.StoredDocument);

            if (stream == null)
                return NotFound();

            return File(stream, "application/octet-stream");
        }

        // Single file upload
        [HttpPost("upload/invoice")]
        public IActionResult Invoice(IFormFile file)
        {
            try
            {
                var invoicefile = new Models.RecoDb.InvoiceUploadFile();
                invoicefile.Filename = file.FileName;
                invoicefile.ContentType = file.ContentType;

                //Check if filename has been previously uploaded
                //if (await CheckPreviouslyUploadedInvoice(invoicefile.Filename))
                //    return StatusCode(500, "File has been previously uploaded");

                //Get stream from file.  
                Stream inputStream = file.OpenReadStream();
                using (var streamReader = new MemoryStream())
                {
                    inputStream.CopyTo(streamReader);
                    invoicefile.StoredInvoice = streamReader.ToArray();
                }

                // Put your code here
                return Ok(invoicefile);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Single file upload
        [HttpPost("upload/single")]
        public IActionResult Single(IFormFile file)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Multiple files upload
        [HttpPost("upload/multiple")]
        public IActionResult Multiple(IFormFile[] files)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Multiple files upload with parameter
        [HttpPost("upload/{id}")]
        public IActionResult Post(IFormFile[] files, int id)
        {
            try
            {
                // Put your code here
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Multiple files upload
        [HttpPost("upload/file/{claimId}/{userId}")]
        public async Task<IActionResult> Upload(int? claimId, string userId)
        {
            try
            {
                List<Models.RecoDb.File> savedFiles = new List<Models.RecoDb.File>();

                IFormFile file = Enumerable.Single(Request.Form.Files);

                if (Path.GetExtension(file.FileName.Trim()) == ".zip")
                {
                    var entries = await ExtractFiles(new MemoryStream(_ToBytes(file)));

                    foreach (var item in entries)
                    {
                        savedFiles.Add(_SaveFileExtractedFile(file, claimId, userId, item.Name.Trim(), item.FileBytesData));
                    }
                }
                else
                {
                    savedFiles.Add(_SaveFile(file, claimId, userId));
                }

                var response = new FileResponse() { ID = savedFiles[0].ID, Filename = savedFiles[0].Filename, Filesize = savedFiles[0].Filesize.Value };
                response.UploadedFileDetails = savedFiles.Select(x => new UploadedFileDetail { ID = x.ID, Filename = x.Filename, Filesize = x.Filesize.Value, ParentFilename = file.FileName.Trim() }).ToList();

                Response.Headers.Add("upload-response", JsonConvert.SerializeObject(response));
                return Ok();
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                _ = RecoDb.AddErrorLogs($"{jsonMessage}", userId, claimId);
                return StatusCode(500, ex.Message);
            }
        }

        private Models.RecoDb.File _SaveFile(IFormFile file, int? claimId, string uploadedBy)
        {

            var claimFile = new Models.RecoDb.File()
            {
                ID = Guid.NewGuid(),
                ClaimID = (int)claimId,
                Filename = file.FileName.Trim(),
                EntryDate = DateTime.UtcNow,
                Extension = Path.GetExtension(file.FileName),
                UploadedById = uploadedBy,
                StoredDocument = _ToBytes(file),
                Subject = file.FileName.Trim(),
                ContentType = file.ContentType.Trim()
            };

            _context.Files.Add(claimFile);
            _context.SaveChanges();

            return claimFile;
        }

        private Models.RecoDb.File _SaveFileExtractedFile(IFormFile file, int? claimId, string uploadedBy, string fileName, byte[] fileBytes)
        {
            var claimFile = new Models.RecoDb.File()
            {
                ID = Guid.NewGuid(),
                ClaimID = (int)claimId,
                Filename = fileName.Trim(),
                EntryDate = DateTime.UtcNow,
                Extension = Path.GetExtension(fileName.Trim()),
                UploadedById = uploadedBy,
                StoredDocument = fileBytes,
                Subject = fileName.Trim(),
                ContentType = GetContentType(fileName),
                FileDescription = "Extracted from " + file.FileName
            };

            _context.Files.Add(claimFile);
            _context.SaveChanges();

            return claimFile;
        }

        private static string GetContentType(string fileName)
        {
            new FileExtensionContentTypeProvider().TryGetContentType(fileName, out var contentType);
            return contentType;
        }

        public async Task<List<ZipEntry>> ExtractFiles(Stream stream, string basePath = "")
        {
            var archive = new ZipArchive(stream);
            var entries = new List<ZipEntry>();

            foreach (var entry in archive.Entries)
            {
                var fileStream = entry.Open();
                var fileBytes = await fileStream.ReadFully();
                var content = Encoding.UTF8.GetString(fileBytes);
                var type = GetContentType(entry.Name);
                switch (type)
                {
                    case "application/x-zip-compressed":
                        var innerStream = new MemoryStream();
                        await entry.Open().CopyToAsync(innerStream);
                        entries.AddRange(await ExtractFiles(innerStream,$"{basePath}{entry.FullName.Split("/").FirstOrDefault()}/"));
                        break;
                    case not null:
                        entries.Add(new ZipEntry { Name = basePath+entry.FullName, Content = content, FileBytesData = fileBytes, FileStreamData = fileStream });
                    break;
                }
            }

            return entries;
        }

        private byte[] _ToBytes(IFormFile upload)
        {
            byte[] bytes;

            using (var memoryStream = new MemoryStream())
            {
                upload.CopyTo(memoryStream);
                bytes = memoryStream.ToArray();
            }

            return bytes;
        }

        // Single file upload
        [HttpPost("upload/single/{claimId}/{userId}")]
        public IActionResult Single(IFormFile file, int? claimId, string userId)
        {
            try
            {
                Models.RecoDb.File savedFile = _SaveFile(file, claimId, userId);
                return Ok(new FileResponse() { ID = savedFile.ID, Filename = savedFile.Filename, Filesize = savedFile.Filesize.Value });
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                _ = RecoDb.AddErrorLogs($"{jsonMessage}", userId, claimId);
                return StatusCode(500, ex.Message);
            }
        }

        // Image file upload (used by HtmlEditor components)
        [HttpPost("upload/image")]
        public IActionResult Image(IFormFile file)
        {
            try
            {
                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";

                using (var stream = new FileStream(Path.Combine(environment.WebRootPath, fileName), FileMode.Create))
                {
                    // Save the file
                    file.CopyTo(stream);

                    // Return the URL of the file
                    var url = Url.Content($"~/{fileName}");

                    return Ok(new { Url = url });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
    public class ZipEntry
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string Type { get; set; }
        public byte[] FileBytesData { get; set; }
        public Stream FileStreamData { get; set; }
    }

    public static class StreamExtension
    {
        public static async Task<byte[]> ReadFully(this Stream input)
        {
            await using var ms = new MemoryStream();
            await input.CopyToAsync(ms);
            return ms.ToArray();
        }
    }

}