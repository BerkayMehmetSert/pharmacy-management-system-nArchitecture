using Core.Persistence.Repositories;

namespace Pharmacy.Domain.Entities;

public class Category : Entity
{
    public string? Name { get; set; }

    public virtual ICollection<Medicine> Medicines { get; set; }

    public Category()
    {
        Medicines = new HashSet<Medicine>();
    }

    public Category(int id, string? name) : this()
    {
        Id = id;
        Name = name;
    }
}