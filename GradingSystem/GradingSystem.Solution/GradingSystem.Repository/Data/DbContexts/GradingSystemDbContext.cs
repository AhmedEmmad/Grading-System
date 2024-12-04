using GradingSystem.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Task = GradingSystem.Core.Entities.Task;

namespace GradingSystem.Repository.Data.DbContexts
{
    public class GradingSystemDbContext : DbContext
    {
        // This Class has Some Properties And Methods. I Will Inherit These From DbContext Class

        public GradingSystemDbContext(DbContextOptions<GradingSystemDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Instead Of Applying Each Configuration Like modelBuilder.ApplyConfiguration(new AdminConfigurations()), Use This : 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
            base.OnModelCreating(modelBuilder);
        }

        // Represent Tables In SQL Server
        public DbSet<Admin> Admins { get; set; }
        public DbSet<DrInstruction> DrInstructions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<StudentTaskDoctor> StudentTaskAssignments { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<SupervisorGrading> SupervisorGradings { get; set; }
        public DbSet<GradingCriteria> GradingCriterias { get; set; }
        public DbSet<StudentTeamInvitation> StudentTeamInvitations { get; set; }
        public DbSet<Committee> Committees { get; set; }
        public DbSet<GradingSchedule> GradingSchedules { get; set; }
        public DbSet<DoctorCommittee> DoctorCommittees { get; set; }
        public DbSet<CommitteeGrading> CommitteeGradings { get; set; }
        public DbSet<AcceptedProjectFromTeam> AcceptedProjectsFromTeams { get; set; }
        public DbSet<ProjectFromTeam> ProjectsFromTeams { get; set; }
        public DbSet<AcceptedProjectFromDr> AcceptedProjectsFromDrs { get; set; }
        public DbSet<RequestProjectFromTeam> RequestProjectsFromTeams { get; set; }
        public DbSet<ProjectFromDr> ProjectsFromDrs { get; set; }
    }
}
