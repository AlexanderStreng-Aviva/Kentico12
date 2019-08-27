using AutoMapper;
using Business.Dto.Home;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Home
{
    public class HomeProfile : Profile
    {
        public HomeProfile()
        {
            CreateMap<HomeSection, HomeSectionDto>();
        }
    }
}