using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class CommitteeConfigurations : IEntityTypeConfiguration<Committee>
    {
        public void Configure(EntityTypeBuilder<Committee> builder)
        {
            builder.HasKey(C => new {C.GradingScheduleId, C.TeamId});

            // One-To-Many (Committees <-> GradingSchedules)
            builder.HasOne(C => C.GradingSchedule)
                   .WithMany(GS => GS.Committees)
                   .HasForeignKey(C => C.GradingScheduleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (Committees <-> Teams)
            builder.HasOne(C => C.Team)
                   .WithMany(T => T.Committees)
                   .HasForeignKey(C => C.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
