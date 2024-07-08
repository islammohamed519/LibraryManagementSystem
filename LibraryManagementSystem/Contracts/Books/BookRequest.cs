namespace LibraryManagementSystem.Contracts.Books;

public record BookRequest(
    string Name,
    string Description,
    decimal Price,
    string Author,
    int Stock,
    int CategoryId
    );

