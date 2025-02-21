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
    public Result<string, bool> UserLogin(UserLoginDto user)
    {
        
        var result = authRepository.UserLogin(user.Email);
        
        if (result.Value is null) return Result.Failure<string, bool>(false);
        var loginUserPasswordHash = HashPassword(user.Password);

        return loginUserPasswordHash != result.Value.Password
            ? Result.Failure<string, bool>(false)
            : Result.Success<string, bool>(result.Value.Email);

    }
    
    private static string HashPassword(string password)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        
        var argon2 = new Argon2id(passwordBytes);
        
        argon2.DegreeOfParallelism = 3;
        argon2.MemorySize = 128*1024;
        argon2.Iterations = 4;
        
        return Convert.ToBase64String(argon2.GetBytes(32));
    }
    
}