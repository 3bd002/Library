using Library.Domain.DTOs.Books;

namespace Library.Domain.DTOs.Shelves;

public class ShelfDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CreatedAt { get; set; }
    public List<BookDTO> Books { get; set; } = new List<BookDTO>();
}
