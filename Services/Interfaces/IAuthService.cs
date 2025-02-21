using CharacterVaulBack.DTOs.Sheet;
using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public interface IAuthService
{
    public Result<string, bool> UserLogin(UserLoginDto user);
}