using AppBooks.API.Features.Books.Dtos;
using MediatR;

namespace AppBooks.API.Features.Books.Queries.Get;

public record GetBookQuery(Guid id) : IRequest<BookDto>;
