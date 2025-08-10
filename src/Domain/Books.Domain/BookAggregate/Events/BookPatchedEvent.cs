
using Books.Domain.Abstractions;

namespace Books.Domain.BookAggregate.Events;

public record BookPatchedEvent(Book Book) : IDomainEvent;