using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class AcceptedProjectFromTeamConfigurations : IEntityTypeConfiguration<AcceptedProjectFromTeam>
    {
        public void Configure(EntityTypeBuilder<AcceptedProjectFromTeam> builder)
        {
            builder.HasKey(APRO => new { APRO.ProjectFromTeamId, APRO.DoctorId });

            // One-To-Many (Doctors <-> AcceptedProjectsFromTeams)
            builder.HasOne(APRO => APRO.Doctor)
                   .WithMany(D => D.AcceptedProjectsFromTeams)
                   .HasForeignKey(APRO => APRO.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-To-One (ProjectsFromTeams <-> AcceptedProjectsFromTeams)
            builder.HasOne(APRO => APRO.ProjectFromTeam)
                   .WithOne(PRO => PRO.AcceptedProjectFromTeam)
                   .HasForeignKey<AcceptedProjectFromTeam>(APRO => APRO.ProjectFromTeamId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
