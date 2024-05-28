using apbd_tutorial08.Application.DTOs;
using apbd_tutorial08.Models;

namespace TripApp.Application.Mappers;

public static class CountryMapper
{
    public static CountryDto MapToCountryDto(this Country country)
    {
        return new CountryDto
        {
            Name = country.Name
        };
    }
}