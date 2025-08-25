using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.DTOs;
using MovieSystem.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        // GET: /Movie
        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetAllAsync();
            return View(movies);
        }

        // GET: /Movie/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        // GET: /Movie/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDirectors();
            return View();
        }

        // POST: /Movie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDirectors();
                return View(dto);
            }

            await _movieService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Movie/Edit/{id}
        public async Task<IActionResult> Edit(Guid id)
        {
            var movie = await _movieService.GetByIdAsync(id);
            if (movie == null) return NotFound();

            await PopulateDirectors();
            return View(movie);
        }

        // POST: /Movie/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MovieDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDirectors();
                return View(dto);
            }

            await _movieService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _movieService.DeleteAsync(id);
            return Ok(new { message = "Deleted successfully" });
        }

        private async Task PopulateDirectors()
        {
            var directors = await _directorService.GetAllAsync();
            ViewBag.Directors = new SelectList(directors, "DirectorId", "Name");
        }
    }
}