using Application.Interfaces.Repositories;
using Clean.Tests.Builder.CallBack;
using Clean.Tests.TestCaseOrdering;
using FluentAssertions;
using System;
using Xunit;
using Xunit.Frameworks.Autofac;

namespace Clean.Tests.UseCase.Repository.CallBack
{
    [UseAutofacTestFramework]
    [TestCaseOrderer("Clean.Tests.TestCaseOrdering.PriorityOrderer", "Clean.Tests")]
    public class CallBackRepositoryTest
    {
        private readonly ICallBackReadOnlyRepository callBackReadOnlyRepository;
        private readonly ICallBackWriteOnlyRepository callBackWriteOnlyRepository;
        private static readonly Guid IdCallBack = Guid.NewGuid();

        public CallBackRepositoryTest(ICallBackReadOnlyRepository callBackReadOnlyRepository, ICallBackWriteOnlyRepository callBackWriteOnlyRepository)
        {
            this.callBackReadOnlyRepository = callBackReadOnlyRepository;
            this.callBackWriteOnlyRepository = callBackWriteOnlyRepository;
        }

        [Fact]
        [TestPriority(0)]
        public void ShouldCreateCallBack()
        {
            var callback = BuilderCallBack.New().WithId(IdCallBack).Build();

            var output = callBackWriteOnlyRepository.Add(callback);

            output.Should().BeGreaterThan(0);
        }

        [Fact]
        [TestPriority(1)]
        public void ShouldGetAllCallBack()
        {
            var output = callBackReadOnlyRepository.GetAll();

            output.Should().HaveCountGreaterThan(0);
        }

        [Fact]
        [TestPriority(2)]
        public void ShouldGetCallBackById()
        {
            var output = callBackReadOnlyRepository.Find(IdCallBack);

            output.Should().NotBeNull();
            output.Id.Should().Be(IdCallBack);
        }
               
        [Theory]
        [InlineData("Falha na CPU")]
        [TestPriority(3)]
        public void ShouldUpdateCallBack(string message)
        {
            var callback = BuilderCallBack.New().WithId(IdCallBack).WithDescription(message).Build();

            var output = callBackWriteOnlyRepository.Update(callback);

            output.Should().BeGreaterThan(0);
        }  
               
        [Fact]
        [TestPriority(4)]
        public void ShouldRemoveCallBack()
        {
            var callback = BuilderCallBack.New().WithId(IdCallBack).Build();

            var output = callBackWriteOnlyRepository.Remove(callback);

            output.Should().BeGreaterThan(0);
        }
    }
}
