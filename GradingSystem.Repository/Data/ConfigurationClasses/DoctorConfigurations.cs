using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class DoctorConfigurations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            // Make Doctor's Email Unique
            builder.HasIndex(D => D.Email)
                   .IsUnique();

            // One-To-Many (Doctors <-> StudentTaskAssignments)
            //builder.HasMany(D => D.StudentTaskDoctors)
            //       .WithOne(STD => STD.Doctor)
            //       .HasForeignKey(STD => STD.DoctorId)
            //       .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (Doctors <-> Chats)
            //builder.HasMany(D => D.Chats)
            //       .WithOne(C => C.Doctor)
            //       .HasForeignKey(C => C.DoctorId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
