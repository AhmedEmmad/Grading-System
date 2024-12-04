using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class TeamConfigurations : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            // One-to-One (Teams <-> Leader (Students))
            builder.HasOne(T => T.Leader)
                   .WithOne(S => S.TeamLeader)
                   .HasForeignKey<Team>(T => T.LeaderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
