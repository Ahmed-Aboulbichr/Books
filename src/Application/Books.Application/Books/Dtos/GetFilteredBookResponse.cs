using Books.Domain.BookAggregate;

namespace Books.Application.Books.Dtos;

/// <summary>
/// Data Transfer Object representing a filtered Book record in response collections.
/// </summary>
/// <param name="Id">Unique identifier of the book.</param>
/// <param name="Title">Title of the book.</param>
/// <param name="Author">Author name of the book.</param>
/// <param name="ISBN">International Standard Book Number.</param>
/// <param name="Publisher">Publisher of the book.</param>
/// <param name="Price">Price of the book.</param>
/// <param name="Language">Language of the book (enum).</param>
/// <param name="AvailableCopies">Number of available copies.</param>
/// <param name="IsArchived">Indicates whether the book is archived (true if archived).</param>
public record GetFilteredBookResponse(
    Guid Id,
    string Title,
    string Author,
    string ISBN,
    string Publisher,
    decimal Price,
    Language Language,
    int AvailableCopies,
    bool IsArchived
    );
