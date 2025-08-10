using Books.Domain.BookAggregate;
using Mapster;

namespace Books.Application.Books.Mappings;
public class BookMappings
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<BookId, Guid>
            .NewConfig()
            .MapWith(src => src.Value);
    }
}
