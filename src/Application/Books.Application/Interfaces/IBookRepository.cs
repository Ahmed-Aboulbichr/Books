using Books.Application.Books.Dtos;
using Books.Application.Books.Queries.GetFilteredBooks;
using Books.Domain.BookAggregate;

namespace Books.Application.Interfaces;

public interface IBookRepository
{
    Task<Book?> GetByIdAsync(BookId id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Book>> GetFilteredAsync(GetFilteredBooksQuery query, CancellationToken cancellationToken = default);
    void Add(Book book, CancellationToken cancellationToken = default);
    void Update(Book book, CancellationToken cancellationToken = default);
    void Delete(Book book, CancellationToken cancellationToken = default);
    Task SaveChangesAsync(CancellationToken cancellationToken = default);    
}
