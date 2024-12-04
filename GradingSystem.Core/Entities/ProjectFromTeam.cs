namespace GradingSystem.Core.Entities
{
    // Represents the ProjectsFromTeams table in the database. (By Convention Method)
    public class ProjectFromTeam : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        // Foreign Key
        public int TeamId { get; set; }

        #region Navigation Properties
        public AcceptedProjectFromTeam AcceptedProjectFromTeam { get; set; }
        public Team Team { get; set; }
        #endregion
    }
}
