using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.DTOs;
using MovieSystem.Application.Services;

public class DirectorController : Controller
{
    private readonly DirectorService _directorService;

    public DirectorController(DirectorService directorService)
    {
        _directorService = directorService;
    }

    public async Task<IActionResult> Index() => View(await _directorService.GetAllAsync());

    public async Task<IActionResult> Details(Guid id)
    {
        var director = await _directorService.GetByIdAsync(id);
        if (director == null) return NotFound();
        return View(director);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(DirectorDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _directorService.AddAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var director = await _directorService.GetByIdAsync(id);
        if (director == null) return NotFound();
        return View(director);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(DirectorDto dto)
    {
        if (!ModelState.IsValid) return View(dto);
        await _directorService.UpdateAsync(dto);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        await _directorService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}