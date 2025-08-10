using System.Reflection;
using Books.Application.Data;
using Books.Domain.BookAggregate;
using Microsoft.EntityFrameworkCore;

namespace Books.Infrastructure.Persistence;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContext) : DbContext(dbContext), IApplicationDbContext
{

    public DbSet<Book> Books => Set<Book>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }
}
