using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VirtualCommunitySupport.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpGet("admin")]
    public IActionResult AdminOnly() => Ok("Welcome, Admin!");

    [Authorize(Roles = "User")]
    [HttpGet("user")]
    public IActionResult UserOnly() => Ok("Hello, User!");


}
