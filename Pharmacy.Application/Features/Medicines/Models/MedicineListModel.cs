using Core.Persistence.Paging;
using Pharmacy.Application.Features.Medicines.Dto;

namespace Pharmacy.Application.Features.Medicines.Models;

public class MedicineListModel : BasePageableModel
{
    public IList<MedicineListDto> Items { get; set; }
}