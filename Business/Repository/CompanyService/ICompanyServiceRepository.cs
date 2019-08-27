using System.Collections.Generic;
using Business.Dto.CompanyService;

namespace Business.Repository.CompanyService
{
    public interface ICompanyServiceRepository
    {
        IEnumerable<CompanyServiceDto> GetCompanyServices();
    }
}
