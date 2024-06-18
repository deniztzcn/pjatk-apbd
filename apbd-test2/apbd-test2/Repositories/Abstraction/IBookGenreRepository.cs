namespace apbd_test2.Repositories.Abstraction;

public interface IBookGenreRepository
{
    Task<List<string>> getBookGenres(int bookId);
}