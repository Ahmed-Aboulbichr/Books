using Books.Application.Books.Dtos;
using Books.Application.Interfaces;
using Books.Domain.BookAggregate;
using Books.Domain.BookAggregate.Exceptions;
using MediatR;
using Mapster;

namespace Books.Application.Books.Queries.GetBookById;

public class GetBookByIdQueryHandler(IBookRepository _bookRepository) 
    : IRequestHandler<GetBookByIdQuery, GetBookResponse>
{
    public async Task<GetBookResponse?> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var bookId = BookId.Of(request.Id);
        var book = await _bookRepository.GetByIdAsync(bookId, cancellationToken);

        if(book is null) throw new BookNotFoundException(bookId);

        return book.Adapt<GetBookResponse>();
    }
}