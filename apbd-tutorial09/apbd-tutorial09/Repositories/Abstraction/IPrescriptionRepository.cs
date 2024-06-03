using apbd_tutorial09.DTOs;

namespace apbd_tutorial09.Repositories.Abstraction;

public interface IPrescriptionRepository
{
    Task<PrescriptionResponseDto> AddPrescriptionWithPatient(PrescriptionRequestDto prescriptionRequestDto);
}