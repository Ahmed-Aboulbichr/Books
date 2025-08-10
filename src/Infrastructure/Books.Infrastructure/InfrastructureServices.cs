using Books.Application.Data;
using Books.Application.Interfaces;
using Books.Infrastructure.Persistence;
using Books.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Books.Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BooksDb");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();

        services.AddScoped<IBookRepository, BookRepository>();

        return services;
    }
}
