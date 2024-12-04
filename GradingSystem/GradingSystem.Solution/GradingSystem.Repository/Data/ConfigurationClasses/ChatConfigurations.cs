using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class ChatConfigurations : IEntityTypeConfiguration<Chat>
    {
        public void Configure(EntityTypeBuilder<Chat> builder)
        {
            // Composite Unique Index To preserve the logical integrity of the relationship
            builder.HasIndex(C => new { C.DoctorId, C.StudentId, C.Time })
                   .IsUnique();


            // One-To-Many (Students <-> Chats)
            builder.HasOne(C => C.Student)
                   .WithMany(S => S.Chats)
                   .HasForeignKey(C => C.StudentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // One-To-Many (Doctors <-> Chats)
            builder.HasOne(C => C.Doctor)
                   .WithMany(D => D.Chats)
                   .HasForeignKey(C => C.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
