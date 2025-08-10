using Books.Application.Interfaces;
using Books.Domain.BookAggregate;
using MediatR;

namespace Books.Application.Books.Commands.CreateBook;

public class CreateBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<CreateBookCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var bookId = BookId.Create();
        var book = Book.Create(bookId,
            request.Title,
            request.Author,
            request.ISBN,
            request.Publisher,
            request.Price,
            request.Language,
            request.AvailableCopies);

        bookRepository.Add(book,cancellationToken);
        await bookRepository.SaveChangesAsync(cancellationToken);

        return bookId.Value;
    }
}
