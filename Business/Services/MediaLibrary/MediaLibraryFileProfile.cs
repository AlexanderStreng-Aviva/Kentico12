using AutoMapper;
using Business.Dto.MediaLibrary;
using CMS.MediaLibrary;

namespace Business.Services.MediaLibrary
{
    public class MediaLibraryFileProfile : Profile
    {
        public MediaLibraryFileProfile()
        {
            CreateMap<MediaFileInfo, MediaLibraryFileDto>()
                .ForMember(dst => dst.Title, opt => opt.MapFrom(src => src.FileTitle))
                .ForMember(dst => dst.Extension, opt => opt.MapFrom(src => src.FileExtension))
                .ForMember(dst => dst.DirectUrl, opt => opt.MapFrom(src => MediaLibraryHelper.GetDirectUrl(src)))
                .ForMember(dst => dst.PermanentUrl, opt => opt.MapFrom(src => MediaLibraryHelper.GetPermanentUrl(src)));
        }
    }
}