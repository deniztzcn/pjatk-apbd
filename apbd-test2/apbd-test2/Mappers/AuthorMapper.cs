using apbd_test2.Models.Domain;
using apbd_test2.Models.ResponseDTOs;

namespace apbd_test2.Mappers;

public static class AuthorMapper
{
    public static AuthorResponseDto AuthorResponseDto(this Author author)
    {
        return new AuthorResponseDto
        {
            Name = author.FirstName,
            LastName = author.LastName
        };
    }
}