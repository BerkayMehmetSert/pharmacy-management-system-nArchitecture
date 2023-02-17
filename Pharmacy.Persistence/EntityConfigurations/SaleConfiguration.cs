using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Persistence.EntityConfigurations;

public class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> builder)
    {
        builder.ToTable("Sales");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CustomerId);
        builder.Property(x => x.MedicineId);
        builder.Property(x=>x.PharmacistId);
        builder.Property(x => x.PurchaseId);
        builder.Property(x => x.Count).IsRequired();
        builder.Property(x => x.TotalPrice).IsRequired();
        
        builder.HasOne(x => x.Customer);
        builder.HasOne(x => x.Medicine);
        builder.HasOne(x => x.Pharmacist);
        builder.HasOne(x => x.Purchase);
    }
}