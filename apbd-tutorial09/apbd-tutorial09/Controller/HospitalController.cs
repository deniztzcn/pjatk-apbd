using apbd_tutorial09.DTOs;
using apbd_tutorial09.Exceptions;
using apbd_tutorial09.Services.Abstraction;
using apbd_tutorial09.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tutorial09.Controller;

[ApiController]
[Route("api")]
public class HospitalController: ControllerBase
{
    private readonly IHospitalService _hospitalService;

    public HospitalController(IHospitalService hospitalService)
    {
        _hospitalService = hospitalService;
    }

    [HttpPost("prescriptions")]
    public async Task<IActionResult> AddPrescriptionWithPatientAsync([FromBody] PrescriptionRequestDto prescriptionRequestDto)
    {
        try
        {
            await _hospitalService.AddPrescriptionWithPatient(prescriptionRequestDto);
        }
        catch (DueDateEarlierThanDate ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (MedicamentNotFound ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (MedicamentListTooLong ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception)
        {
            return StatusCode(500, new { Message = "Some error occured" });
        }
        
        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPatientInformation(int id)
    {
        try
        {
            var result = await _hospitalService.GetPatientDetailsAsync(id);
            return Ok(result);
        }
        catch (PatientNotFound ex)
        {
            return NotFound(new {Message = ex.Message});
        }
        catch (Exception)
        {
            return StatusCode(500, "Some error occured");
        }
    }
}