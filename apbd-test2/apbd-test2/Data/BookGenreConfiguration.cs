using apbd_test2.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_test2.Data;

public class BookGenreConfiguration: IEntityTypeConfiguration<BookGenre>
{
    public void Configure(EntityTypeBuilder<BookGenre> builder)
    {
        builder.HasKey(bg => new { bg.IdBook, bg.IdGenre });
        builder.HasOne(bg => bg.Book)
            .WithMany(b => b.BookGenres);
        builder.HasOne(bg => bg.Genre)
            .WithMany(g => g.BookGenres);
    }
}