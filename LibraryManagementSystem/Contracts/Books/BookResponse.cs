namespace LibraryManagementSystem.Contracts.Books;

public record BookResponse(
    int BookId,
    string Name,
    string Description,
    decimal Price,
    string Author,
    int Stock,
    string Category,
    string CreatedOn
    );

