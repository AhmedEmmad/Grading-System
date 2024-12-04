namespace GradingSystem.Core.Entities
{
    // Represents the StudentTaskAssignments table in the database. (By Convention Method)
    public class StudentTaskDoctor
    {
        public double Mark { get; set; }
        public string Status { get; set; } // Pending, InProgress, Completed
        public DateTime CreatedDate { get; set; }
        

        // Composite Primary Key Of Foreign Keys
        public int StudentId { get; set; }
        public int TaskId { get; set; }
        public int DoctorId { get; set; }


        #region Navigation Properties
        public Student Student { get; set; }
        public Task Task { get; set; }
        public Doctor Doctor { get; set; }
        #endregion
    }
}