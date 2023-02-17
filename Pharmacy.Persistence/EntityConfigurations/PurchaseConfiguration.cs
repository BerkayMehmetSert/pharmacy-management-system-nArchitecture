using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Persistence.EntityConfigurations;

public class PurchaseConfiguration : IEntityTypeConfiguration<Purchase>
{
    public void Configure(EntityTypeBuilder<Purchase> builder)
    {
        builder.ToTable("Purchases");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.MedicineId);
        builder.Property(x => x.CustomerId);
        builder.Property(x => x.Amount).IsRequired();
        builder.Property(x => x.CreatedDate);
        builder.Property(x => x.UpdatedDate);
        
        builder.HasOne(x => x.Medicine);
        builder.HasOne(x => x.Customer);
        builder.HasMany(x => x.Sales);
    }
}