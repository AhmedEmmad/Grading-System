using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class AcceptedProjectFromDrConfigurations : IEntityTypeConfiguration<AcceptedProjectFromDr>
    {
        public void Configure(EntityTypeBuilder<AcceptedProjectFromDr> builder)
        {
            builder.HasKey(APRO => new { APRO.ProjectFromDrId, APRO.RequestProjectFromTeamId });

            // One-To-One (RequestProjectsFromTeams <-> AcceptedProjectsFromDrs)
            builder.HasOne(APRO => APRO.RequestProjectFromTeam)
                   .WithOne(RPRO => RPRO.AcceptedProjectFromDr)
                   .HasForeignKey<AcceptedProjectFromDr>(APRO => APRO.RequestProjectFromTeamId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-To-One (ProjectsFromDrs <-> AcceptedProjectsFromDrs)
            builder.HasOne(APRO => APRO.ProjectFromDr)
                   .WithOne(RPRO => RPRO.AcceptedProjectFromDr)
                   .HasForeignKey<AcceptedProjectFromDr>(APRO => APRO.ProjectFromDrId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
