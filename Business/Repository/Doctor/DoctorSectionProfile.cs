using AutoMapper;
using Business.Dto.Doctor;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Doctor
{
    public class DoctorSectionProfile : Profile
    {
        public DoctorSectionProfile()
        {
            CreateMap<DoctorSection, DoctorSectionDto>();
        }
    }
}