using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Services;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;

[ApiController]
[Route("[controller]")]

public class UserController(IUserService userService) : ControllerBase
{
    [HttpPost]
    [Route("users")]
    public IActionResult CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var result = userService.CreateUser(createUserDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteUser([FromBody] DeleteUserDto deleteUserDto)
    {
        var result = userService.DeleteUser(deleteUserDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    
}