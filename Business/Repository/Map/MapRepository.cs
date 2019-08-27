using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Dto.Map;
using Business.Services.Query;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Map
{
    public class MapRepository : BaseRepository, IMapRepository
    {
        public MapRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper, documentQueryService)
        {
        }

        public IEnumerable<MapLocationDto> GetOfficeLocations()
        {
            return DocumentQueryService.GetDocuments<MapLocation>()
                .AddColumns("Longitude", "Latitude", "Tooltip")
                .OrderByAscending("NodeOrder")
                .ToList()
                .Select(mld => Mapper.Map<MapLocationDto>(mld));
        }
    }
}