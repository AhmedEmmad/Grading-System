namespace GradingSystem.Core.Entities
{
    // Represents the Students table in the database. (By Convention Method)
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public bool InTeam { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        

        // Foreign Key
        public int TeamId { get; set; }


        #region Navigation properties
        public ICollection<StudentTaskDoctor> StudentTaskDoctors { get; set; } = new HashSet<StudentTaskDoctor>();
        public ICollection<Chat> Chats { get; set; } = new HashSet<Chat>();
        public Team Team { get; set; }
        public Team TeamLeader { get; set; }
        public ICollection<SupervisorGrading> SupervisorGradings { get; set; } = new HashSet<SupervisorGrading>();
        public ICollection<StudentTeamInvitation> StudentInvitations { get; set; } = new HashSet<StudentTeamInvitation>();
        public ICollection<CommitteeGrading> CommitteeGradings { get; set; } = new HashSet<CommitteeGrading>();
        #endregion
    }
}
