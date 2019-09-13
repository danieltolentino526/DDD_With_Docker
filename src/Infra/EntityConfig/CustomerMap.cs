using Domain.Entities.Customer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfig
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer", "Resource")
                .Ignore(x=> x.ValidationResult)
                .HasKey(x=> x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("NameCustomer")
                .HasColumnType("varchar")
                .IsRequired();         
                
        }
    }
}
