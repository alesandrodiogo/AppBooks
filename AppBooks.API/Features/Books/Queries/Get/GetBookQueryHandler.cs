using AppBooks.API.Features.Books.Dtos;
using AppBooks.Infra.Data.Percistense;
using MediatR;

namespace AppBooks.API.Features.Books.Queries.Get;

public class GetBookQueryHandler(AppDbContext context) : IRequestHandler<GetBookQuery, BookDto?>
{
    public async Task<BookDto?> Handle(
        GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await context.Books.FindAsync(request.id,cancellationToken);
        if(book == null) return null;

        return new BookDto(
            book.Id, book.Title, book.Author, book.Genre, book.YearPublished
            );
    }
}
