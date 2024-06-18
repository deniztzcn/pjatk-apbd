using apbd_test2.Mappers;
using apbd_test2.Models.ResponseDTOs;
using apbd_test2.Services.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace apbd_test2.Controllers;

[ApiController]
[Route("api")]
public class BookController: ControllerBase
{
    private readonly BookGenreService _bookGenreService;
    private readonly BookService _bookService;
    private readonly AuthorService _authorService;

    public BookController(BookGenreService bookGenreService, BookService bookService, AuthorService authorService)
    {
        _bookGenreService = bookGenreService;
        _bookService = bookService;
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBookInformations(bool filterByCity, bool filterByCountry)
    {
        var books = await _bookService.GetBooks();
        var allData = new List<PublishingHouseResponseDto>();
        var bookDTOs = new List<BookResponseDto>();
        foreach (var book in books)
        {
            BookResponseDto responseDto = book.BookResponseDto();
            var authors = await _authorService.GetAuthorDTOs(book.IdBook);
            var genres = await _bookGenreService.GetGenresByBookId(book.IdBook);
            responseDto.Authors = authors;
            responseDto.ListOfGenres = genres;
            bookDTOs.Add(responseDto);
        }
    }
}