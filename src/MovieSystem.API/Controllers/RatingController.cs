using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Services;
using MovieSystem.Application.DTOs;

namespace MovieSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RatingController : ControllerBase
{
    private readonly RatingService _ratingService;

    public RatingController(RatingService ratingService)
    {
        _ratingService = ratingService;
    }

    // GET: api/rating
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var ratings = await _ratingService.GetAllAsync();
        return Ok(ratings);
    }

    // GET: api/rating/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var rating = await _ratingService.GetByIdAsync(id);
        if (rating == null) return NotFound();
        return Ok(rating);
    }

    // GET: api/rating/by-movie/{movieId}
    [HttpGet("by-movie/{movieId:guid}")]
    public async Task<IActionResult> GetByMovie(Guid movieId)
    {
        var ratings = await _ratingService.GetByMovieIdAsync(movieId);
        return Ok(ratings);
    }

    // GET: api/rating/by-user/{userId}
    [HttpGet("by-user/{userId:guid}")]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var ratings = await _ratingService.GetByUserIdAsync(userId);
        return Ok(ratings);
    }

    // POST: api/rating
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RatingDto dto)
    {
        await _ratingService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.RatingId }, dto);
    }

    // PUT: api/rating/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] RatingDto dto)
    {
        if (id != dto.RatingId)
            return BadRequest("ID mismatch");

        await _ratingService.UpdateAsync(dto);
        return NoContent();
    }

    // DELETE: api/rating/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _ratingService.DeleteAsync(id);
        return NoContent();
    }
}