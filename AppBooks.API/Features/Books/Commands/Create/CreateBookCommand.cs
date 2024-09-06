using MediatR;

namespace AppBooks.API.Features.Books.Commands.Create;

public record CreateBookCommand(
    string Title, string Author, string Genre, int YearPublished) : IRequest<Guid>;