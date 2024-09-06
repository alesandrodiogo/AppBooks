using AppBooks.API.Features.Books.Dtos;
using AppBooks.Infra.Data.Percistense;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AppBooks.API.Features.Books.Queries.List;

public class ListBooksQueryHandler(AppDbContext context) : IRequestHandler<ListBooksQuery, List<BookDto>>
{
    public async Task<List<BookDto>> Handle(
        ListBooksQuery request, CancellationToken cancellationToken)
    {
        return await context.Books
            .Select(b => new BookDto(
                b.Id, b.Title, b.Author, b.Genre, b.YearPublished))
            .ToListAsync(cancellationToken);
    }
}
