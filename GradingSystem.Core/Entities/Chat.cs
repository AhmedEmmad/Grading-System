namespace GradingSystem.Core.Entities
{
    // Represents the Chats table in the database. (By Convention Method)
    public class Chat : BaseEntity
    {
        public string Message { get; set; }
        public DateTime Time { get; set; }
        

        // Foreign Keys
        public int StudentId { get; set; }
        public int DoctorId { get; set; }


        #region Navigation Properties
        public Student Student { get; set; }
        public Doctor Doctor { get; set; }
        #endregion
    }
}
