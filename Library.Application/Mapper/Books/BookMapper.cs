using Library.Domain.DTOs.Books;
using Library.Domain.Entities.Books;
namespace Library.Application.Mapper.Books;

public class BookMapper : IBookMapper
{
    public BookDTO MapFromBookToBookDTO(Book book)
    {
        if (book == null) // Check for null input
        {
            return null;
        }

        return new BookDTO
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Description = book.Description,
            CreatedAt = book.CreatedAt,
            ShelfId = book.ShelfId
        };
    }

    public Book MapFromBookDTOToBook(BookDTO bookDTO)
    {
        if (bookDTO == null) // Check for null input
        {
            return null;
        }

        return new Book
        {
            Id = bookDTO.Id,
            Title = bookDTO.Title,
            Author = bookDTO.Author,
            Description = bookDTO.Description,
            CreatedAt= bookDTO.CreatedAt,
            ShelfId = bookDTO.ShelfId,
        };
    }

    public List<BookDTO> MapFromBooksToBooksDTO(List<Book> books)
    {
        return books.Select(b => new BookDTO
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description,
            CreatedAt = b.CreatedAt,
            ShelfId = b.ShelfId
        }).ToList();
    }

    public List<Book> MapFromBooksDTOToBooks(List<BookDTO> bookDTOs)
    {
        return bookDTOs.Select(b => new Book
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Description = b.Description,
            CreatedAt = b.CreatedAt,
            ShelfId = b.ShelfId
        }).ToList();
    }
}

