using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class ProjectFromTeamConfigurations : IEntityTypeConfiguration<ProjectFromTeam>
    {
        public void Configure(EntityTypeBuilder<ProjectFromTeam> builder)
        {
            // One-To-Many (Teams <-> ProjectsFromTeams)
            builder.HasOne(PRO => PRO.Team)
                   .WithMany(T => T.ProjectsFromTeams)
                   .HasForeignKey(PRO => PRO.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
