using Books.Application.Books.Commands.CreateBook;
using Books.Domain.BookAggregate;
using FluentValidation.TestHelper;

namespace Books.Application.Tests;

public class CreateBookCommandValidatorTests
{
    private readonly CreateBookCommandValidator _validator = new();

    [Fact]
    public void Should_Have_Error_When_Title_Is_Empty()
    {
        var command = new CreateBookCommand
        {
            Title = "",
            Author = "Author",
            ISBN = "12345",
            Publisher = "Publisher",
            Price = 10,
            Language = Language.English,
            AvailableCopies = 5
        };

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Title);
    }

    [Fact]
    public void Should_Have_Error_When_Price_Is_Negative()
    {
        var command = new CreateBookCommand
        {
            Title = "Title",
            Author = "Author",
            ISBN = "12345",
            Publisher = "Publisher",
            Price = -1,
            Language = Language.English,
            AvailableCopies = 5
        };

        var result = _validator.TestValidate(command);
        result.ShouldHaveValidationErrorFor(x => x.Price);
    }

    [Fact]
    public void Should_Not_Have_Error_When_Valid()
    {
        var command = new CreateBookCommand
        {
            Title = "Valid Title",
            Author = "Valid Author",
            ISBN = "12345",
            Publisher = "Valid Publisher",
            Price = 15.5m,
            Language = Language.English,
            AvailableCopies = 10
        };

        var result = _validator.TestValidate(command);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
