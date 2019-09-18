using Application.Interfaces.UseCase;
using Clean.Tests.Builder;
using FluentAssertions;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Clean.Tests.UseCase.Application.Customer
{
    [UseAutofacTestFramework]
    public class CustomerUseCaseTest
    {
        private readonly ICustomerCreateUseCase customerCreateUseCase;
        private readonly ICustomerGetAllUseCase customerGetAllUseCase;

        public CustomerUseCaseTest(ICustomerCreateUseCase customerCreateUseCase, ICustomerGetAllUseCase customerGetAllUseCase)
        {
            this.customerCreateUseCase = customerCreateUseCase;
            this.customerGetAllUseCase = customerGetAllUseCase;
        }

        [Fact]
        public void ShoudlCreateCustomer()
        {
            var customer = BuilderCustomer.New().Build();

            var output = customerCreateUseCase.Execute(customer);

            output.Should().BeGreaterThan(0);
        }
    }
}
