using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Dto.Company;
using Business.Dto.Culture;
using Business.Dto.Menu;
using Business.Dto.Page;
using Business.Dto.Social;

namespace MedioClinic.Models
{
    public class PageViewModel : IViewModel
    {
        public CompanyDto Company { get; set; }
        public IEnumerable<CultureDto> Cultures { get; set; }
        public IEnumerable<SocialLinkDto> SocialLinks { get; set; }
        public PageMetadataDto PageMetadata { get; set; }
        public IEnumerable<MenuItemDto> MenuItems { get; set; }
    }

    public class PageViewModel<TViewModel> : PageViewModel where TViewModel : IViewModel
    {
        public TViewModel Data { get; set; }
    }
}