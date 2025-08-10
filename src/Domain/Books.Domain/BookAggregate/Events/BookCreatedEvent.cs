

using Books.Domain.Abstractions;

namespace Books.Domain.BookAggregate.Events;
public record BookCreatedEvent(Book book) : IDomainEvent;