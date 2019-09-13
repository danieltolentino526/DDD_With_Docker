using MediatR;
using System;

namespace WebApi.UseCases.Customer.CreateCustomer
{
    public class CreateRequest : IRequest<Guid>
    {
        public string Name { get; set; }
        
    }
}
