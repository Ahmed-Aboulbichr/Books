using Books.Domain.BookAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Books.Infrastructure.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // primary key
        builder.HasKey(e => e.Id);

        // Conversion de l'Id (Value Object)
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => BookId.Of(value))
            .ValueGeneratedNever()
            .IsRequired();

    }
}
