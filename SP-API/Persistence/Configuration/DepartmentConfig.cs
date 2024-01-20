using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasMaxLength(80)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(380)
                .IsRequired();
        }
    }
}
