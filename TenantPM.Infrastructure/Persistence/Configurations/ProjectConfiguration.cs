using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantPM.Domain.Entities;

namespace TenantPM.Infrastructure.Persistence.Configurations
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(p => p.Description)
                   .HasMaxLength(1000);

            builder.Property(p => p.CreatedBy)
                   .IsRequired();

            // Indexes
            builder.HasIndex(p => p.Name);
            builder.HasIndex(p => p.CreatedBy);
        }
    }
}
