namespace GradingSystem.Core.Entities
{
    // By Convention Method
    public class GradingSchedule : BaseEntity
    {
        public DateTime Date { get; set; }

        #region Navigation Properties
        public ICollection<Committee> Committees { get; set; } = new HashSet<Committee>();
        #endregion
    }
}
