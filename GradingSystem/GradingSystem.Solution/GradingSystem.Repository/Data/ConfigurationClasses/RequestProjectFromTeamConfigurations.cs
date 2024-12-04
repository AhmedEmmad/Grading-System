using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class RequestProjectFromTeamConfigurations : IEntityTypeConfiguration<RequestProjectFromTeam>
    {
        public void Configure(EntityTypeBuilder<RequestProjectFromTeam> builder)
        {
            // One-To-Many (Teams <-> RequestProjectsFromTeams)
            builder.HasOne(RPRO => RPRO.Team)
                   .WithMany(T => T.RequestProjectsFromTeams)
                   .HasForeignKey(RPRO => RPRO.TeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
