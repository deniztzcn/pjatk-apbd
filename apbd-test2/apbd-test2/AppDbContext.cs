using apbd_test2.Models;
using apbd_test2.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace apbd_test2;

public class AppDbContext: DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<PublishingHouse> PublishingHouses { get; set; }
    public DbSet<BookGenre> BookGenres { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Genre> Genres { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}