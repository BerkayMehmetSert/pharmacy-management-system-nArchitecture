using Core.Persistence.Repositories;

namespace Pharmacy.Domain.Entities;

public class Medicine : Entity
{
    public int CategoryId { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }

    public virtual Category? Category { get; set; }
    public virtual ICollection<Sale> Sales { get; set; }
    public virtual ICollection<Purchase> Purchases { get; set; }

    public Medicine()
    {
        Sales = new HashSet<Sale>();
        Purchases = new HashSet<Purchase>();
    }

    public Medicine(int id, int categoryId, string description, double price) : this()
    {
        Id = id;
        CategoryId = categoryId;
        Description = description;
        Price = price;
    }
}