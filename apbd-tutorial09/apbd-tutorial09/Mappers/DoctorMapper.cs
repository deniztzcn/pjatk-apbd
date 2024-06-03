using apbd_tutorial09.DTOs;
using apbd_tutorial09.Models;

namespace apbd_tutorial09.Mappers;

public static class DoctorMapper
{
    public static DoctorDto DoctorDto(this Doctor doctor)
    {
        return new DoctorDto
        {
            IdDoctor = doctor.IdDoctor,
            FirstName = doctor.FirstName
        };
    }
}