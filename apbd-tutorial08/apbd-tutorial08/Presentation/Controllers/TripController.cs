using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Application.Services.Abstraction;
using apbd_tutorial08.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tutorial08.Presentation.Controllers;

[ApiController]
[Route("api/trips")]
public class TripController: ControllerBase
{
    private readonly ITripService _tripService;

    public TripController(ITripService tripService)
    {
        _tripService = tripService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetTrips([FromQuery] int? page, int? pageSize)
    {
        if (page is null || pageSize is null)
            return Ok(await _tripService.GetAllTripsAsync());

        return Ok(await _tripService.GetPaginatedTripsAsync(page.Value, pageSize.Value));
    }

    [HttpPost("{idTrip}/clients")]
    public async Task<IActionResult> AssignClientToTrip(int idTrip, [FromBody] AssignClientDto assignClientDto)
    {
        try
        {
            await _tripService.AssignClientToTripAsync(idTrip, assignClientDto);
            return Ok();
        }
        catch (ClientAlreadyExists ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (ClientAlreadyRegisteredTrip ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (TripNotFound ex)
        {
            return NotFound(new { Message = ex.Message });
        }
        catch (TripAlreadyMade ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "some error occured" });
        }
    }

    [HttpPost]
    public async Task<IActionResult> addTrip([FromBody] TripDto tripDto)
    {
        await _tripService.AddTrip(tripDto);
        return Ok();
    }
    
}