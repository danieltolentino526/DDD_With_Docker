using Domain.Entities.CallBack;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.EntityConfig
{
    public class CallBackMap : IEntityTypeConfiguration<CallBack>
    {
        public void Configure(EntityTypeBuilder<CallBack> builder)
        {
            builder.ToTable("CallBack", "Resource")
                .Ignore(x=> x.ValidationResult)
                .HasKey();

            builder.Property(x => x.Description).IsRequired();

            builder.Property(x => x.Status).IsRequired();
           
        }
    }
}
