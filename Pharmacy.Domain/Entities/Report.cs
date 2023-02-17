using Core.Persistence.Repositories;

namespace Pharmacy.Domain.Entities;

public class Report : Entity
{
    public int CustomerId { get; set; }
    public int PurchaseId { get; set; }
    public int SaleId { get; set; }

    public virtual Customer? Customer { get; set; }
    public virtual Purchase? Purchase { get; set; }
    public virtual Sale? Sale { get; set; }

    public Report()
    {
    }

    public Report(int id, int customerId, int purchaseId, int saleId) : this()
    {
        Id = id;
        CustomerId = customerId;
        PurchaseId = purchaseId;
        SaleId = saleId;
    }
}