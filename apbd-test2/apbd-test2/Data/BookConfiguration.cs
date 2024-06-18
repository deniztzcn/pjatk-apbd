using apbd_test2.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_test2.Data;

public class BookConfiguration: IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.IdBook);
        builder.HasOne(b => b.PublishingHouse)
            .WithMany(ph => ph.Books)
            .HasForeignKey(b => b.IdPublishingHouse);
        builder.Property(b => b.Name).HasMaxLength(50).IsRequired();
        
    }
}