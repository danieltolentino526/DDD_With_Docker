using Domain.Entities.Customer;
using System;

namespace Clean.Tests.Builder
{
    public class BuilderCustomer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }


        public static BuilderCustomer New()
        {
            return new BuilderCustomer()
            {
                Id = Guid.NewGuid(),
                Name = "Vivo"
            };
        }

        public BuilderCustomer WithId(Guid id)
        {
            Id = id;
            return this;
        }

        public BuilderCustomer WithName(string name)
        {
            Name = name;
            return this;
        }

        public Customer Build()
        {
            return new Customer(Id, Name);
        }
    }
}
