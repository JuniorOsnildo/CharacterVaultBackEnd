using System.Text;
using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Models;
using CharacterVaulBack.Repositories.Interfaces;
using CharacterVaulBack.Services.Interfaces;
using CSharpFunctionalExtensions;
using Konscious.Security.Cryptography;

namespace CharacterVaulBack.Services;

public class AuthService(IAuthRepository authRepository) : IAuthService
{
    public Result<User, bool> UserLogin(UserLoginDto user)
    {
        
        var result = authRepository.UserLogin(user.Email);
        
        if (result.Value is null) return Result.Failure<User, bool>(false);
        var loginUserPasswordHash = HashPassword(user.Password);
        
        //VALIDA A SENHA DO USUARIO
        return loginUserPasswordHash != result.Value.Password
            ? Result.Failure<User, bool>(false)
            : Result.Success<User, bool>(result.Value);

    }
    
    private static string HashPassword(string password)
    {
        //APLICA HASH A SENHA DO USUARIO
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        
        var argon2 = new Argon2id(passwordBytes);
        
        argon2.DegreeOfParallelism = 3;
        argon2.MemorySize = 128*1024;
        argon2.Iterations = 4;
        
        return Convert.ToBase64String(argon2.GetBytes(32));
    }
    
}