namespace LibraryManagementSystem.Validations;

public class BookRequestValidator :AbstractValidator<BookRequest>
{
    public BookRequestValidator()
    {
        RuleFor(e=>e.Price)
            .NotEmpty()
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be a non-negative value.");
        
        RuleFor(e => e.Stock)
          .NotEmpty()
          .GreaterThanOrEqualTo(0)
          .WithMessage("{PropertyName} must be a non-negative value.");
    }
}
