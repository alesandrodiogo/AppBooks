
using AppBooks.API.Features.Books.Commands.Create;
using AppBooks.API.Features.Books.Commands.Delete;
using AppBooks.API.Features.Books.Queries.Get;
using AppBooks.API.Features.Books.Queries.List;
using AppBooks.Infra.Data.Percistense;
using MediatR;
using System.Reflection;

namespace AppBooks.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();

        builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        builder.Services.AddDbContext<AppDbContext>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapGet("/books/{id:guid}", async (Guid id, ISender mediatr) =>
         {
             var book = await mediatr.Send(new GetBookQuery(id));
             if (book == null) return Results.NotFound();
             return Results.Ok(book);
         });

        app.MapGet("/books", async (ISender mediatr) =>
        {
            var books = await mediatr.Send(new ListBooksQuery());
            return Results.Ok(books);
        });

        app.MapPost("/books", async (CreateBookCommand command, ISender mediatr) =>
        {
            var bookId = await mediatr.Send(command);
            if(Guid.Empty == bookId) return Results.BadRequest();
            return Results.Created($"/books/{bookId}", new {id = bookId});
        });

        app.MapDelete("/books/{id:guid}", async (Guid id, ISender mediatr) =>
        {
            await mediatr.Send(new DeleteBookCommand(id));
            return Results.NoContent();
        });

        app.Run();
    }
}
