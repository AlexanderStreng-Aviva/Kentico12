using AutoMapper;
using Business.Dto.Doctor;

namespace Business.Repository.Doctor
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<CMS.DocumentEngine.Types.MedioClinic.Doctor, DoctorDto>()
                .ForMember(dst => dst.NodeId, opt => opt.MapFrom(src => src.NodeID))
                .ForMember(dst => dst.NodeGuid, opt => opt.MapFrom(src => src.NodeGUID))
                .ForMember(dst => dst.Photo, opt => opt.MapFrom(src => src.Fields.Photo));
        }
    }
}