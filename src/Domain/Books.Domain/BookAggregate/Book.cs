using Books.Domain.Abstractions;
using Books.Domain.BookAggregate.Events;

namespace Books.Domain.BookAggregate;

public class Book : Aggregate<BookId>
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public string Publisher { get; private set; }
    public decimal Price { get; private set; }
    public Language Language { get; private set; }
    public int AvailableCopies { get; private set; }
    public bool IsArchived { get; private set; } = false;

    private Book() { }

    public static Book Create(
        BookId id,
        string title,
        string author,
        string isbn,
        string publisher,
        decimal price,
        Language language,
        int availableCopies)
    {
        var book = new Book
        {
            Id = id,
            Title = title,
            Author = author,
            ISBN = isbn,
            Publisher = publisher,
            Price = price,
            Language = language,
            AvailableCopies = availableCopies,
        };

        book.AddDomainEvent(new BookCreatedEvent(book));

        return book;
    }

    public void Update(
        string? title,
        string? author,
        string? isbn,
        string? publisher,
        decimal? price,
        Language? language,
        int? availableCopies,
        bool? isArchived)
    {
        Title = title ?? Title;
        Author = author ?? Author;
        ISBN = isbn ?? ISBN;
        Publisher = publisher ?? Publisher;
        Price = price ?? Price;
        Language = language ?? Language;
        AvailableCopies = availableCopies ?? AvailableCopies;
        IsArchived = isArchived ?? IsArchived;

        this.AddDomainEvent(new BookPatchedEvent(this));
    }
}
