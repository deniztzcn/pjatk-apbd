namespace apbd_test2.Services.Abstraction;

public interface IBookGenreService
{
    Task<List<string>> GetGenresByBookId(int bookId);
}