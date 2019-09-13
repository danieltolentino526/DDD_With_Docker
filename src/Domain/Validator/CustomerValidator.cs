using Domain.Entities.Customer;
using FluentValidation;
using System;

namespace Domain.Validator
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .NotNull()
                .NotEqual(new Guid());                

            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull();
        }
    }
}
