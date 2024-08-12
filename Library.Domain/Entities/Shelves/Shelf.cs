using Library.Domain.Entities.Books;

namespace Library.Domain.Entities.Shelves;

public class Shelf
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatedAt { get; set; }
    public ICollection<Book> Books { get; set; }
}
