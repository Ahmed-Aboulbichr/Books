using Books.Application.Books.Commands.CreateBook;
using Books.Application.Books.Commands.DeleteBook;
using Books.Application.Books.Commands.PatchBook;
using Books.Application.Books.Dtos;
using Books.Application.Books.Queries.GetBookById;
using Books.Application.Books.Queries.GetFilteredBooks;
using Books.Domain.BookAggregate;
using Mapster;
using MediatR;

namespace Books.API.Endpoints;

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("/api/books")
            .WithTags("Book");

        group.MapPost("/", CreateBook)
            .WithName("CreateBook")
            .WithSummary("Creates a new book")
            .WithDescription("Creates a new book in the system.")
            .Produces<Guid>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces(StatusCodes.Status500InternalServerError);

        group.MapPatch("/{id:guid}", PatchBook)
             .WithName("Patch Book")
             .WithSummary("Patch properties of a Book")
             .WithDescription("Allows partial updates to a Book entity.")
             .Produces<Guid>(StatusCodes.Status200OK)
             .ProducesValidationProblem(StatusCodes.Status400BadRequest)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .ProducesProblem(StatusCodes.Status500InternalServerError);

        group.MapGet("/", GetFilteredBooks)
             .WithName("GetFilteredCashRegisterReportCurrencies")
             .WithSummary("Get filtered Cash Register Report Currencies with pagination")
             .WithDescription("Returns a paginated list of Cash Register Report Currency entries matching filter criteria.")
             .Produces<IEnumerable<Book>>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status500InternalServerError);

        group.MapGet("/{id:guid}", GetBookById)
             .WithName("GetCashRegisterReportCurrencyById")
             .WithSummary("Get a Cash Register Report Currency by Id")
             .WithDescription("Retrieves a Cash Register Report Currency entity by its unique identifier.")
             .Produces<GetBookResponse>(StatusCodes.Status200OK)
             .ProducesProblem(StatusCodes.Status404NotFound)
             .ProducesProblem(StatusCodes.Status500InternalServerError);

        group.MapDelete("/{id:guid}", DeleteBook)
          .WithName("DeleteCashRegisterReportCurrency")
          .WithSummary("Delete a Cash Register Report Currency row")
          .WithDescription("Permanently removes the specified Cash Register Report Currency entry.")
          .Produces<bool>(StatusCodes.Status200OK)
          .ProducesValidationProblem(StatusCodes.Status400BadRequest)
          .ProducesProblem(StatusCodes.Status404NotFound)
          .ProducesProblem(StatusCodes.Status500InternalServerError);
    }

    internal static async Task<IResult> CreateBook(
        CreateBookRequest request,
        IMediator mediator)
    {
        var command = request.Adapt<CreateBookCommand>();
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }

    internal static async Task<IResult> PatchBook(
        Guid id,
        PatchBookRequest request,
        IMediator mediator)
    {
        var command = request.Adapt<PatchBookCommand>();
        command = command with { Id = id };
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }

    internal static async Task<IResult> GetFilteredBooks(
        [AsParameters] GetFilteredBooksRequest request,
        IMediator mediator)
    {
        var query = request.Adapt<GetFilteredBooksQuery>();
        var result = await mediator.Send(query);
        return Results.Ok(result);
    }

    internal static async Task<IResult> GetBookById(
        Guid id,
        IMediator mediator)
    {
        var query = new GetBookByIdQuery { Id = id };
        var result = await mediator.Send(query);
        return Results.Ok(result);
    }

    internal static async Task<IResult> DeleteBook(
        Guid id,
        IMediator mediator)
    {
        var command = new DeleteBookCommand { Id = id };
        var result = await mediator.Send(command);
        return Results.Ok(result);
    }
}
