namespace GradingSystem.Core.Entities
{
    // Represents the DoctorCommittees table in the database. (By Convention Method)
    public class DoctorCommittee
    {
        // Foreign Keys
        public int DoctorId { get; set; }
        public int TeamId { get; set; }
        public int GradingScheduleId { get; set; }



        #region Navigation Properties
        public Doctor Doctor { get; set; }
        public Committee Committee { get; set; }
        public ICollection<CommitteeGrading> CommitteeGradings { get; set; } = new HashSet<CommitteeGrading>();
        #endregion
    }
}
