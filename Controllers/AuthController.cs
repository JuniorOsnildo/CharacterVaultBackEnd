using CharacterVaulBack.DTOs.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] UserLoginDto userLoginDto)
    {
        return Ok();
    }
}