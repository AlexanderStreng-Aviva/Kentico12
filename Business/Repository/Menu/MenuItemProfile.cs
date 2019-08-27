using AutoMapper;
using Business.Dto.Menu;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Menu
{
    public class MenuItemProfile : Profile
    {
        public MenuItemProfile()
        {
            CreateMap<MenuContainerItem, MenuItemDto>();
        }
    }
}