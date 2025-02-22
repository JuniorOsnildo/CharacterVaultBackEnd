using CharacterVaulBack.DTOs.Sheet;
using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public interface IAuthService
{
    public Result<User, bool> UserLogin(UserLoginDto user);
}