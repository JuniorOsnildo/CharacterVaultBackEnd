using System.Data.Common;
using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories.Interfaces;

public interface IUserRepository
{
    public Result<User, DbException> CreateUser(User user);
    
    public Result<string, DbException> DeleteUser(int userId);
}