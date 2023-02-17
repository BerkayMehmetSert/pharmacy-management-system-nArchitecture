using Core.Persistence.Repositories;

namespace Pharmacy.Domain.Entities;

public class Purchase : Entity
{
    public int MedicineId { get; set; }
    public int CustomerId { get; set; }

    public double Amount { get; set; }

    public virtual Medicine? Medicine { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual ICollection<Sale> Sales { get; set; }

    public Purchase()
    {
        Sales = new HashSet<Sale>();
    }

    public Purchase(int id, int medicineId, int customerId, double amount) : this()
    {
        Id = id;
        MedicineId = medicineId;
        CustomerId = customerId;
        Amount = amount;
    }
}