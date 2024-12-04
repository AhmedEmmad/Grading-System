using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class DoctorCommitteeConfigurations : IEntityTypeConfiguration<DoctorCommittee>
    {
        public void Configure(EntityTypeBuilder<DoctorCommittee> builder)
        {
            builder.HasKey(CD => new { CD.DoctorId, CD.GradingScheduleId, CD.TeamId });
            //builder.HasNoKey();

            // One - To - Many(Doctors <-> DoctorCommittees)
            builder.HasOne(CD => CD.Doctor)
                   .WithMany(D => D.DoctorCommittees)
                   .HasForeignKey(CD => CD.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One - To - Many(Committees <-> DoctorCommittees)
            builder.HasOne(CD => CD.Committee)
                   .WithMany(C => C.DoctorCommittees)
                   .HasForeignKey(CD => new { CD.TeamId, CD.GradingScheduleId })
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
