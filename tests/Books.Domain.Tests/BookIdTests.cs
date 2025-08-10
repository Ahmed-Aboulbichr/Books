using Books.Domain.BookAggregate;
using FluentAssertions;

namespace Books.Domain.Tests;

public class BookIdTests
{
    [Fact]
    public void Create_ShouldGenerateNewGuid()
    {
        // Act
        var bookId = BookId.Create();

        // Assert
        bookId.Value.Should().NotBe(Guid.Empty);
    }

    [Fact]
    public void Of_ShouldReturnBookId_WhenValidGuidProvided()
    {
        // Arrange
        var guid = Guid.NewGuid();

        // Act
        var bookId = BookId.Of(guid);

        // Assert
        bookId.Value.Should().Be(guid);
    }

    [Fact]
    public void Of_ShouldThrow_WhenGuidIsEmpty()
    {
        // Act
        var act = () => BookId.Of(Guid.Empty);

        // Assert
        act.Should().Throw<Exception>()
           .WithMessage("*cannot be empty*");
    }

    [Fact]
    public void Equality_ShouldWorkBasedOnValue()
    {
        // Arrange
        var guid = Guid.NewGuid();
        var id1 = BookId.Of(guid);
        var id2 = BookId.Of(guid);

        // Act & Assert
        id1.Should().BeEquivalentTo(id2);
    }
}
