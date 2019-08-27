using System.Linq;
using AutoMapper;
using Business.Dto.Doctor;
using Business.Services.Query;
using CMS.DocumentEngine.Types.MedioClinic;

namespace Business.Repository.Doctor
{
    public class DoctorSectionRepository : BaseRepository, IDoctorSectionRepository
    {
        public DoctorSectionRepository(IMapper mapper, IDocumentQueryService documentQueryService) : base(mapper, documentQueryService)
        {
        }

        public DoctorSectionDto GetDoctorSection()
        {
            return DocumentQueryService.GetDocuments<DoctorSection>()
                .AddColumns("Title")
                .TopN(1)
                .ToList()
                .Select(ds => new DoctorSectionDto
                {
                    Header = ds.Title
                })
                .FirstOrDefault();
        }
    }
}