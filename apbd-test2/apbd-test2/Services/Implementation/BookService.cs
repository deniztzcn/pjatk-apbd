using apbd_test2.Models.Domain;
using apbd_test2.Models.ResponseDTOs;
using apbd_test2.Repositories.Implementation;
using apbd_test2.Services.Abstraction;

namespace apbd_test2.Services.Implementation;

public class BookService: IBookService
{
    private readonly BookRepository _bookRepository;

    public BookService(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<List<Book>> GetBooks()
    {
        return await _bookRepository.GetBooks();
    }
}