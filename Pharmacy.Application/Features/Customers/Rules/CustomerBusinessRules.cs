using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Pharmacy.Application.Features.Customers.Constants;
using Pharmacy.Application.Services.Repositories;
using Pharmacy.Domain.Entities;

namespace Pharmacy.Application.Features.Customers.Rules;

public class CustomerBusinessRules: BaseBusinessRules
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerBusinessRules(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task CheckIfCustomerExistsByEmail(string email)
    {
        var customer = await _customerRepository.GetAsync(x => x.Email == email);

        if (customer != null) throw new BusinessException(CustomerMessages.CustomerAlreadyExistsByEmail);
    }

    public async Task CheckCustomerExists(int id)
    {
        var customer = await _customerRepository.GetAsync(x => x.Id == id);

        if (customer == null) throw new BusinessException(CustomerMessages.CustomerNotFound);
    }

    public void CheckIfCategoryListEmpty(IPaginate<Customer> customers)
    {
        if (customers.Items.Count == 0) throw new BusinessException(CustomerMessages.CustomerListEmpty);
    }
}