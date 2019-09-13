using Clean.Tests.Builder;
using FluentAssertions;
using System;
using Xunit;

namespace Clean.Tests.UseCase.Domain.Customer
{
    public class CustomerDomainTest
    {
        [Fact]
        public void ShouldCreateCustomer()
        {
            var customer = BuilderCustomer.New().Build();

            customer.IsValid.Should().BeTrue();
        }

        [Fact]
        public void IdShouldBeNotEmpty()
        {
            var customer = BuilderCustomer.New().WithId(Guid.Empty).Build();

            customer.IsValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NameShouldRequired(string name)
        {
            var customer = BuilderCustomer.New().WithName(name).Build();

            customer.IsValid.Should().BeFalse();
        }
      
    }
}
