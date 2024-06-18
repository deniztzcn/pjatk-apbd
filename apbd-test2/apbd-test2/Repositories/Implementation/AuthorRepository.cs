using apbd_test2.Mappers;
using apbd_test2.Models.ResponseDTOs;
using apbd_test2.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace apbd_test2.Repositories.Implementation;

public class AuthorRepository: IAuthorsRepository
{
    private readonly AppDbContext _dbContext;

    public AuthorRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<AuthorResponseDto>> GetAuthorsByBookId(int bookId)
    {
        return await _dbContext.Books.Include(b => b.BookAuthors)
            .Where(b => b.IdBook == bookId)
            .SelectMany(b => b.BookAuthors.Select(b => b.Author.AuthorResponseDto()))
            .ToListAsync();
    }
}