using System.Data.Common;
using CharacterVaulBack.DTOs.User;
using CharacterVaulBack.Models;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories;

public class AuthRepository(ConnectionContext context) : IAuthRepository
{
    public Result<User, DbException> UserLogin(string email)
    {
        var user = context.Users.FirstOrDefault(u => u.Email == email);

        try
        {
            return Result.Success<User, DbException>(user!);
        }
        catch (DbException e)
        {
            return Result.Failure<User, DbException>(e);
        }
        
    }
}