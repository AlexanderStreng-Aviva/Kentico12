using System.Linq;
using AutoMapper;
using Business.Dto.Company;
using Business.Services.Query;

namespace Business.Repository.Company
{
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper, documentQueryService)
        {
        }

        public CompanyDto GetCompany()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.Company>()
                .AddColumns("CompanyName", "Street", "City", "Country", "ZipCode", "PhoneNumber", "Email")
                .TopN(1)
                .ToList()
                .Select(company =>
                {
                    var mapped = Mapper.Map<CompanyDto>(company);

                    var (country, state) = GetCountryStateFromCompany(company);
                    mapped.Country = country;
                    mapped.State = state;

                    return mapped;
                }).FirstOrDefault();
        }

        private static (string country, string state) GetCountryStateFromCompany(CMS.DocumentEngine.Types.MedioClinic.Company company)
        {
            var splitCountry = company.Country.Split(';');
            string country;
            string state = null;

            if (splitCountry.Length == 2)
            {
                country = splitCountry[0];
                state = splitCountry[1];
            }
            else
            {
                country = company.Country;
            }

            return (country, state);
        }
    }
}