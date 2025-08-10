using FluentValidation;

namespace Books.Application.Books.Commands.CreateBook;

public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
{
    public CreateBookCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title cannot exceed 200 characters.");
        RuleFor(x => x.Author)
            .NotEmpty().WithMessage("Author is required.")
            .MaximumLength(100).WithMessage("Author cannot exceed 100 characters.");
        RuleFor(x => x.ISBN)
            .NotEmpty().WithMessage("ISBN is required.")
            .MaximumLength(20).WithMessage("ISBN cannot exceed 20 characters.");
        RuleFor(x => x.Publisher)
            .NotEmpty().WithMessage("Publisher is required.")
            .MaximumLength(100).WithMessage("Publisher cannot exceed 100 characters.");
        RuleFor(x => x.Price)
            .GreaterThanOrEqualTo(0).WithMessage("Price must be a non-negative value.");
        RuleFor(x => x.Language)
            .IsInEnum().WithMessage("Language must be a valid enum value.");
        RuleFor(x => x.AvailableCopies)
            .GreaterThanOrEqualTo(0).WithMessage("Available copies must be a non-negative integer.");
    }
}
