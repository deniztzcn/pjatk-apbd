namespace apbd_test2.Models.ResponseDTOs;

public class PublishingHouseResponseDto
{
    public string Name { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public List<BookResponseDto> Books { get; set; }
    
}