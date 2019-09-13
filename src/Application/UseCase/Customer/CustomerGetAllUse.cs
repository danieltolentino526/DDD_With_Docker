using Application.Interfaces.Repositories;
using Application.Interfaces.UseCase;
using System.Collections.Generic;

namespace Application.UseCase.Customer
{
    public class CustomerGetAllUse : ICustomerGetAllUseCase
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;

        public CustomerGetAllUse(ICustomerReadOnlyRepository customerReadOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
        }

        public IEnumerable<Domain.Entities.Customer.Customer> Execute(int userId)
        {
            return customerReadOnlyRepository.GetAll();
        }
    }
}
