namespace apbd_test2.Models.Domain;

public class Author
{
    public int IdAuthor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }
}