using FluentValidation;

namespace Books.Application.Books.Commands.PatchBook;

public class PatchBookCommandValidator : AbstractValidator<PatchBookCommand>
{
    public PatchBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Book ID is required.");
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title is required.")
            .MaximumLength(200)
            .WithMessage("Title must not exceed 200 characters.")
            .When(x => !string.IsNullOrEmpty(x.Title));

        RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage("Author is required.")
            .MaximumLength(100)
            .WithMessage("Author must not exceed 100 characters.")
            .When(x => !string.IsNullOrEmpty(x.Author));

        RuleFor(x => x.ISBN)
            .NotEmpty()
            .WithMessage("ISBN is required.")
            .MaximumLength(20)
            .WithMessage("ISBN must not exceed 20 characters.")
            .When(x => !string.IsNullOrEmpty(x.ISBN));

        RuleFor(x => x.Publisher)
            .NotEmpty()
            .WithMessage("Publisher is required.")
            .MaximumLength(100)
            .WithMessage("Publisher must not exceed 100 characters.")
            .When(x => !string.IsNullOrEmpty(x.Publisher));

        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Price must be a non-negative value.")
            .When(x => x.Price.HasValue);

        RuleFor(x => x.Language)
            .IsInEnum()
            .WithMessage("Language must be a valid enum value.")
            .When(x => x.Language.HasValue);
    }
}
