using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Persistence.EntityConfigurations;

public class ReportConfiguration : IEntityTypeConfiguration<Report>
{
    public void Configure(EntityTypeBuilder<Report> builder)
    {       
        builder.ToTable("Reports");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CustomerId);
        builder.Property(x => x.PurchaseId);
        builder.Property(x => x.SaleId);
        builder.Property(x => x.CreatedDate);
        builder.Property(x => x.UpdatedDate);

        builder.HasOne(x => x.Customer);
        builder.HasOne(x => x.Purchase);
        builder.HasOne(x => x.Sale);
    }
}