using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Models;

namespace TripApp.Application.Mappers;

public static class TripMapper
{
    public static TripDto MapToTripDto(this Trip trip)
    {
        return new TripDto
        {
            Name = trip.Name,
            DateFrom = trip.DateFrom,
            DateTo = trip.DateTo,
            Description = trip.Description,
            MaxPeople = trip.MaxPeople,
            Countries = trip.IdCountries.Select(country => country.MapToCountryDto()).ToList(),
            Clients = trip.ClientTrips.Select(e => e.IdClientNavigation.MapToClientDto()).ToList()
        };
    }

    public static Trip MapToTrip(this TripDto dto)
    {
        return new Trip
        {
            Name = dto.Name,
            Description = dto.Description,
            MaxPeople = dto.MaxPeople,
            DateFrom = dto.DateFrom,
            DateTo = dto.DateTo
        };
    }
}