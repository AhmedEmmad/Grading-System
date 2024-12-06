using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class AdminConfigurations : IEntityTypeConfiguration<Admin>
    {
        public void Configure(EntityTypeBuilder<Admin> builder)
        {
            // Make Admin's Email Unique
            builder.HasIndex(A => A.Email).IsUnique();

            // One - To - Many(Admins <->DrInstructions)
            builder.HasMany(A => A.DrInstructions)
                    .WithOne(Di => Di.Admin)
                    .HasForeignKey(Di => Di.AdminId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
