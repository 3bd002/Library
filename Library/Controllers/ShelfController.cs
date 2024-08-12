using Library.Application.Services.Books;
using Library.Application.Services.Shelves;
using Library.Domain.DTOs.Shelves;
using Library.Domain.Entities.Shelves;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

namespace Library.Web.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfService _shelfService;
        private readonly IBookService _bookService;
        public ShelfController(IShelfService shelfService, IBookService bookService)
        {
            _shelfService = shelfService;
            _bookService = bookService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _shelfService.GetAllShelves());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] ShelfDTO shelfDTO)
        {
            if (ModelState.IsValid)
            {

                await _shelfService.CreateShelf(shelfDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(shelfDTO);
        }

        public async Task<IActionResult> Details(int id)
        {
            var shelf = await _shelfService.GetShelfById(id);
            if (shelf == null)
            {
                return NotFound();
            }

            var books = await _bookService.GetBooksByShelfId(id);
            ViewData["Books"] = books;

            

            return View(shelf);
        }




        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var shelfDTO = await _shelfService.GetShelfById(id);
            if (shelfDTO == null)
            {
                return NotFound();
            }
            return View(shelfDTO);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedAt")] ShelfDTO shelfDTO)
        {
            if (id != shelfDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _shelfService.UpdateShelf(shelfDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(shelfDTO);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shelfDTO = await _shelfService.GetShelfById(id.Value);
            if (shelfDTO == null)
            {
                return NotFound();
            }

            return View(shelfDTO);
        }

        // POST: Shelves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _shelfService.DeleteShelf(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ShelfExists(int id)
        {
            var shelves = _shelfService.GetAllShelves().Result;
            return shelves.Any(e => e.Id == id);
        }
    }
}
