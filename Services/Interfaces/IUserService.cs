using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public interface IUserService
{
    public Result<User, string> CreateUser(CreateUserDto user);
    
    public Result<string, string> DeleteUser(DeleteUserDto user);
    
}