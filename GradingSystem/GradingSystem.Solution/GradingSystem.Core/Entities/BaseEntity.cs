namespace GradingSystem.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; } //(By Convention) -> PK(Auto Incremental -> Identity(1,1)) In SQL Server For Each Entity Inherits From BaseEntity
    }
}
