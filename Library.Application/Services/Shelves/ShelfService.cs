using Library.Application.Mapper.Shelves;
using Library.Domain.DTOs.Shelves;
using Library.Domain.Entities.Shelves;
using Library.Infrastructure.Repository.Shelves;
using Library.Application.Mapper.Books;
using Library.Domain.DTOs.Books;
using Library.Infrastructure.Repository.Books;

namespace Library.Application.Services.Shelves
{
    public class ShelfService : IShelfService
    {
        private readonly IShelfRepository _shelfRepo;
        private readonly IShelfMapper _shelfMapper;
        private readonly IBookRepository _bookRepo;
        private readonly IBookMapper _bookMapper;

        public ShelfService(IShelfRepository shelfRepo, IShelfMapper shelfMapper, IBookRepository bookRepo, IBookMapper bookMapper)
        {
            _shelfRepo = shelfRepo;
            _shelfMapper = shelfMapper;
            _bookRepo = bookRepo;
            _bookMapper = bookMapper;
        }

        public async Task<List<ShelfDTO>> GetAllShelves()
        {
            List<Shelf> shelves = await _shelfRepo.GetAll();
            List<ShelfDTO> shelvesDTO = _shelfMapper.MapFromShelvesToShelvesDTO(shelves);
            return shelvesDTO;
        }

        public async Task<ShelfDTO> GetShelfById(int id)
        {
            var shelf = await _shelfRepo.GetById(id);
            if (shelf == null)
            {
                return null; // or handle accordingly
            }
            return _shelfMapper.MapFromShelfToShelfDTO(shelf);
        }

        public async Task CreateShelf(ShelfDTO shelfDTO)
        {
            var shelf = _shelfMapper.MapFromShelfDTOToShelf(shelfDTO);
            await _shelfRepo.Create(shelf);
        }

        public async Task UpdateShelf(ShelfDTO shelfDTO)
        {
            var shelf = _shelfMapper.MapFromShelfDTOToShelf(shelfDTO);
            await _shelfRepo.Update(shelf);
        }

        public async Task DeleteShelf(int id)
        {
            await _shelfRepo.Delete(id);
        }

        public async Task<List<BookDTO>> GetBooksByShelfId(int id)
        {
            var books = await _bookRepo.GetBooksByShelfId(id);
            return _bookMapper.MapFromBooksToBooksDTO(books);
        }

        public async Task<bool> ShelfExists(int shelfId)
        {
            var shelf = await _shelfRepo.GetById(shelfId);
            return shelf != null;
        }
    }
}
