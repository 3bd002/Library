using Library.Domain.Entities.Shelves;

namespace Library.Infrastructure.Repository.Shelves;

public interface IShelfRepository
{
    Task<List<Shelf>> GetAll();
    Task<Shelf> GetById(int id);
    Task Create(Shelf shelf);
    Task Update(Shelf shelf);
    Task Delete(int id);
    Task SaveChangesAsync();
}
