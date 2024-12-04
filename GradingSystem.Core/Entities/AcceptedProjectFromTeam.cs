namespace GradingSystem.Core.Entities
{
    // Represents the AcceptedProjectsFromTeams table in the database. (By Convention Method)
    public class AcceptedProjectFromTeam
    {
        // Foreign Keys
        public int ProjectFromTeamId { get; set; }
        public int DoctorId { get; set; }


        #region Navigation Properties
        public Doctor Doctor { get; set; }
        public ProjectFromTeam ProjectFromTeam { get; set; }
        #endregion
    }
}
