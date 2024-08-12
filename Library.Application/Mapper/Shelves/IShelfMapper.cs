using Library.Domain.DTOs.Shelves;
using Library.Domain.Entities.Shelves;

namespace Library.Application.Mapper.Shelves;

public interface IShelfMapper
{
    List<ShelfDTO> MapFromShelvesToShelvesDTO(List<Shelf> shelves);
    ShelfDTO MapFromShelfToShelfDTO(Shelf shelf);
    Shelf MapFromShelfDTOToShelf(ShelfDTO shelfDTO);

}