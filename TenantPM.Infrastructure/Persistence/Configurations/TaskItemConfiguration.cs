using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantPM.Domain.Entities;

namespace TenantPM.Infrastructure.Persistence.Configurations
{
    public class TaskItemConfiguration : IEntityTypeConfiguration<TaskItem>
    {
        public void Configure(EntityTypeBuilder<TaskItem> builder)
        {
            // Primary key
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedNever();

            // Required properties
            builder.Property(t => t.Title)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.Description)
                   .HasMaxLength(1000);

            builder.Property(t => t.ProjectId)
                   .IsRequired();

            builder.Property(t => t.AssignedTo)
                   .IsRequired();

            builder.Property(t => t.Status)
                   .IsRequired()
                   .HasConversion<string>() 
                   .HasMaxLength(50);

            // Optional: indexes
            builder.HasIndex(t => t.ProjectId);
            builder.HasIndex(t => t.AssignedTo);
        }
    }
}
