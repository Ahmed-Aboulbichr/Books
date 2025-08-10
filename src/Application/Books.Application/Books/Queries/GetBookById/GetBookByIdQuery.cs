using Books.Application.Books.Dtos;
using MediatR;

namespace Books.Application.Books.Queries.GetBookById;

public class GetBookByIdQuery : IRequest<GetBookResponse>
{
    public required Guid Id { get; init; }
}
