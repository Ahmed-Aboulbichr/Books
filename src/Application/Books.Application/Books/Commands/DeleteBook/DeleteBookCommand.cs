using MediatR;

namespace Books.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand : IRequest<bool>
{
    public required Guid Id { get; init; }
}