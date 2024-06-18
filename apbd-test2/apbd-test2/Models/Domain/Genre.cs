namespace apbd_test2.Models.Domain;

public class Genre
{
    public int IdGenre { get; set; }
    public string Name { get; set; }
    public ICollection<BookGenre> BookGenres { get; set; }
}