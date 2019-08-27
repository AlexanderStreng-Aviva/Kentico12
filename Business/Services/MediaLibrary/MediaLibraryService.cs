using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Dto.MediaLibrary;
using CMS.MediaLibrary;

namespace Business.Services.MediaLibrary
{
    public class MediaLibraryService : BaseService, IMediaLibraryService
    {
        private readonly IMapper _mapper;

        public MediaLibraryService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public IEnumerable<MediaLibraryFileDto> GetMediaLibraryFiles(string folder, string siteName,
            params string[] extensions)
        {
            var mediaLibrary = MediaLibraryInfoProvider.GetMediaLibraryInfo(folder, siteName);
            if (mediaLibrary == null)
            {
                return Enumerable.Empty<MediaLibraryFileDto>();
            }

            return MediaFileInfoProvider.GetMediaFiles()
                .WhereEquals("FileLibraryID", mediaLibrary.LibraryID)
                .WhereIn("FileExtension", extensions)
                .ToList()
                .Select(mf => _mapper.Map<MediaLibraryFileDto>(mf));
        }
    }
}