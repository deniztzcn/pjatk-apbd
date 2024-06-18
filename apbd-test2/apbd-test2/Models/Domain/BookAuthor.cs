namespace apbd_test2.Models.Domain;

public class BookAuthor
{
    public int IdBook { get; set; }
    public int IdAuthor { get; set; }
    public Book Book { get; set; }
    public Author Author { get; set; }
}