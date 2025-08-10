using System.Text.Json.Serialization;
using Books.Domain.Abstractions;

namespace Books.Domain.BookAggregate;

public class BookId : IValueObject
{
    public Guid Value { get; }

    [JsonConstructor]
    public BookId(Guid value) => Value = value;

    public override string ToString() => Value.ToString();
    public static BookId Create() => new BookId(Guid.NewGuid());

    public static BookId Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new Exception($"{nameof(BookId)} cannot be empty.");
        }
        return new BookId(value);
    }

    public IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

}

