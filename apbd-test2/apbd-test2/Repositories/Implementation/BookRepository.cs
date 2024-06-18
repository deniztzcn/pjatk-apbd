using apbd_test2.Mappers;
using apbd_test2.Models.Domain;
using apbd_test2.Models.ResponseDTOs;
using apbd_test2.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace apbd_test2.Repositories.Implementation;

public class BookRepository: IBookRepository
{
    private readonly AppDbContext _dbContext;

    public BookRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _dbContext.Books.ToListAsync();
    }
}