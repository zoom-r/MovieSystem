using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Services;
using MovieSystem.Application.DTOs;

namespace MovieSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;

    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }

    // GET: api/movie
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieService.GetAllAsync();
        return Ok(movies);
    }

    // GET: api/movie/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var movie = await _movieService.GetByIdAsync(id);
        if (movie == null) return NotFound();
        return Ok(movie);
    }

    // GET: api/movie/by-director/{directorId}
    [HttpGet("by-director/{directorId:guid}")]
    public async Task<IActionResult> GetByDirector(Guid directorId)
    {
        var movies = await _movieService.GetByDirectorIdAsync(directorId);
        return Ok(movies);
    }

    // GET: api/movie/by-user/{userId}
    [HttpGet("by-user/{userId:guid}")]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var movies = await _movieService.GetByUserIdWithRatingsAsync(userId);
        return Ok(movies);
    }

    // GET: api/movie/top/{count}
    [HttpGet("top/{count:int}")]
    public async Task<IActionResult> GetTopRated(int count)
    {
        var movies = await _movieService.GetTopRatedAsync(count);
        return Ok(movies);
    }

    // POST: api/movie
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MovieDto dto)
    {
        await _movieService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.MovieId }, dto);
    }

    // PUT: api/movie/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] MovieDto dto)
    {
        if (id != dto.MovieId)
            return BadRequest("ID mismatch");

        await _movieService.UpdateAsync(dto);
        return NoContent();
    }

    // DELETE: api/movie/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _movieService.DeleteAsync(id);
        return NoContent();
    }
}