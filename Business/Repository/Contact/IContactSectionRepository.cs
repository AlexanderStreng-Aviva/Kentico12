using Business.Dto.ContactSection;

namespace Business.Repository.Contact
{
    public interface IContactSectionRepository : IRepository
    {
        ContactSectionDto GetContactSection();
    }
}