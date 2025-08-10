using Books.Application.Interfaces;
using Books.Domain.BookAggregate;
using Books.Domain.BookAggregate.Exceptions;
using MediatR;

namespace Books.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, bool>
{
    private readonly IBookRepository _bookRepository;
    public DeleteBookCommandHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task<bool> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var bookId = BookId.Of(request.Id);
        var book = await _bookRepository.GetByIdAsync(bookId, cancellationToken);
        if (book is null)
        {
            throw new BookNotFoundException(bookId);
        }
        _bookRepository.Delete(book);
        await _bookRepository.SaveChangesAsync(cancellationToken);

        return true;
    }
}