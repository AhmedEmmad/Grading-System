using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class StudentTaskDoctorConfigurations : IEntityTypeConfiguration<StudentTaskDoctor>
    {
        public void Configure(EntityTypeBuilder<StudentTaskDoctor> builder)
        {
            builder.HasKey(STD => new { STD.StudentId, STD.TaskId, STD.DoctorId}); // Composite Primary Key

            // One-To-Many (Students <-> StudentTaskAssignments)
            builder.HasOne(STD => STD.Student)
                   .WithMany(S => S.StudentTaskDoctors)
                   .HasForeignKey(STD => STD.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (Tasks <-> StudentTaskAssignments)
            builder.HasOne(STD => STD.Task)
                   .WithMany(T => T.StudentTaskDoctors)
                   .HasForeignKey(STD => STD.TaskId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (Doctors <-> StudentTaskAssignments)
            builder.HasOne(STD => STD.Doctor)
                   .WithMany(D => D.StudentTaskDoctors)
                   .HasForeignKey(STD => STD.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
