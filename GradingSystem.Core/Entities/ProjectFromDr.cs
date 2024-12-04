namespace GradingSystem.Core.Entities
{
    // Represents the ProjectsFromDrs table in the database. (By Convention Method)
    public class ProjectFromDr : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        // Foreign Key
        public int DoctorId { get; set; }

        #region Navigation Properties
        public AcceptedProjectFromDr AcceptedProjectFromDr { get; set; }
        public Doctor Doctor { get; set; }
        #endregion
    }
}
