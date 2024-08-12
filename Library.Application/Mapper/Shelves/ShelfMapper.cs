using Library.Domain.DTOs.Shelves;
using Library.Domain.Entities.Shelves;

namespace Library.Application.Mapper.Shelves;

public class ShelfMapper : IShelfMapper
{
    public List<ShelfDTO> MapFromShelvesToShelvesDTO(List<Shelf> shelves)
    {
        List<ShelfDTO> shelvesDTO = new List<ShelfDTO>();

        foreach (Shelf shelf in shelves)
        {
            shelvesDTO.Add(new ShelfDTO()
            {
                Id = shelf.Id,
                Name = shelf.Name,
                CreatedAt = shelf.CreatedAt,
            });
        }

        return shelvesDTO;
    }

    public ShelfDTO MapFromShelfToShelfDTO(Shelf shelf)
    {
        return new ShelfDTO
        {
            Id = shelf.Id,
            Name = shelf.Name,
            CreatedAt = shelf.CreatedAt,
        };
    }

    public Shelf MapFromShelfDTOToShelf(ShelfDTO shelfDTO)
    {
        return new Shelf
        {
            Id = shelfDTO.Id,
            Name = shelfDTO.Name,
            CreatedAt = shelfDTO.CreatedAt,
        };
    }

}
