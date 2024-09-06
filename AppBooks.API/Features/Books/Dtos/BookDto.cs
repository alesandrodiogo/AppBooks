namespace AppBooks.API.Features.Books.Dtos;

public record BookDto(
    Guid Id,
    string Title,
    string Author,
    string Genre,
    int YearPublished);

