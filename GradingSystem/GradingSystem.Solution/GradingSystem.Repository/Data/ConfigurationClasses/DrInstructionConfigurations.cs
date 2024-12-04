using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class DrInstructionConfigurations : IEntityTypeConfiguration<DrInstruction>
    {
        public void Configure(EntityTypeBuilder<DrInstruction> builder)
        {
            // One-To-Many (Admins <-> DrInstructions)
            //builder.HasOne(Di => Di.Admin)
            //       .WithMany(A => A.DrInstructions)
            //       .HasForeignKey(Di => Di.AdminId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
