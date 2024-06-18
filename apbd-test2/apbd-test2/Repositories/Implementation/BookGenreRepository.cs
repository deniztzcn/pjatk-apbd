using apbd_test2.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace apbd_test2.Repositories.Implementation;

public class BookGenreRepository: IBookGenreRepository
{
    private readonly AppDbContext _dbContext;

    public BookGenreRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<string>> getBookGenres(int bookId)
    {
        var listOfGenres = await _dbContext.Books.Include(b => b.BookGenres)
            .Where(b => b.IdBook == bookId)
            .SelectMany(b => b.BookGenres.Select(bg => bg.Genre.Name)).ToListAsync();
        return listOfGenres;
    }
}