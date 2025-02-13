using System.Data.Common;
using CharacterVaulBack.Models;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;
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

    public Result<string, DbException> DeleteUser(int userId)
    {

        var userRemove = context.Users.Find(userId)!;
        context.Users.Remove(userRemove);

        try
        {
            context.SaveChanges();
            return Result.Success<string, DbException>("User deleted");
        }
        catch (DbException e)
        {
            return Result.Failure<string, DbException>(e);
        }
        
    }
    
}