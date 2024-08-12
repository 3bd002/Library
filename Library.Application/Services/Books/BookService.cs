using Library.Application.Mapper.Books;
using Library.Domain.DTOs.Books;
using Library.Domain.Entities.Books;
using Library.Infrastructure.Repository.Books;

namespace Library.Application.Services.Books
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepo;
        private readonly IBookMapper _bookMapper;

        public BookService(IBookMapper bookMapper, IBookRepository bookRepo)
        {
            _bookMapper = bookMapper;
            _bookRepo = bookRepo;
        }

        public async Task<List<BookDTO>> GetAllBooks()
        {
            List<Book> books = await _bookRepo.GetAll();
            List<BookDTO> booksDTO = _bookMapper.MapFromBooksToBooksDTO(books);
            return booksDTO;
        }

        public async Task<List<BookDTO>> GetBooksByShelfId(int id)
        {
            var books = await _bookRepo.GetBooksByShelfId(id);
            return _bookMapper.MapFromBooksToBooksDTO(books);
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            var book = await _bookRepo.GetById(id);
            if (book == null)
            {
                return null; // Return null if the book is not found
            }
            return _bookMapper.MapFromBookToBookDTO(book);
        }

        public async Task CreateBook(BookDTO bookDTO)
        {
            var book = _bookMapper.MapFromBookDTOToBook(bookDTO);
            await _bookRepo.Add(book);
        }
        public async Task UpdateBook(BookDTO bookDTO)
        {
            var book = _bookMapper.MapFromBookDTOToBook(bookDTO);
            await _bookRepo.Update(book);
        }

        public async Task DeleteBook(int id)
        {
            await _bookRepo.Delete(id);
        }
    }
}
