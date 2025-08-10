using Books.Application.Books.Queries.GetFilteredBooks;
using Books.Application.Data;
using Books.Application.Interfaces;
using Books.Domain.BookAggregate;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Repositories;

public class BookRepository(IApplicationDbContext _dbContext) : IBookRepository
{
    public void Add(Book book, CancellationToken cancellationToken = default)
    {
        _dbContext.Books.Add(book);
    }

    public void Delete(Book book, CancellationToken cancellationToken = default)
    {
        _dbContext.Books.Remove(book);
    }

    public async Task<Book?> GetByIdAsync(BookId id, CancellationToken cancellationToken = default)
    {
        var book = await _dbContext.Books
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        return book;
    }

    public async Task<IEnumerable<Book>> GetFilteredAsync(GetFilteredBooksQuery filters, CancellationToken cancellationToken = default)
    {
        var query =  _dbContext.Books.AsNoTracking();

        if(filters.Title is not null)
        {
            query = query.Where(b => b.Title.Equals(filters.Title));
        }
        if (filters.Author is not null)
        {
            query = query.Where(b => b.Author.Equals(filters.Author));
        }
        if (filters.Language is not null)
        {
            query = query.Where(b => b.Language == filters.Language);
        }
        if (filters.IsArchived.HasValue)
        {
            query = query.Where(b => b.IsArchived == filters.IsArchived.Value);
        }

        return await query.ToListAsync(cancellationToken);
    }

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Update(Book book, CancellationToken cancellationToken = default)
    {
        _dbContext.Books.Update(book);
    }
}
