using Library.Domain.DTOs.Books;
using Library.Domain.DTOs.Shelves;

namespace Library.Application.Services.Shelves;

public interface IShelfService
{
    Task<List<ShelfDTO>> GetAllShelves();
    Task CreateShelf(ShelfDTO shelfDTO);
    Task UpdateShelf(ShelfDTO shelfDTO);
    Task<ShelfDTO> GetShelfById(int id);
    Task DeleteShelf(int id);
    Task<List<BookDTO>> GetBooksByShelfId(int id);
    Task<bool> ShelfExists(int shelfId);
}
