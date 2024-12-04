using System.ComponentModel.DataAnnotations.Schema;

namespace GradingSystem.Core.Entities
{
    // Represents the CommitteeGradings table in the database. (By Convention Method)
    public class CommitteeGrading
    {
        [ForeignKey("GradingCriteria")]
        public int GradingCriteriaId { get; set; }
        public int DoctorId { get; set; }
        public int TeamId { get; set; }
        public int GradingScheduleId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public double Marks { get; set; }

        #region Navigation Properties
        public GradingCriteria GradingCriteria { get; set; }
        public DoctorCommittee DoctorCommittee { get; set; }
        public Student Student { get; set; }
        #endregion

    }
}
