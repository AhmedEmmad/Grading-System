using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class StudentConfigurations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Make Student's Email Unique
            builder.HasIndex(S => S.Email)
                   .IsUnique();

            // One-To-Many (Students <-> StudentTaskAssignments)
            //builder.HasMany(S => S.StudentTaskDoctors)
            //       .WithOne(STD => STD.Student)
            //       .HasForeignKey(STD => STD.StudentId)
            //       .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (Students <-> Chats)
            //builder.HasMany(S => S.Chats)
            //       .WithOne(C => C.Student)
            //       .HasForeignKey(C => C.StudentId)
            //       .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (Teams <-> Students)
            builder.HasOne(S => S.Team)
                   .WithMany(T => T.Students)
                   .HasForeignKey(S => S.TeamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
