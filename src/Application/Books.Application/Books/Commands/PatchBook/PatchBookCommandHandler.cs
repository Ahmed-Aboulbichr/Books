using Books.Application.Interfaces;
using Books.Domain.BookAggregate;
using Books.Domain.BookAggregate.Exceptions;
using MediatR;

namespace Books.Application.Books.Commands.PatchBook;

public class PatchBookCommandHandler(IBookRepository bookRepository) : IRequestHandler<PatchBookCommand, Guid>
{
    public async Task<Guid> Handle(PatchBookCommand request, CancellationToken cancellationToken)
    {
        var bookId = BookId.Of(request.Id);
        var book = await bookRepository.GetByIdAsync(bookId, cancellationToken);

        if(book is null)
            throw new BookNotFoundException(bookId);

        book.Update(request.Title,
                    request.Author,
                    request.ISBN,
                    request.Publisher,
                    request.Price,
                    request.Language,
                    request.AvailableCopies,
                    request.IsArchived);
        await bookRepository.SaveChangesAsync(cancellationToken);
        return bookId.Value;
    }
}
