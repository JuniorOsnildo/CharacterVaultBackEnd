using System.Data.Common;
using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;
using CharacterVaulBack.Services;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories;

public class UserRepository(ConnectionContext context) : IUserRepository
{
    public Result<User, DbException> CreateUser(User user)
    {
        
        var newUser = context.Users.Add(user);
        
        try
        {
            context.SaveChanges();
            return Result.Success<User, DbException>(newUser.Entity);
        }
        catch (DbException e)
        {
            return Result.Failure<User, DbException>(e);
        }
        
    }
}