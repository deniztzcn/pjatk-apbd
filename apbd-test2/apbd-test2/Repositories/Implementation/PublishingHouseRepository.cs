using apbd_test2.Mappers;
using apbd_test2.Models.Domain;
using apbd_test2.Models.ResponseDTOs;
using apbd_test2.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace apbd_test2.Repositories.Implementation;

public class PublishingHouseRepository: IPublishingHouseRepository
{
    private AppDbContext _context;

    public PublishingHouseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<PublishingHouseResponseDto> GetPublishingHouseResponseDtoByBookId(int bookId)
    {
        return _context.Books.Include(b => b.PublishingHouse)
            .Where(b => b.IdBook == bookId)
            .Select(b => b.PublishingHouse).First().PublishingResponseDto();
    }
}