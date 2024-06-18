using apbd_test2.Models.ResponseDTOs;
using apbd_test2.Repositories.Implementation;
using apbd_test2.Services.Abstraction;

namespace apbd_test2.Services.Implementation;

public class AuthorService: IAuthorService
{
    private readonly AuthorRepository _authorRepository;

    public AuthorService(AuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task<List<AuthorResponseDto>> GetAuthorDTOs(int bookId)
    {
        return await _authorRepository.GetAuthorsByBookId(bookId);
    }
}