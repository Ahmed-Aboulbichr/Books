using Books.Domain.BookAggregate.Events;
using Books.Domain.BookAggregate;
using FluentAssertions;

namespace Books.Domain.Tests;

public class BookTests
{
    [Fact]
    public void Create_ShouldSetAllProperties()
    {
        // Arrange
        var id = BookId.Create();
        var title = "Test Book";
        var author = "John Doe";
        var isbn = "1234567890";
        var publisher = "Test Publisher";
        var price = 9.99m;
        var language = Language.English;
        var availableCopies = 5;

        // Act
        var book = Book.Create(id, title, author, isbn, publisher, price, language, availableCopies);

        // Assert
        book.Id.Should().Be(id);
        book.Title.Should().Be(title);
        book.Author.Should().Be(author);
        book.ISBN.Should().Be(isbn);
        book.Publisher.Should().Be(publisher);
        book.Price.Should().Be(price);
        book.Language.Should().Be(language);
        book.AvailableCopies.Should().Be(availableCopies);
        book.IsArchived.Should().BeFalse();

    }

    [Fact]
    public void Update_ShouldChangeOnlyProvidedFields_AndRaiseEvent()
    {
        // Arrange
        var book = Book.Create(
            BookId.Create(),
            "Old Title",
            "Old Author",
            "1234567890",
            "Old Publisher",
            9.99m,
            Language.English,
            5);

        // Act
        book.Update(
            title: "New Title",
            author: null, // should remain old
            isbn: null,   // should remain old
            publisher: "New Publisher",
            price: 12.5m,
            language: null,
            availableCopies: 10,
            isArchived: true);

        // Assert
        book.Title.Should().Be("New Title");
        book.Author.Should().Be("Old Author");
        book.ISBN.Should().Be("1234567890");
        book.Publisher.Should().Be("New Publisher");
        book.Price.Should().Be(12.5m);
        book.Language.Should().Be(Language.English);
        book.AvailableCopies.Should().Be(10);
        book.IsArchived.Should().BeTrue();

        var domainEvent = book.DomainEvents.Last()
            .Should().BeOfType<BookPatchedEvent>().Which;
        domainEvent.Book.Should().Be(book);
    }
}
