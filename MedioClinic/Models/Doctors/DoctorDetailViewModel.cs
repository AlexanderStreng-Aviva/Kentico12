using Business.Dto.Doctor;

namespace MedioClinic.Models.Doctors
{
    public class DoctorDetailViewModel : IViewModel
    {
        public DoctorDto Doctor { get; set; }
    }
}