using AutoMapper;
using Business.Dto.Company;

namespace Business.Repository.Company
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CMS.DocumentEngine.Types.MedioClinic.Company, CompanyDto>();
        }
    }
}
