using apbd_test2.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_test2.Data;

public class PublishingHouseConfiguration: IEntityTypeConfiguration<PublishingHouse>
{
    public void Configure(EntityTypeBuilder<PublishingHouse> builder)
    {
        builder.HasKey(ph => ph.IdPublishingHouse);
        builder.Property(ph => ph.Name).HasMaxLength(50).IsRequired();
        builder.Property(ph => ph.Country).HasMaxLength(50).IsRequired();
        builder.Property(ph => ph.City).HasMaxLength(50).IsRequired();
    }
}