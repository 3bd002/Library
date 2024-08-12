using Library.Domain.Entities.Books;

namespace Library.Infrastructure.Repository.Books;

public interface IBookRepository
{
    Task<List<Book>> GetAll();
    Task<Book> GetById(int id); // Ensure this method is defined here
    Task<List<Book>> GetBooksByShelfId(int shelfId);
    Task Add(Book book);
    Task Update(Book book);
    Task Delete(int id);

}

