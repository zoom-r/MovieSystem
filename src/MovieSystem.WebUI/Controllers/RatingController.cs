using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.DTOs;
using MovieSystem.Application.Services;

public class RatingController : Controller
{
    private readonly RatingService _ratingService;
    private readonly UserService _userService;
    private readonly MovieService _movieService;

    public RatingController(
        RatingService ratingService,
        UserService userService,
        MovieService movieService)
    {
        _ratingService = ratingService;
        _userService = userService;
        _movieService = movieService;
    }

    // List all ratings
    public async Task<IActionResult> Index()
    {
        var ratings = await _ratingService.GetAllAsync();
        return View(ratings);
    }

    // Rating details
    public async Task<IActionResult> Details(Guid id)
    {
        var rating = await _ratingService.GetByIdAsync(id);
        if (rating == null) return NotFound();
        return View(rating);
    }

    // Show create form
    public async Task<IActionResult> Create()
    {
        ViewBag.Users = await _userService.GetAllAsync();   // for user dropdown
        ViewBag.Movies = await _movieService.GetAllAsync(); // for movie dropdown
        return View();
    }

    // Handle create form submission
    [HttpPost]
    public async Task<IActionResult> Create(RatingDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Users = await _userService.GetAllAsync();
            ViewBag.Movies = await _movieService.GetAllAsync();
            return View(dto);
        }

        await _ratingService.AddAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // Show edit form
    public async Task<IActionResult> Edit(Guid id)
    {
        var rating = await _ratingService.GetByIdAsync(id);
        if (rating == null) return NotFound();

        ViewBag.Users = await _userService.GetAllAsync();
        ViewBag.Movies = await _movieService.GetAllAsync();
        return View(rating);
    }

    // Handle edit form submission
    [HttpPost]
    public async Task<IActionResult> Edit(RatingDto dto)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Users = await _userService.GetAllAsync();
            ViewBag.Movies = await _movieService.GetAllAsync();
            return View(dto);
        }

        await _ratingService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    // Delete
    public async Task<IActionResult> Delete(Guid id)
    {
        await _ratingService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}