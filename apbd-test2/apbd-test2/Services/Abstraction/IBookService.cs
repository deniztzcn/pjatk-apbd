using apbd_test2.Models.Domain;
using apbd_test2.Models.ResponseDTOs;

namespace apbd_test2.Services.Abstraction;

public interface IBookService
{
    Task<List<Book>> GetBooks();
}