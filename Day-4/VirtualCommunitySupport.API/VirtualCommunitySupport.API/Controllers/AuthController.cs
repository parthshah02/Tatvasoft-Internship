using Microsoft.AspNetCore.Mvc;
using VirtualCommunitySupport.Models;
using VirtualCommunitySupport.Services;

namespace VirtualCommunitySupport.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService) => _jwtService = jwtService;

    private readonly List<User> _users = new()
    {
        new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
        new User { Id = 2, Username = "user", Password = "user123", Role = "User" }
    };

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto dto)
    {
        var user = _users.SingleOrDefault(u =>
            u.Username == dto.Username && u.Password == dto.Password);

        if (user == null) return Unauthorized("Invalid credentials.");

        var token = _jwtService.GenerateToken(user);
        return Ok(new { token });
    }
}
