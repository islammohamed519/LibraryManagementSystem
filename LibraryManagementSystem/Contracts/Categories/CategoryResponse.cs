namespace LibraryManagementSystem.Contracts.Categories;

public record CategoryResponse(
    int CategoryId,
    string Name,
    string Description ,
    string CreatedOn
    );

