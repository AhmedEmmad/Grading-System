using System.ComponentModel.DataAnnotations.Schema;

namespace GradingSystem.Core.Entities
{
    // Represents the Teams table in the database. (By Convention Method)
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public bool HasProject { get; set; }


        // Foreign Key
        [ForeignKey("Leader")]
        public int LeaderId { get; set; }


        #region Navigation Properties
        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
        public Student Leader { get; set; }
        public ICollection<StudentTeamInvitation> TeamInvitations { get; set; } = new HashSet<StudentTeamInvitation>();
        public ICollection<Committee> Committees { get; set; } = new HashSet<Committee>();
        public ICollection<ProjectFromTeam> ProjectsFromTeams { get; set; } = new HashSet<ProjectFromTeam>();
        public ICollection<RequestProjectFromTeam> RequestProjectsFromTeams { get; set; } = new HashSet<RequestProjectFromTeam>();
        #endregion
    }
}
