using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Models;

namespace TripApp.Application.Mappers;

public static class ClientMapper
{
    public static ClientDto MapToClientDto(this Client client)
    {
        return new ClientDto
        {
            FirstName = client.FirstName,
            LastName = client.LastName
        };
    }
}