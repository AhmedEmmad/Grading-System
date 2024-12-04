using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = GradingSystem.Core.Entities.Task;

namespace GradingSystem.Repository.Data.ConfigurationClasses
{
    public class TaskConfigurations : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            // One-To-Many (Tasks <-> StudentTaskAssignments)
            //builder.HasMany(T => T.StudentTaskDoctors)
            //       .WithOne(STD => STD.Task)
            //       .HasForeignKey(STD => STD.TaskId)
            //       .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
