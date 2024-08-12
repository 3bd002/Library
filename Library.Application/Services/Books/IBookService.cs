using Library.Domain.DTOs.Books;

namespace Library.Application.Services.Books;

public interface IBookService
{
    Task<List<BookDTO>> GetAllBooks();
    Task<BookDTO> GetBookById(int id);
    Task CreateBook(BookDTO bookDTO);
    Task UpdateBook(BookDTO bookDTO);
    Task DeleteBook(int id);
    Task<List<BookDTO>> GetBooksByShelfId(int shelfId);
    
}

