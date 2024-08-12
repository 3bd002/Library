using Library.Domain.Entities.Shelves;
using Library.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repository.Shelves;

public class ShelfRepository : IShelfRepository
{
    private readonly DBLibraryContext _context;
    public ShelfRepository(DBLibraryContext context)
    {
        _context = context;
    }

    public async Task<List<Shelf>> GetAll()
    {
        return await _context.Shelves.ToListAsync();
    }
    public async Task<Shelf> GetById(int id)
    {
        return await _context.Shelves
            .Include(s => s.Books) // if you have navigation properties
            .FirstOrDefaultAsync(s => s.Id == id);
    }


    public async Task Create(Shelf shelf)
    {
        shelf.CreatedAt = DateTime.Now.ToString("yyyy-MM-dd");
        await _context.Shelves.AddAsync(shelf);
        await SaveChangesAsync();
    }

    public async Task Update(Shelf shelf)
    {
        _context.Shelves.Update(shelf);
        await SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
        _context.Shelves.Remove(await GetById(id));
        await SaveChangesAsync();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}
