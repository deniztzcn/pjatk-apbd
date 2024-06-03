using apbd_tutorial09.DTOs;
using apbd_tutorial09.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tutorial09.Controller;

[ApiController]
[Route("api/prescriptions")]
public class HospitalController: ControllerBase
{
    private readonly PrescriptionService _prescriptionService;

    public HospitalController(PrescriptionService prescriptionService)
    {
        _prescriptionService = prescriptionService;
    }
    
    [HttpPost]
    public async Task<IActionResult> addPrescriptionWithPatient([FromBody] PrescriptionRequestDto prescriptionRequestDto)
    {
        await _prescriptionService.AddPrescriptionWithPatient(prescriptionRequestDto);
        return Ok();
    }
}