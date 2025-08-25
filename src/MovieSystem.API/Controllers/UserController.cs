using Microsoft.AspNetCore.Mvc;
using MovieSystem.Application.Services;
using MovieSystem.Application.DTOs;

namespace MovieSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    // GET: api/user
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    // GET: api/user/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    // POST: api/user
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserDto dto)
    {
        await _userService.AddAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = dto.UserId }, dto);
    }

    // PUT: api/user/{id}
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UserDto dto)
    {
        if (id != dto.UserId)
            return BadRequest("ID mismatch");

        await _userService.UpdateAsync(dto);
        return NoContent();
    }

    // DELETE: api/user/{id}
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _userService.DeleteAsync(id);
        return NoContent();
    }
}