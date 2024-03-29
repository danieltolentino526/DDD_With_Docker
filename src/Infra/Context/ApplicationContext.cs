﻿using Domain.Entities.CallBack;
using Domain.Entities.Customer;
using Infra.EntityConfig;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<CallBack> CallBack { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(Environment.GetEnvironmentVariable("DB_TYPE")))
                optionsBuilder.UseInMemoryDatabase("DB_Resource");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CallBackMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}
