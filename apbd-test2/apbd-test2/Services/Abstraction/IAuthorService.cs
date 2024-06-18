using apbd_test2.Models.ResponseDTOs;

namespace apbd_test2.Services.Abstraction;

public interface IAuthorService
{
    Task<List<AuthorResponseDto>> GetAuthorDTOs(int bookId);
}