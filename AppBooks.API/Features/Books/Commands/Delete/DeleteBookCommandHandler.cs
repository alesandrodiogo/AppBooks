using AppBooks.Infra.Data.Percistense;
using MediatR;

namespace AppBooks.API.Features.Books.Commands.Delete;

public class DeleteBookCommandHandler(AppDbContext context) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(
        DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FindAsync(request.Id);
        if (book == null)
        {
            return;
        }
        context.Books.Remove(book);
        await context.SaveChangesAsync(cancellationToken);
    }
}
