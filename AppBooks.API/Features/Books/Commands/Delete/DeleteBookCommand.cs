using MediatR;

namespace AppBooks.API.Features.Books.Commands.Delete;

public record DeleteBookCommand(Guid Id) : IRequest;

