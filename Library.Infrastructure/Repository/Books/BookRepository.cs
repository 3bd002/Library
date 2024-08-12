using Library.Domain.Entities.Books;
using Library.Domain.Entities.Shelves;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository.Books
{
    public class BookRepository : IBookRepository
    {
        private readonly DBLibraryContext _context;

        public BookRepository(DBLibraryContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetById(int id) // Implement this method
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<List<Book>> GetBooksByShelfId(int shelfId)
        {
            return await _context.Books.Where(b => b.ShelfId == shelfId).ToListAsync();
        }

        public async Task Add(Book book)

        {
            book.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd");
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Book book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if (existingBook != null)
            {
                _context.Entry(existingBook).CurrentValues.SetValues(book);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Handle the case where the book is not found
                throw new InvalidOperationException("Book not found");
            }
        }

        public async Task Delete(int id)
        {
            _context.Books.Remove(await GetById(id));

            

            await _context.SaveChangesAsync();

        }
    }
}
