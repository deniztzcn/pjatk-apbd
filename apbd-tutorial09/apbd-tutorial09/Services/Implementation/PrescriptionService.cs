using apbd_tutorial09.DTOs;
using apbd_tutorial09.Repositories.Abstraction;
using apbd_tutorial09.Services.Abstraction;

namespace apbd_tutorial09.Services.Implementation;

public class PrescriptionService: IPrescriptionService
{
    private readonly IPrescriptionRepository _prescriptionRepository;

    public async Task<PrescriptionResponseDto> AddPrescriptionWithPatient(PrescriptionRequestDto prescriptionRequestDto)
    {
        return await _prescriptionRepository.AddPrescriptionWithPatient(prescriptionRequestDto);
    }
}