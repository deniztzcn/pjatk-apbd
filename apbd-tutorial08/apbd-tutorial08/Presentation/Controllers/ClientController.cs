using apbd_tutorial08.Application.Services.Abstraction;
using apbd_tutorial08.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace apbd_tutorial08.Presentation.Controllers;
[ApiController]
[Route("api/clients")]

public class ClientController: ControllerBase
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpDelete("{idClient}")]
    public async Task<IActionResult> DeleteClient(int idClient)
    {
        try
        {
            await _clientService.DeleteClientAsync(idClient);
        }
        catch (NotFoundException ex)
        {
            return NotFound(new { ex.Message });
        }
        catch (ClientHasAssignedTrips ex)
        {
            return Conflict(new { ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "some error occured" });
        }
        return NoContent();
    }
}