using System.ComponentModel;
using Books.Domain.BookAggregate;

namespace Books.Application.Books.Dtos;

/// <summary>
/// Request DTO for querying filtered Books with pagination.
/// </summary>
public record GetFilteredBooksRequest : FilterRequest
{
    /// <summary>
    /// Optional filter by book title (partial match).
    /// </summary>
    public string? Title { get; init; }

    /// <summary>
    /// Optional filter by author name (partial match).
    /// </summary>
    public string? Author { get; init; }

    /// <summary>
    /// Optional filter by language.
    /// </summary>
    public Language? Language { get; init; }

    /// <summary>
    /// Optional filter by archived status.
    /// </summary>
    public bool? IsArchived { get; init; }
}

/// <summary>
/// Base class for pagination and enabled/archived filtering.
/// </summary>
public record FilterRequest
{
    private int? _pageNumber;
    private int? _pageSize;

    /// <summary>
    /// The page number to retrieve (default 1).
    /// </summary>
    [DefaultValue(1)]
    public int? PageNumber
    {
        get => _pageNumber ?? 1;
        init => _pageNumber = value;
    }

    /// <summary>
    /// Number of records per page (default 10).
    /// </summary>
    [DefaultValue(10)]
    public int? PageSize
    {
        get => _pageSize ?? 10;
        init => _pageSize = value;
    }
}
