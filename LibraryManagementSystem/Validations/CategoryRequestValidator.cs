namespace LibraryManagementSystem.Validations;

public class CategoryRequestValidator:AbstractValidator<CategoryRequest>
{
    public CategoryRequestValidator()
    {
        RuleFor(e=>e.Name).NotEmpty();
        RuleFor(e=>e.Description).NotEmpty();
    }
}
