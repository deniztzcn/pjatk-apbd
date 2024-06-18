using apbd_test2.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_test2.Data;

public class BookAuthorConfiguration: IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.HasKey(b => new { b.IdBook, b.IdAuthor });
        builder.HasOne(b => b.Book)
            .WithMany(b => b.BookAuthors);
        builder.HasOne(b => b.Author)
            .WithMany(a => a.BookAuthors);
        

    }
}