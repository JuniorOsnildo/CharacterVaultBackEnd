﻿using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Jwt;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService authService, IConfiguration configuration) : ControllerBase
{
    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] UserLoginDto userLoginDto)
    {
        var jwtHandler = new JwtHandler(configuration);
        var dadada = authService.UserLogin(userLoginDto);


        if (!dadada.IsSuccess) return Unauthorized();
        var userId = dadada.Value.Id;
        var token = jwtHandler.GenerateToken(dadada.Value.Email);
            
        return Ok(new
        {
            UserId = userId,
            Token = token
        });

    }
}