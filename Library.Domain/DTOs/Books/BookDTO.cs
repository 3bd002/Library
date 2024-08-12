﻿namespace Library.Domain.DTOs.Books;

public class BookDTO
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }
    public string CreatedAt { get; set; }
    public int ShelfId { get; set; }

}

