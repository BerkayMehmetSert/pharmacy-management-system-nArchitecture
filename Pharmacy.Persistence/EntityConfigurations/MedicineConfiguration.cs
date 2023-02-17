using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Persistence.EntityConfigurations;

public class MedicineConfiguration : IEntityTypeConfiguration<Medicine>
{
    public void Configure(EntityTypeBuilder<Medicine> builder)
    {
        builder.ToTable("Medicines");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CategoryId);
        builder.Property(x => x.Description);
        builder.Property(x => x.Price).IsRequired();
        builder.Property(x => x.CreatedDate);
        builder.Property(x => x.UpdatedDate);

        builder.HasOne(x => x.Category);
        builder.HasMany(x => x.Sales);
        builder.HasMany(x => x.Purchases);
    }
}