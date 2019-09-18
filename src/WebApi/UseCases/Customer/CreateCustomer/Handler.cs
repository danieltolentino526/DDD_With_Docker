using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces.Notification;
using Application.Interfaces.UseCase;
using MediatR;

namespace WebApi.UseCases.Customer.CreateCustomer
{
    public class Handler : IRequestHandler<CreateRequest, Guid>
    {
        private readonly ICustomerCreateUseCase customerCreateUseCase;
        private readonly INotifications notifications;

        public Handler(ICustomerCreateUseCase customerCreateUseCase, INotifications notifications)
        {
            this.customerCreateUseCase = customerCreateUseCase;
            this.notifications = notifications;
        }

        public Task<Guid> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            var customer = new Domain.Entities.Customer.Customer(Guid.NewGuid(), request.Name);

            if (customer.IsValid)
                customerCreateUseCase.Execute(customer);
            else
                notifications.AddNotifications(customer.ValidationResult);

            return Task.FromResult(customer.Id);
        }
    }
}
