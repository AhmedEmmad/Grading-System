using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class CommitteeGradingConfigurations : IEntityTypeConfiguration<CommitteeGrading>
    {
        public void Configure(EntityTypeBuilder<CommitteeGrading> builder)
        {
            builder.HasKey(CG => new { CG.GradingCriteriaId, CG.DoctorId, CG.StudentId, CG.TeamId });

            // One-To-Many (CommitteeGradings <-> GradingCriterias)
            builder.HasOne(CG => CG.GradingCriteria)
                   .WithMany(GC => GC.CommitteeGradings)
                   .HasForeignKey(CG => CG.GradingCriteriaId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (CommitteeGradings <-> DoctorCommittees)
            builder.HasOne(CG => CG.DoctorCommittee)
                   .WithMany(CD => CD.CommitteeGradings)
                   .HasForeignKey(CG => new { CG.DoctorId, CG.GradingScheduleId, CG.TeamId })
                   .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (CommitteeGradings <-> Students)
            builder.HasOne(CG => CG.Student)
                   .WithMany(S => S.CommitteeGradings)
                   .HasForeignKey(CG => CG.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
