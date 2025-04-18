using Microsoft.AspNetCore.Mvc;

namespace ApiBackend;

[ApiController]
[Route("api/[controller]")]
public class SessionController : ControllerBase
{
    [HttpGet("set")]
    public IActionResult SetSession()
    {
        HttpContext.Session.SetString("User", "Alper");
        return Ok("Session set");
    }

    [HttpGet("get")]
    public IActionResult GetSession()
    {
        var user = HttpContext.Session.GetString("User") ?? "not set";
        return Ok($"User: {user}");
    }
}