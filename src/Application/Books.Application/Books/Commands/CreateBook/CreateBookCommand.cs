using Books.Domain.BookAggregate;
using MediatR;

namespace Books.Application.Books.Commands.CreateBook;

public class CreateBookCommand : IRequest<Guid>
{
    public required string Title { get; init; }
    public required string Author { get; init; }
    public required string ISBN { get; init; }
    public required string Publisher { get; init; }
    public decimal Price { get; init; }
    public Language Language { get; init; }
    public int AvailableCopies { get; init; }
}
