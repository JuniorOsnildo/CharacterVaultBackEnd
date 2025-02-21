using System.Data.Common;
using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories.Interfaces;

public interface IAuthRepository
{
    public Result<User, DbException> UserLogin(string email);
}