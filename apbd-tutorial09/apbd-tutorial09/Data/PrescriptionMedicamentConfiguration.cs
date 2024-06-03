using apbd_tutorial09.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace apbd_tutorial09.Data;

public class PrescriptionMedicamentConfiguration: IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> b)
    {
        b.ToTable("Prescription_Medicament");
        b.HasKey(b => new { b.IdPrescription, b.IdMedicament });
        b.Property(pm => pm.Dose).HasMaxLength(100);
        b.Property(pm => pm.Details).HasMaxLength(100).IsRequired();
        b.HasOne(pm => pm.Prescription)
            .WithMany(p => p.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription);
        b.HasOne(pm => pm.Medicament)
            .WithMany(m => m.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament);
    }
}