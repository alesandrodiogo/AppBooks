namespace AppBooks.Domain.Entities;
public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Author { get; set; } = default!;
    public string Genre { get; set; } = default!;
    public int YearPublished { get; set; }

    private Book(){ }

    public Book(string title, string author, string genre, int yearPublished)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        Genre = genre;
        YearPublished = yearPublished;
    }
}
