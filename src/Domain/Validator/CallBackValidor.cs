using Domain.Entities.CallBack;
using FluentValidation;
using System;

namespace Domain.Validator
{
    class CallBackValidator : AbstractValidator<CallBack>
    {
        public CallBackValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty()
               .NotEqual(new Guid());

            RuleFor(x => x.Description)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Status).IsInEnum();

        }
    }
}
