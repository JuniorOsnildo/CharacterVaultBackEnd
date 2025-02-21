using System.Text;
using CharacterVaulBack.DTOs.User;
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

    public Result<string, string> DeleteUser(DeleteUserDto userDto)
    {
        var result = userRepository.DeleteUser(userDto.UserId);

        return result.Match(
            success => Result.Success<string, string>(success),
            failure => Result.Failure<string, string>(failure.Message)
        );
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