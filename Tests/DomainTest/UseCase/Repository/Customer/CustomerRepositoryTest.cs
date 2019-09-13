using Application.Interfaces.Repositories;
using Clean.Tests.Builder;
using FluentAssertions;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Clean.Tests.UseCase.Repository.Customer
{
    [UseAutofacTestFramework]   
    public class CustomerRepositoryTest
    {
        private readonly ICustomerReadOnlyRepository customerReadOnlyRepository;
        private readonly ICustomerWriteOnlyRepository customerWriteOnlyRepository;
               
        public CustomerRepositoryTest(ICustomerReadOnlyRepository customerReadOnlyRepository, ICustomerWriteOnlyRepository customerWriteOnlyRepository)
        {
            this.customerReadOnlyRepository = customerReadOnlyRepository;
            this.customerWriteOnlyRepository = customerWriteOnlyRepository;
        }

        [Fact]
        public void ShouldCreateCustomer()
        {
            var output = BuilderCustomer.New().Build();

            var ret = customerWriteOnlyRepository.Add(output);

            ret.Should().BeGreaterThan(0);
        }
    }
}
