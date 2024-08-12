using Library.Domain.Entities.Books;
using Library.Domain.Entities.Shelves;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Context;

public class DBLibraryContext : DbContext
{
    public DBLibraryContext(DbContextOptions<DBLibraryContext> options) : base(options) { }

    public DbSet<Shelf> Shelves { get; set; }
    public DbSet<Book> Books { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Shelf>().ToTable("Shelves");
        modelBuilder.Entity<Book>().ToTable("Books");
    }
}
