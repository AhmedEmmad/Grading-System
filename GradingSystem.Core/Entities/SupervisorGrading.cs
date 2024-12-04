namespace GradingSystem.Core.Entities
{
    // Represents the SupervisorGradings table in the database. (By Convention Method)
    public class SupervisorGrading
    {
        public double Marks { get; set; }
        

        // Foreign Keys
        public int StudentId { get; set; }
        public int GradingCriteriaId { get; set; }
        public int DoctorId { get; set; }



        #region Navigation Properties
        public Student Student { get; set; }
        public GradingCriteria GradingCriteria { get; set; }
        public Doctor Doctor { get; set; }
        #endregion
    }
}
