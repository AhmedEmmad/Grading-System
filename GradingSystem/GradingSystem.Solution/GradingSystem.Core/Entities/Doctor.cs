namespace GradingSystem.Core.Entities
{
    // Represents the Doctors table in the database. (By Convention Method)
    public class Doctor : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Specialization { get; set; }
        public string PhoneNumber { get; set; }


        #region Navigation Properties
        public ICollection<StudentTaskDoctor> StudentTaskDoctors { get; set; } = new HashSet<StudentTaskDoctor>();
        public ICollection<Chat> Chats { get; set; } = new HashSet<Chat>();
        public ICollection<SupervisorGrading> SupervisorGradings { get; set; } = new HashSet<SupervisorGrading>();
        public ICollection<DoctorCommittee> DoctorCommittees { get; set; } = new HashSet<DoctorCommittee>();
        public ICollection<AcceptedProjectFromTeam> AcceptedProjectsFromTeams { get; set; } = new HashSet<AcceptedProjectFromTeam>();
        public ICollection<ProjectFromDr> ProjectsFromDrs { get; set; } = new HashSet<ProjectFromDr>();
        #endregion
    }
}
