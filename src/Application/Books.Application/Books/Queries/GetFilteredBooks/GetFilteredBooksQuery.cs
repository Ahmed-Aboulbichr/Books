using Books.Application.Books.Dtos;
using Books.Domain.BookAggregate;
using MediatR;

namespace Books.Application.Books.Queries.GetFilteredBooks;

public class GetFilteredBooksQuery : IRequest<IEnumerable<GetFilteredBookResponse>>
{
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

    public string? Title { get; init; }
    public string? Author { get; init; }
    public Language? Language { get; init; }
    public bool? IsArchived { get; init; }

}
