namespace Books.Domain.BookAggregate.Exceptions;

public class IsbnAlreadyExistException : Exception
{
    public IsbnAlreadyExistException(string isbn)
        : base($"A {nameof(Book)} with ISBN {isbn} already exists.")
    {
    }
}
