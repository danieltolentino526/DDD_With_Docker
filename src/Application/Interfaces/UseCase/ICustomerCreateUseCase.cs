using Domain.Entities.Customer;
using System;

namespace Application.Interfaces.UseCase
{
    public interface ICustomerCreateUseCase
    {
        int Execute(Customer customer);
    }
}
