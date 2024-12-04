using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class StudentTeamInvitationConfigurations : IEntityTypeConfiguration<StudentTeamInvitation>
    {
        public void Configure(EntityTypeBuilder<StudentTeamInvitation> builder)
        {
            builder.HasKey(STI => new { STI.StudentId, STI.TeamId });

            builder.HasOne(STI => STI.Student)
                   .WithMany(S => S.StudentInvitations)
                   .HasForeignKey(STI => STI.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(STI => STI.Team)
                   .WithMany(T => T.TeamInvitations)
                   .HasForeignKey(STI => STI.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
