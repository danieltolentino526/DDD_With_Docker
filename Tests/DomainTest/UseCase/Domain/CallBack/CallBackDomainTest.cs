using Clean.Tests.Builder.CallBack;
using FluentAssertions;
using System;
using Xunit;

namespace Clean.Tests.UseCase.Domain.CallBack
{
    public class CallBackDomainTest
    {       
        [Fact]
        public void ShoudCreateCallBack()
        {
            var callback = BuilderCallBack.New().Build();

            callback.IsValid.Should().BeTrue();
        }

        [Fact]
        public void GuidShouldBeRequired()
        {
            var callback = BuilderCallBack.New().WithId(new Guid()).Build();

            callback.IsValid.Should().BeFalse();
            callback.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void DescriptionShouldNotEmptyOrNull(string description)
        {
            var callback = BuilderCallBack.New().WithDescription(description).Build();

            callback.IsValid.Should().BeFalse();
            callback.ValidationResult.Errors.Should().HaveCountGreaterThan(0);
        }
        
    }
}
