namespace LibraryManagementSystem.Core.Entities;

public class Book : BaseAuditableEntity
{
    public int BookId { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }
    public string Author { get; set; } = string.Empty;
    [Range(0, int.MaxValue)]
    public int Stock { get; set; }


    // navigation properties
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
