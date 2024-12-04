using System.ComponentModel.DataAnnotations.Schema;

namespace GradingSystem.Core.Entities
{
    // Represents the RequestProjectsFromTeams table in the database. (By Convention Method)
    public class RequestProjectFromTeam : BaseEntity
    {
        public string Status { get; set; } // Request status (Pending, Accepted, Rejected)
        public DateTime RequestDate { get; set; } // Date of the request project

        [ForeignKey("Team")]
        public int TeamId { get; set; }


        #region Navigation Properties
        public Team Team { get; set; }
        public AcceptedProjectFromDr AcceptedProjectFromDr { get; set; }
        #endregion
    }
}
