using Books.Domain.BookAggregate;

namespace Books.Application.Books.Dtos;

/// <summary>
/// Request DTO to create a new Book.
/// </summary>
public record CreateBookRequest
{
    /// <summary>
    /// Book title.
    /// </summary>
    /// <example>The Great Gatsby</example>
    public required string Title { get; init; }

    /// <summary>
    /// Book author.
    /// </summary>
    /// <example>F. Scott Fitzgerald</example>
    public required string Author { get; init; }

    /// <summary>
    /// International Standard Book Number.
    /// </summary>
    /// <example>978-0141182636</example>
    public required string ISBN { get; init; }

    /// <summary>
    /// Publisher of the book.
    /// </summary>
    /// <example>Scribner</example>
    public required string Publisher { get; init; }

    /// <summary>
    /// Price of the book.
    /// </summary>
    /// <example>15.99</example>
    public decimal Price { get; init; }

    /// <summary>
    /// Language of the book.
    /// </summary>
    /// <example>English</example>
    public Language Language { get; init; }

    /// <summary>
    /// Number of available copies.
    /// </summary>
    /// <example>100</example>
    public int AvailableCopies { get; init; }
}
