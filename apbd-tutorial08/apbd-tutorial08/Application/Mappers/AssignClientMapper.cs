using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Models;

namespace TripApp.Application.Mappers;

public static class AssignClientMapper
{
    public static Client MapToClient(this AssignClientDto assignClientDto)
    {
        return new Client
        {
            FirstName = assignClientDto.FirstName,
            LastName = assignClientDto.LastName,
            Pesel = assignClientDto.Pesel,
            Email = assignClientDto.Email,
            Telephone = assignClientDto.Telephone,
        };
    }

    public static ClientTrip MapToClientTrip(this AssignClientDto assignClientDto)
    {
        return new ClientTrip
        {
            IdTrip = assignClientDto.IdTrip,
            IdClient = assignClientDto.MapToClient().IdClient,
            RegisteredAt = DateTime.Now,
            PaymentDate = assignClientDto.PaymentDate,
            IdClientNavigation = assignClientDto.MapToClient()
        };
    }
}