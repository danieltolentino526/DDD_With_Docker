using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Repositories;
using Domain.Entities.Customer;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class CustomerRepository : ICustomerReadOnlyRepository, ICustomerWriteOnlyRepository, IDisposable
    {
        private readonly ApplicationContext context;

        public CustomerRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public int Add(Customer entity)
        {
            context.Customer.Add(entity);

            return context.SaveChanges();
        }

        public int Delete(Customer entity)
        {
            context.Customer.Remove(entity);

            return context.SaveChanges();
        }

        public int Update(Customer entity)
        {
            context.Entry(entity).State = EntityState.Modified;

            return context.SaveChanges();
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customer.ToList();
        }

        public Customer GetById(int id)
        {
            return context.Customer.Find(id);
        }

        public void Dispose()
        {
            context.Dispose();
        }

    }
}
