namespace LibraryManagementSystem.Core.Entities.Common;

public abstract class BaseAuditableEntity
{
    public bool IsDeleted { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;
    public DateTime? LastUpdatedOn { get; set; }
}
