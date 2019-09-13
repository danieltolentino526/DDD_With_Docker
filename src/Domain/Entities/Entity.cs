﻿using FluentValidation;
using FluentValidation.Results;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        [NotMapped]
        public bool IsValid { get; private set; }

        [NotMapped]
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);

            return IsValid = ValidationResult.IsValid;
        }
    }
}
