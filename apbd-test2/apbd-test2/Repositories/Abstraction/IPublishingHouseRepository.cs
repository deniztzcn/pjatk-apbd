using apbd_test2.Models.ResponseDTOs;

namespace apbd_test2.Repositories.Abstraction;

public interface IPublishingHouseRepository
{
    Task<PublishingHouseResponseDto> GetPublishingHouseResponseDtoByBookId(int bookId);
}