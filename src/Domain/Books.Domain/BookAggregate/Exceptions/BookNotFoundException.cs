namespace Books.Domain.BookAggregate.Exceptions;

public class BookNotFoundException(BookId bookId) : Exception($"{nameof(Book)} with ID {bookId} not found.")
{
}
