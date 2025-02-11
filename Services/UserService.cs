using System.Text;
using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CharacterVaulBack.Repositories.Interfaces;
using CharacterVaulBack.Services.Interfaces;
using CSharpFunctionalExtensions;
using Konscious.Security.Cryptography;

namespace CharacterVaulBack.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    public Result<User, string> CreateUser(CreateUserDto userDto)
    {
        var hashedPassword = HashPassword(userDto.Password);
        
        var newUser = new User
        {
            Username = userDto.Username,
            Password = hashedPassword,
            Email = userDto.Email,
        };
        
        var result = userRepository.CreateUser(newUser);

        return result.Match(
            success => Result.Success<User, string>(success),
            failure => Result.Failure<User, string>(failure.Message)
        );
        
    }

    private static string HashPassword(string password)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);
        var salt = new byte[128 / 8];
        new Random().NextBytes(salt);
        
        var argon2 = new Argon2id(passwordBytes);
        
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = 3;
        argon2.MemorySize = 128*1024;
        argon2.Iterations = 4;
        
        return Convert.ToBase64String(argon2.GetBytes(32));
    }
}