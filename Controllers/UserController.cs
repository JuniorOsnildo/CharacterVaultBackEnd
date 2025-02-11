using CharacterVaulBack.DTOs;
using CharacterVaulBack.Services;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    [Route("add")]
    public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var result = userService.CreateUser(createUserDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
}