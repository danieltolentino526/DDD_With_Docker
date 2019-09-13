using Domain.Entities.Customer;
using System.Collections.Generic;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerReadOnlyRepository
    {
        Customer GetById(int id);

        IEnumerable<Customer> GetAll();
    }
}
