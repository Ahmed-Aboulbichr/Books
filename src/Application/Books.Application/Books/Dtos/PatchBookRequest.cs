using Books.Domain.BookAggregate;

namespace Books.Application.Books.Dtos;

/// <summary>
/// Request DTO for partial update (patch) of a Book.
/// </summary>
public record PatchBookRequest
{
    /// <summary>
    /// New title of the book (optional).
    /// </summary>
    public string? Title { get; init; }

    /// <summary>
    /// New author name (optional).
    /// </summary>
    public string? Author { get; init; }

    /// <summary>
    /// New ISBN number (optional).
    /// </summary>
    public string? ISBN { get; init; }

    /// <summary>
    /// New publisher name (optional).
    /// </summary>
    public string? Publisher { get; init; }

    /// <summary>
    /// New price (optional).
    /// </summary>
    public decimal? Price { get; init; }

    /// <summary>
    /// New language (optional).
    /// </summary>
    public Language? Language { get; init; }

    /// <summary>
    /// New available copy count (optional).
    /// </summary>
    public int? AvailableCopies { get; init; }

    /// <summary>
    /// Flag to archive or unarchive the book (optional).
    /// </summary>
    public bool? IsArchived { get; init; }
}
