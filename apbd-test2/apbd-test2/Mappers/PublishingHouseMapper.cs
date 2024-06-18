using apbd_test2.Models.Domain;
using apbd_test2.Models.ResponseDTOs;

namespace apbd_test2.Mappers;

public static class PublishingHouseMapper
{
    public static PublishingHouseResponseDto PublishingResponseDto(this PublishingHouse publishingHouse)
    {
        return new PublishingHouseResponseDto
        {
            Name = publishingHouse.Name,
            City = publishingHouse.City,
            Country = publishingHouse.Country
        };
    }
}