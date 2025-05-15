using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Radzen;
using Radzen.Blazor;
using RecoCms6.Models.RecoDb;
using Newtonsoft.Json;
using RecoCms6.Models;
using RecoCms6.Shared;
using System.Collections.Concurrent;

namespace RecoCms6.Pages
{
    public partial class AddFileComponent
    {
        protected RadzenCheckBoxList<Role> chkBoxRoles;
        protected RadzenUpload upldDocument;
        protected RadzenLabel lblFile;
        protected FileUploaderComponent fileUploader;
        protected IEnumerable<Radzen.FileInfo> CurrentFiles { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            //if (firstRender)
            //{
            //    var helper = new PermissionsHelper(RecoDb);
            //    await helper.LoadCheckBoxAsync(true, chkBoxRoles, Security);
            //    roles = helper.CheckBoxValue;
            //}
        }
        protected BlockingCollection<int> Locks { get; set; }
        protected async Task UploadFiles()
        {
            if (fileUploader.Files == null || fileUploader.Files.Count == 0)
            {
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new file, no file selected!");
                return;
            }
            try
            {
                int fileNumber = fileUploader.Files.Count;
                Locks = new BlockingCollection<int>(fileNumber);
                Enumerable.Repeat(1, fileNumber).ToList().ForEach(i => Locks.Add(i));
                await fileUploader.FileUploader.UploadAsync();
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", file.ClaimID);
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new file!");
            }

        }
        protected async void UploadCompleted(FileResponse args)
        {
            try
            {
                await SaveFile(args);
            }
            catch (Exception ex)
            {
                string jsonMessage = JsonConvert.SerializeObject(ex);
                await RecoDb.AddErrorLogs($"{jsonMessage}", $"{Security.User.Id}", file.ClaimID);
                NotificationService.Notify(NotificationSeverity.Error, $"Error", $"Unable to create new file {args.Filename}!");
            }
            finally
            {
                Locks.Take();
                if (Locks.Count == 0)
                {
                    DialogService.Close(file);
                }
            }
        }
        private async Task SaveFile(FileResponse uploadResponse)
        {
            foreach (UploadedFileDetail fileDetail in uploadResponse.UploadedFileDetails)
            {
                var existingFile = await RecoDb.GetFileById(fileDetail.ID);

                if (existingFile == null || existingFile.ID == Guid.Empty || Locks.Count == 0)
                {
                    throw new Exception("Failed to save file!");
                }

                
                if (fileUploader.Files.Count == 1 && System.IO.Path.GetExtension(fileDetail.ParentFilename.Trim()) != ".zip")
                {
                    if (!String.IsNullOrEmpty(file.Subject))
                    {
                        existingFile.Subject = file.Subject;
                        existingFile.Filename = file.Subject + existingFile.Extension;
                    }
                }
                if (String.IsNullOrEmpty(existingFile.Subject)) //If there is no subject, set the subject to the filename
                    existingFile.Subject = existingFile.Filename.Replace(existingFile.Extension, "");

                existingFile.LargeLoss = file.LargeLoss;
                existingFile.Sticky = file.Sticky;
                existingFile.FileTypeID = file.FileTypeID;
                existingFile.Confidential = file.Confidential;

                if (System.IO.Path.GetExtension(fileDetail.ParentFilename.Trim()) != ".zip")
                    existingFile.FileDescription = file.FileDescription;

                if (Security.IsInRole("Defense Counsel")) //Files uploaded by Counsel are marked as Visible To Counsel
                    existingFile.VisibleToCounsel = true;
                else
                    existingFile.VisibleToCounsel = file.VisibleToCounsel;

                existingFile.Comments = file.Comments;

                var recoDbUpdateUploadedFilesResult = await RecoDb.UpdateUploadedFiles(existingFile.FileID, existingFile.Subject, existingFile.LargeLoss, existingFile.Sticky, existingFile.FileTypeID, existingFile.Confidential, existingFile.FileDescription, existingFile.VisibleToCounsel);
            }


        }
    }
}
