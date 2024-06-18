using apbd_test2.Models.Domain;
using apbd_test2.Models.ResponseDTOs;

namespace apbd_test2.Mappers;

public static class BookMapper
{
    public static BookResponseDto BookResponseDto(this Book book)
    {
        return new BookResponseDto
        {
            BookName = book.Name,
            ReleaseDate = book.ReleaseDate
        };
    }
}