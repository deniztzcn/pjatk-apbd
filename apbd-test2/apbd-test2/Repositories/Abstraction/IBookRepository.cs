using apbd_test2.Models.Domain;
using apbd_test2.Models.ResponseDTOs;

namespace apbd_test2.Repositories.Abstraction;

public interface IBookRepository
{
    Task<List<Book>> GetBooks();
}