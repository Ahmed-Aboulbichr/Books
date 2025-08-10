using Books.Domain.BookAggregate;
using Microsoft.EntityFrameworkCore;

namespace Books.Application.Data;

public interface IApplicationDbContext
{

    public DbSet<Book> Books { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
