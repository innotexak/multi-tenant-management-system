using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantPM.Domain.Entities;

namespace TenantPM.Infrastructure.Persistence.Configurations
{
    public class ProjectMemberConfiguration : IEntityTypeConfiguration<ProjectMember>
    {
        public void Configure(EntityTypeBuilder<ProjectMember> builder)
        {
            // Primary key
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Id)
                   .ValueGeneratedNever();

            // Required properties
            builder.Property(pm => pm.ProjectId)
                   .IsRequired();

            builder.Property(pm => pm.UserId)
                   .IsRequired();

            // Optional: Unique index to prevent duplicate membership
            builder.HasIndex(pm => new { pm.ProjectId, pm.UserId })
                   .IsUnique();
        }
    }
}
