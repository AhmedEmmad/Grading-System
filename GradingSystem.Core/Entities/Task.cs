namespace GradingSystem.Core.Entities
{
    // Represents the Tasks table in the database. (By Convention Method)
    public class Task : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }


        #region Navigation Properties
        public ICollection<StudentTaskDoctor> StudentTaskDoctors { get; set; } = new HashSet<StudentTaskDoctor>();
        #endregion
    }
}
