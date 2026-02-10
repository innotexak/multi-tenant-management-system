using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TenantPM.Domain.Entities;
using TenantPM.Domain.Enums;

namespace TenantPM.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Primary key
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                   .ValueGeneratedNever();

            // Required properties
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.HasIndex(u => u.Email)
                   .IsUnique(); 

            builder.Property(u => u.PasswordHash)
                   .IsRequired();


            builder.Property(u => u.Role)
                   .IsRequired()
                   .HasConversion<string>()  
                   .HasMaxLength(50);

            //indexes for faster queries by Role
            builder.HasIndex(u => u.Role);
        }
    }
}
