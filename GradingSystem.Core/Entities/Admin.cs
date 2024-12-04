namespace GradingSystem.Core.Entities
{
    // Represents the Admins table in the database. (By Convention Method)
    public class Admin : BaseEntity
    {  
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }


        #region Navigational Property
        public ICollection<DrInstruction> DrInstructions { get; set; } = new HashSet<DrInstruction>(); // Relationship Between Admins and DrInstructions [Many]
        #endregion
    }
}
