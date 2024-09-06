using AppBooks.Domain.Entities;
using AppBooks.Infra.Data.Percistense;
using MediatR;

namespace AppBooks.API.Features.Books.Commands.Create;

public class CreateBookCommandHandler(AppDbContext context) : IRequestHandler<CreateBookCommand, Guid>
{
    public async Task<Guid> Handle(
        CreateBookCommand command, CancellationToken cancellationToken)
    {
        var book = new Book(
            command.Title, command.Author, command.Genre, command.YearPublished);
        await context.Books.AddAsync(book, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return book.Id;
    }
}
