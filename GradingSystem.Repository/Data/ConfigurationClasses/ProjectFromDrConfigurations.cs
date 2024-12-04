using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class ProjectFromDrConfigurations : IEntityTypeConfiguration<ProjectFromDr>
    {
        public void Configure(EntityTypeBuilder<ProjectFromDr> builder)
        {
            // One-To-Many (Doctors <-> ProjectsFromDr)
            //builder.HasOne(PRO => PRO.Doctor)
            //       .WithMany(D => D.ProjectIdeasUploadedFromDoctor)
            //       .HasForeignKey(PRO => PRO.DoctorId)
            //       .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (Doctors <-> ProjectsFromDrs)
            builder.HasOne(PRO => PRO.Doctor)
                   .WithMany(D => D.ProjectsFromDrs)
                   .HasForeignKey(PRO => PRO.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
