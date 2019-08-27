using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Dto.Menu;
using Business.Services.Query;
using CMS.DocumentEngine;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Menu
{
    public class MenuItemRepository : BaseRepository, IMenuRepository
    {
        public MenuItemRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper, documentQueryService)
        {
        }

        public IEnumerable<MenuItemDto> GetMenuItems()
        {
            return DocumentQueryService.GetDocuments<MenuContainerItem>()
                .Path("/Menu-items", PathTypeEnum.Children)
                .AddColumns("Controller", "Action", "Caption")
                .OrderByAscending("NodeOrder")
                .ToList()
                .Select(mi => Mapper.Map<MenuItemDto>(mi));
        }
    }
}