namespace GradingSystem.Core.Entities
{
    // Represents the Committees table in the database. (By Convention Method)
    public class Committee
    {
        // Foreign Keys
        public int GradingScheduleId { get; set; }
        public int TeamId { get; set; }



        #region Navigation Properties
        public GradingSchedule GradingSchedule { get; set; }
        public Team Team { get; set; }
        public ICollection<DoctorCommittee> DoctorCommittees { get; set; } = new HashSet<DoctorCommittee>();
        #endregion
    }
}
