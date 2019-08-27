using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Dto.Doctor;
using Business.Services.Context;
using Business.Services.Query;

namespace Business.Repository.Doctor
{
    public class DoctorRepository : BaseRepository, IDoctorRepository
    {
        private readonly string[] _doctorColumns =
        {
            "NodeAlias", "Bio", "Degree", "EmergencyShift", "FirstName",
            "LastName", "Photo", "Specialty"
        };

        private readonly ISiteContextService _siteContextService;

        public DoctorRepository(IMapper mapper, IDocumentQueryService documentQueryService,
            ISiteContextService siteContextService) : base(mapper, documentQueryService)
        {
            _siteContextService = siteContextService;
        }

        public IEnumerable<DoctorDto> GetDoctors()
        {
            return DocumentQueryService.GetDocuments<CMS.DocumentEngine.Types.MedioClinic.Doctor>().AddColumns(_doctorColumns).ToList()
                .Select(d => Mapper.Map<DoctorDto>(d));
        }

        public DoctorDto GetDoctor(Guid nodeGuid)
        {
            return DocumentQueryService.GetDocument<CMS.DocumentEngine.Types.MedioClinic.Doctor>(nodeGuid).AddColumns(_doctorColumns)
                .ToList()
                .Select(d => Mapper.Map<DoctorDto>(d)).FirstOrDefault();
        }
    }
}