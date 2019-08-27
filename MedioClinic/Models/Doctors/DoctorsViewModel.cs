using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Dto.Doctor;

namespace MedioClinic.Models.Doctors
{
    public class DoctorsViewModel : IViewModel
    {
        public DoctorSectionDto DoctorSection { get; set; }

        public IEnumerable<DoctorDto> Doctors { get; set; }
    }
}