using Core.Persistence.Repositories;

namespace Pharmacy.Domain.Entities;

public class Sale : Entity
{
    public int CustomerId { get; set; }
    public int MedicineId { get; set; }
    public int PharmacistId { get; set; }
    public int PurchaseId { get; set; }

    public int Count { get; set; }
    public double TotalPrice { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual Medicine? Medicine { get; set; }
    public virtual Pharmacist? Pharmacist { get; set; }
    public virtual Purchase? Purchase { get; set; }

    public Sale()
    {
    }

    public Sale(int id, int customerId, int medicineId, int pharmacistId, int purchaseId, int count,
        double totalPrice) : this()
    {
        Id = id;
        CustomerId = customerId;
        MedicineId = medicineId;
        PharmacistId = pharmacistId;
        PurchaseId = purchaseId;
        Count = count;
        TotalPrice = totalPrice;
    }
}