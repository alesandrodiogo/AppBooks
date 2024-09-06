using AppBooks.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppBooks.Infra.Data.Percistense;
public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<Book> Books { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(x => x.Id);
        modelBuilder.Entity<Book>().HasData(
            new Book("1984", "George Orwell", "Dystopian", 1949),
            new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 1960),
            new Book("The Great Gatsby", "F. Scott Fitzgerald", "Tragedy", 1925)
            );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("alesandro");
    }
}
