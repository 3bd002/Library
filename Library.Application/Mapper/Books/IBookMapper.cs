using Library.Domain.DTOs.Books;
using Library.Domain.DTOs.Shelves;
using Library.Domain.Entities.Books;
using Library.Domain.Entities.Shelves;
namespace Library.Application.Mapper.Books;

public interface IBookMapper
{
    BookDTO MapFromBookToBookDTO(Book book);
    Book MapFromBookDTOToBook(BookDTO bookDTO);
    List<BookDTO> MapFromBooksToBooksDTO(List<Book> books);
    List<Book> MapFromBooksDTOToBooks(List<BookDTO> bookDTOs);
}

