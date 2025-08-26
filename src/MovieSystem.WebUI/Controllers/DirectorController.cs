using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.DTOs;
using MovieSystem.Application.Services;

namespace MovieSystem.WebUI.Controllers
{
    public class DirectorController : Controller
    {
        private readonly DirectorService _directorService;
        private readonly MovieService _movieService;

        public DirectorController(DirectorService directorService)
        {
            _directorService = directorService;
        }

        // GET: Directors
        public async Task<IActionResult> Index()
        {
            var directors = await _directorService.GetAllAsync();
            return View(directors);
        }

        // GET: Directors/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var director = await _directorService.GetByIdAsync(id);
            if (director == null) return NotFound();
            return View(director);
        }

        // GET: Directors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DirectorDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _directorService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Directors/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var director = await _directorService.GetByIdAsync(id);
            if (director == null) return NotFound();
            return View(director);
        }

        // POST: Directors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DirectorDto dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            await _directorService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Directors/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var director = await _directorService.GetByIdAsync(id);
            if (director == null) return NotFound();
            return View(director);
        }

        // POST: Directors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _directorService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}