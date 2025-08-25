using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Services;
using MovieSystem.Application.DTOs;

namespace MovieSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectorController : ControllerBase
{
    private readonly DirectorService _directorService;

    public DirectorController(DirectorService directorService)
    {
        _directorService = directorService;
    }

    // GET: api/director
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var directors = await _directorService.GetAllAsync();
        return Ok(directors);
    }

    // GET: api/director/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var director = await _directorService.GetByIdAsync(id);
        if (director == null) return NotFound();
        return Ok(director);
    }

    // GET: api/director/{id}/movies
    [HttpGet("{id:guid}/movies")]
    public async Task<IActionResult> GetMovies(Guid id)
    {
        var movies = await _directorService.GetMoviesWithAverageRatingAsync(id);
        return Ok(movies);
    }

    // POST: api/director
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] DirectorDto dto)
    {
        await _directorService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.DirectorId }, dto);
    }

    // PUT: api/director/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] DirectorDto dto)
    {
        if (id != dto.DirectorId)
            return BadRequest("ID mismatch");

        await _directorService.UpdateAsync(dto);
        return NoContent();
    }

    // DELETE: api/director/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _directorService.DeleteAsync(id);
        return NoContent();
    }
}