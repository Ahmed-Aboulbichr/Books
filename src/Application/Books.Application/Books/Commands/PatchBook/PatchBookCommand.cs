using Books.Domain.BookAggregate;
using MediatR;

namespace Books.Application.Books.Commands.PatchBook;

public record PatchBookCommand : IRequest<Guid>
{
    public required Guid Id { get; init; }
    public string? Title { get; init; }
    public string? Author { get; init; }
    public string? ISBN { get; init; }
    public string? Publisher { get; init; }
    public decimal? Price { get; init; }
    public Language? Language { get; init; }
    public int? AvailableCopies { get; init; }
    public bool? IsArchived { get; init; }
}