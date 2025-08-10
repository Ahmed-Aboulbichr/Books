using Books.Application.Books.Dtos;
using Books.Application.Interfaces;
using Mapster;
using MediatR;

namespace Books.Application.Books.Queries.GetFilteredBooks;

public class GetFilteredBookQueryHandler (IBookRepository bookRepository)
    : IRequestHandler<GetFilteredBooksQuery, IEnumerable<GetFilteredBookResponse>>
{
    public async Task<IEnumerable<GetFilteredBookResponse>> Handle(GetFilteredBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await bookRepository.GetFilteredAsync(request, cancellationToken);

        return books.Adapt<IEnumerable<GetFilteredBookResponse>>();
    }
}
