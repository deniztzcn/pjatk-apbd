using apbd_test2.Repositories.Implementation;
using apbd_test2.Services.Abstraction;

namespace apbd_test2.Services.Implementation;

public class BookGenreService: IBookGenreService
{
    private BookGenreRepository _genreRepository;

    public BookGenreService(BookGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    public async Task<List<string>> GetGenresByBookId(int bookId)
    {
        return await _genreRepository.getBookGenres(bookId);
    }
}