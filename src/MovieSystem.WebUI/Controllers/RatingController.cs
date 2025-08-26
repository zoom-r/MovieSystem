using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieSystem.Application.DTOs;
using MovieSystem.Application.Services;

namespace MovieSystem.WebUI.Controllers
{
    public class RatingController : Controller
    {
        private readonly RatingService _ratingService;
        private readonly UserService _userService;
        private readonly MovieService _movieService;

        public RatingController(RatingService ratingService, UserService userService, MovieService movieService)
        {
            _ratingService = ratingService;
            _userService = userService;
            _movieService = movieService;
        }

        // GET: Ratings
        public async Task<IActionResult> Index()
        {
            var ratings = await _ratingService.GetAllAsync();
            return View(ratings);
        }

        // GET: Ratings/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null) return NotFound();
            return View(rating);
        }

        // GET: Ratings/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View(new RatingDto
            {
                UserId = Guid.Empty,
                MovieId = Guid.Empty,
                Score = 0
            });
        }

        // POST: Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RatingDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _ratingService.AddAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Ratings/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null) return NotFound();

            await PopulateDropdowns();
            return View(rating);
        }

        // POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RatingDto dto)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns();
                return View(dto);
            }

            await _ratingService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        // GET: Ratings/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null) return NotFound();
            return View(rating);
        }

        // POST: Ratings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _ratingService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task PopulateDropdowns()
        {
            var users = (await _userService.GetAllAsync()) ?? new List<UserDto>();
            var movies = (await _movieService.GetAllAsync()) ?? new List<MovieDto>();

            ViewBag.Users = new SelectList(users, "UserId", "FullName", null);
            ViewBag.Movies = new SelectList(movies, "MovieId", "Title", null);
        }
    }
}