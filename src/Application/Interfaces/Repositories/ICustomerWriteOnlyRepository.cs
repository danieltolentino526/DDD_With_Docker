using Domain.Entities.Customer;

namespace Application.Interfaces.Repositories
{
    public interface ICustomerWriteOnlyRepository
    {
        int Add(Customer entity);

        int Update(Customer entity);

        int Delete(Customer entity);
    }
}
