namespace LibraryManagementSystem.Core.Entities;

public class Category : BaseAuditableEntity
{
    public int CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;


    // navigation properties
    public ICollection<Book> Books { get; set; } = [];
}
