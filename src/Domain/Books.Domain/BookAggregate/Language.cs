using System.Text.Json.Serialization;

namespace Books.Domain.BookAggregate;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Language
{
    Arabe,
    English,
    French,
    Spanish,
    German,
    Italian,
    Portuguese,
    Russian,
    Chinese,
    Japanese,
    Korean,
    Hindi,
    Bengali,
    Urdu,
    Turkish,
    Persian,
    Vietnamese
}
