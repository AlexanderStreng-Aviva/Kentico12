using System;
using System.Collections.Generic;
using Business.Dto.Doctor;

namespace Business.Repository.Doctor
{
    public interface IDoctorRepository
    {
        IEnumerable<DoctorDto> GetDoctors();

        DoctorDto GetDoctor(Guid nodeGuid);
    }
}