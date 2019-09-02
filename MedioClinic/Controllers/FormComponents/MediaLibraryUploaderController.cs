using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using CMS.Helpers;
using CMS.MediaLibrary;
using CMS.SiteProvider;
using MedioClinic.Utils;
using FileInfo = CMS.IO.FileInfo;

namespace MedioClinic.Controllers.FormComponents
{
    public class MediaLibraryUploaderController : Controller
    {
        public MediaLibraryUploaderController(IFileManagementHelper fileManagementHelper, IErrorHelper errorHandler)
        {
            FileManagementHelper =
                fileManagementHelper ?? throw new ArgumentNullException(nameof(fileManagementHelper));
            ErrorHelper = errorHandler ?? throw new ArgumentNullException(nameof(errorHandler));
        }

        protected string TempPath => $"{Server.MapPath(@"~\")}App_Data\\Temp\\MediaLibraryUploader";

        protected IFileManagementHelper FileManagementHelper { get; }

        protected IErrorHelper ErrorHelper { get; }

        [HttpPost]
        public ActionResult Upload(string filePathId, int mediaLibraryId)
        {
            if (Request.Files[0] is HttpPostedFileWrapper file && file != null)
            {
                string directoryPath = null;

                try
                {
                    directoryPath = FileManagementHelper.EnsureUploadDirectory(TempPath);
                }
                catch (Exception ex)
                {
                    return ErrorHelper.HandleException(nameof(MediaLibraryUploaderController), nameof(Upload), ex);
                }

                if (!string.IsNullOrEmpty(directoryPath))
                {
                    string imagePath = null;

                    try
                    {
                        imagePath = FileManagementHelper.GetTempFilePath(directoryPath, file.FileName);
                    }
                    catch (Exception ex)
                    {
                        return ErrorHelper.HandleException(nameof(MediaLibraryUploaderController), nameof(Upload), ex);
                    }

                    if (!string.IsNullOrEmpty(imagePath))
                    {
                        FileInfo fileInfo = null;

                        try
                        {
                            fileInfo = GetFileInfo(file, imagePath);
                        }
                        catch (Exception ex)
                        {
                            return ErrorHelper.HandleException(
                                nameof(MediaLibraryUploaderController),
                                nameof(Upload),
                                ex,
                                ErrorHelper.UnprocessableStatusCode);
                        }

                        if (fileInfo != null) return CreateMediaFile(filePathId, mediaLibraryId, imagePath, fileInfo);
                    }
                }
            }

            return new HttpStatusCodeResult(ErrorHelper.UnprocessableStatusCode);
        }

        protected FileInfo GetFileInfo(HttpPostedFileWrapper file, string filePath)
        {
            var data = new byte[file.ContentLength];
            file.InputStream.Seek(0, SeekOrigin.Begin);
            file.InputStream.Read(data, 0, file.ContentLength);
            CMS.IO.File.WriteAllBytes(filePath, data);

            var fileInfo = FileInfo.New(filePath);

            return fileInfo;
        }

        protected MediaFileInfo CreateMediafileInfo(int mediaLibraryId, FileInfo fileInfo)
        {
            var mediaFile = new MediaFileInfo(fileInfo?.FullName, mediaLibraryId)
            {
                FileName = fileInfo.Name.Substring(0, fileInfo.Name.Length - fileInfo.Extension.Length),
                FileExtension = fileInfo.Extension,
                FileMimeType = MimeTypeHelper.GetMimetype(fileInfo.Extension),
                FileSiteID = SiteContext.CurrentSiteID,
                FileLibraryID = mediaLibraryId,
                FileSize = fileInfo.Length
            };

            MediaFileInfoProvider.SetMediaFileInfo(mediaFile);
            return mediaFile;
        }

        protected ActionResult CreateMediaFile(string filePathId, int mediaLibraryId, string imagePath,FileInfo fileInfo)
        {
            MediaFileInfo mediaFileInfo = null;

            try
            {
                mediaFileInfo = CreateMediafileInfo(mediaLibraryId, fileInfo);
            }
            catch (Exception ex)
            {
                return ErrorHelper.HandleException(
                    nameof(MediaLibraryUploaderController),
                    nameof(CreateMediaFile),
                    ex,
                    ErrorHelper.UnprocessableStatusCode);
            }

            try
            {
                CMS.IO.File.Delete(imagePath);
            }
            catch (Exception ex)
            {
                ErrorHelper.LogException(nameof(Upload), "", ex);
            }

            return Json(new
            {
                filePathId,
                fileGuid = mediaFileInfo.FileGUID.ToString()
            });
        }
    }
}