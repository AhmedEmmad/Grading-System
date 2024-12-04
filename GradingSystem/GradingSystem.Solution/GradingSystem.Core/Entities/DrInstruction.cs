namespace GradingSystem.Core.Entities
{
    // Represents the DrInstructions table in the database. (By Convention Method)
    public class DrInstruction : BaseEntity
    {
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }


        // Foreign key Column => Admin
        public int AdminId { get; set; } 


        #region Navigation Property
        public Admin Admin { get; set; } // Relationship Between Admins and DrInstructions [One]
        #endregion
    }
}
