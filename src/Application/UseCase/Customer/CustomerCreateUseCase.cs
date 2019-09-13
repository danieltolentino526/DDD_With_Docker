using System;
using Application.Interfaces.Repositories;
using Application.Interfaces.UseCase;

namespace Application.UseCase.Customer
{
    public class CustomerCreateUseCase : ICustomerCreateUseCase
    {
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;

        public CustomerCreateUseCase(ICustomerWriteOnlyRepository  customerWriteOnlyRepository)
        {
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        public int Execute(Domain.Entities.Customer.Customer customer)
        {
            return customerWriteOnlyRepository.Add(customer);
        }
    }
}
