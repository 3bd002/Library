using Microsoft.AspNetCore.Mvc;
using Library.Application.Services.Books;
using Library.Domain.DTOs.Books;
using System.Threading.Tasks;
using Library.Domain.DTOs.Shelves;
using Library.Application.Services.Shelves;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class BookController : Controller
{
    private readonly IBookService _bookService;
    private readonly IShelfService _shelfService;

    public BookController(IBookService bookService, IShelfService shelfService)
    {
        _bookService = bookService;
        _shelfService = shelfService;
    }


    [HttpGet]
    public async Task<IActionResult> Create(int shelfId)
    {
        var shelf = await _shelfService.GetShelfById(shelfId);
        if (shelf == null)
        {
            return NotFound();
        }

        var bookDTO = new BookDTO { ShelfId = shelfId };
        return View(bookDTO);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BookDTO bookDTO)
    {
        if (ModelState.IsValid)
        {
            await _bookService.CreateBook(bookDTO);
            return RedirectToAction("Details", "Shelf", new { id = bookDTO.ShelfId });
        }
        return View(bookDTO);
    }


    public async Task<IActionResult> Edit(int id)
    {
        var bookDTO = await _bookService.GetBookById(id);
        if (bookDTO == null)
        {
            return NotFound();
        }
        return View(bookDTO);
    }

    // POST: Book/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,  BookDTO bookDTO)
    {
        if (id != bookDTO.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                await _bookService.UpdateBook(bookDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BookExists(bookDTO.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", "Shelf", new { id = bookDTO.ShelfId });
        }
        return View(bookDTO);
    }

    // GET: Book/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var bookDTO = await _bookService.GetBookById(id);
        if (bookDTO == null)
        {
            return NotFound();
        }

        return View(bookDTO);
    }

    // POST: Book/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var bookDTO = await _bookService.GetBookById(id);
        if (bookDTO == null)
        {
            return NotFound();
        }

        await _bookService.DeleteBook(id);
        return RedirectToAction("Details", "Shelf", new { id = bookDTO.ShelfId });
    }

    private async Task<bool> BookExists(int id)
    {
        var book = await _bookService.GetBookById(id);
        return book != null;
    }


}
