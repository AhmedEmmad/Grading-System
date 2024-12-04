using System.ComponentModel.DataAnnotations.Schema;

namespace GradingSystem.Core.Entities
{
    // Represents the AcceptedProjectsFromDrs table in the database. (By Convention Method)
    public class AcceptedProjectFromDr
    {
        [ForeignKey("ProjectFromDr")]
        public int ProjectFromDrId { get; set; }
        [ForeignKey("RequestProjectFromTeam")]
        public int RequestProjectFromTeamId { get; set; }
        

        #region Navigation Properties
        public ProjectFromDr ProjectFromDr { get; set; }
        public RequestProjectFromTeam RequestProjectFromTeam { get; set; }
        #endregion
    }
}
