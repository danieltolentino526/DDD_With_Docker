using Domain.Validator;
using System;

namespace Domain.Entities.Customer
{
    public class Customer : Entity
    {     
        public string Name { get; private set; }
     
        public Customer(Guid id, string name)
        {
            Id = id;
            Name = name;

            Validate(this, new CustomerValidator());
        }
    }
}
