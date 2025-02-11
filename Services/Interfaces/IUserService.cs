using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public interface IUserService
{
    public Result<User, string> CreateUser(CreateUserDto user);
}