using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieSystem.Application.DTOs;
using MovieSystem.Application.Services;

namespace MovieSystem.WebUI.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;
        private readonly DirectorService _directorService;

        public MovieController(MovieService movieService, DirectorService directorService)
        {
            _movieService = movieService;
            _directorService = directorService;
        }

        // GET: Movies
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllAsync();
            return View(movies);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // GET: Movies/Create
        public async Task<IActionResult> Create()
        {
            var directors = await _directorService.GetAllAsync();
            ViewBag.Directors = new SelectList(directors, "DirectorId", "Name");
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                var directors = await _directorService.GetAllAsync();
                ViewBag.Directors = new SelectList(directors, "DirectorId", "Name", dto.DirectorId);
                return View(dto);
            }

            await _movieService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();

            var directors = await _directorService.GetAllAsync();
            ViewBag.Directors = new SelectList(directors, "DirectorId", "Name", movie.DirectorId);

            return View(movie);
        }

        // POST: Movies/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                var directors = await _directorService.GetAllAsync();
                ViewBag.Directors = new SelectList(directors, "DirectorId", "Name", dto.DirectorId);
                return View(dto);
            }

            await _movieService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _movieService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}