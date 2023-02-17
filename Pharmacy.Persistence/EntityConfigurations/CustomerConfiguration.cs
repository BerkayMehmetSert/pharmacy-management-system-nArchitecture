using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{

    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Gender);
        builder.Property(x => x.Age);
        builder.Property(x => x.ContactAddress).IsRequired().HasMaxLength(100);
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Password).IsRequired();
        builder.Property(x => x.CreatedDate);
        builder.Property(x => x.UpdatedDate);

        builder.HasMany(x => x.Sales);
        builder.HasMany(x => x.Purchases);
        builder.HasMany(x => x.Reports);
    }
}