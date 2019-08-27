using AutoMapper;
using Business.Dto.Map;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Map
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<MapLocation, MapLocationDto>();
        }
    }
}