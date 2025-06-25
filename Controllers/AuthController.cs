using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Jwt;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController(IAuthService authService, IConfiguration configuration) : ControllerBase
{
    //Rota de login
    [HttpPost]
    [Route("login")]
    public IActionResult Login([FromBody] UserLoginDto userLoginDto)
    {
        
        var jwtHandler = new JwtHandler(configuration);
        var autenticacao = authService.UserLogin(userLoginDto);

        //VALIDA O USUARIO E CRIA UM JAVA TOKEN PARA ENVIO
        if (!autenticacao.IsSuccess) return Unauthorized();
        var userId = autenticacao.Value.Id;
        var token = jwtHandler.GenerateToken(autenticacao.Value.Email);
            
        return Ok(new
        {
            UserId = userId,
            Token = token
        });

    }
}