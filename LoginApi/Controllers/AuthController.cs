using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
        if (user == null || user.Password != dto.Password) // Replace with hash comparison
            return Unauthorized("Invalid credentials");

        return Ok(new { user.Email, user.Role });
    }
}

public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
}
