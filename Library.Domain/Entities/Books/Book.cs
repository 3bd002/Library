using Library.Domain.Entities.Shelves;

namespace Library.Domain.Entities.Books;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string CreatedAt { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public string hello { get; set; }
    public int ShelfId { get; set; }
    public Shelf Shelf { get; set; }
}
