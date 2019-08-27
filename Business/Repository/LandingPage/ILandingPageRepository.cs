using Business.Dto.LandingPage;

namespace Business.Repository.LandingPage
{
    public interface ILandingPageRepository : IRepository
    {
        LandingPageDto GetLandingPageDto(string pageAlias);
    }
}