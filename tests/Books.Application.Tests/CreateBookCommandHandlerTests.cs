using Books.Application.Books.Commands.CreateBook;
using Books.Application.Interfaces;
using Books.Domain.BookAggregate;
using Moq;

namespace Books.Application.Tests;

public class CreateBookCommandHandlerTests
{
    private readonly Mock<IBookRepository> _bookRepositoryMock;
    private readonly CreateBookCommandHandler _handler;

    public CreateBookCommandHandlerTests()
    {
        _bookRepositoryMock = new Mock<IBookRepository>();
        _handler = new CreateBookCommandHandler(_bookRepositoryMock.Object);
    }

    [Fact]
    public async Task Handle_Should_Add_Book_And_Return_Id()
    {
        // Arrange
        var command = new CreateBookCommand
        {
            Title = "Title",
            Author = "Author",
            ISBN = "12345",
            Publisher = "Publisher",
            Price = 15.99m,
            Language = Language.English,
            AvailableCopies = 3
        };

        _bookRepositoryMock
            .Setup(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(command, default);

        // Assert
        Assert.NotEqual(Guid.Empty, result);
        _bookRepositoryMock.Verify(r => r.Add(It.IsAny<Book>(), It.IsAny<CancellationToken>()), Times.Once);
        _bookRepositoryMock.Verify(r => r.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }
}
