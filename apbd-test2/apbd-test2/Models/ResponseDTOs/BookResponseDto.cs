namespace apbd_test2.Models.ResponseDTOs;

public class BookResponseDto
{
    public string BookName { get; set; }
    public DateTime ReleaseDate { get; set; }
    public List<string> ListOfGenres { get; set; }
    public List<AuthorResponseDto> Authors { get; set; }
}