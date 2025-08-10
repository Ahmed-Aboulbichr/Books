using FluentValidation;

namespace Books.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Book ID is required.");
    }
}