using System.Collections.Generic;
using Business.Dto.CompanyService;
using Business.Dto.Home;

namespace MedioClinic.Models.Home
{
    public class HomeViewModel : IViewModel
    {
        public HomeSectionDto HomeSection { get; set; }
        public IEnumerable<CompanyServiceDto> CompanyServices { get; set; }
    }
}