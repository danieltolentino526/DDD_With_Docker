using Domain.Entities.Customer;
using System.Collections.Generic;

namespace Application.Interfaces.UseCase
{
    public interface ICustomerGetAllUseCase
    {
        IEnumerable<Customer> Execute(int userId);
    }
}
