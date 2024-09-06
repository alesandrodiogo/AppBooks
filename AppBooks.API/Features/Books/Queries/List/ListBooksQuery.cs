using AppBooks.API.Features.Books.Dtos;
using MediatR;

namespace AppBooks.API.Features.Books.Queries.List;

public record ListBooksQuery : IRequest<List<BookDto>>;


