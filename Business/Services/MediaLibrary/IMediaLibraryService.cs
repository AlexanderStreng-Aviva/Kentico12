using System.Collections.Generic;
using Business.Dto.MediaLibrary;

namespace Business.Services.MediaLibrary
{
    public interface IMediaLibraryService : IService
    {
        IEnumerable<MediaLibraryFileDto> GetMediaLibraryFiles(string folder, string siteName,
            params string[] extensions);
    }
}