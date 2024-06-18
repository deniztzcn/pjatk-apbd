namespace apbd_test2.Models.Domain;

public class BookGenre
{
    public int IdGenre { get; set; }
    public int IdBook { get; set; }
    public Genre Genre { get; set; }
    public Book Book { get; set; }
}