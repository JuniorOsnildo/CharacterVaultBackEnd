using System.Data.Common;
using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories;

public class SkillRepository(ConnectionContext context) : ISkillRepository
{
    public Result<Skill, DbException> CreateSkill(Skill skill)
    {
        
        var newSkill = context.Skill.Add(skill);

        try
        {
            context.SaveChanges();
            return Result.Success<Skill, DbException>(newSkill.Entity);
        }
        catch (DbException e)
        {
            return Result.Failure<Skill, DbException>(e);
        }
        
    }

    public Result<string, DbException> DeleteSkill(int id)
    {
        var skillRemove = context.Skill.Find(id)!;
        context.Skill.Remove(skillRemove);

        try
        {
            context.SaveChanges();
            return Result.Success<string, DbException>("Skill deleted");
        }
        catch (DbException e)
        {
            return Result.Failure<string, DbException>(e);
        }
    }

    public Result<Skill, DbException> UpdateSkill(Skill skill)
    {
        
        var skillUpdate = context.Skill.Find(skill.Id);

        try
        {
            if (skillUpdate is not null)
            {
                context.Entry(skillUpdate).CurrentValues.SetValues(skill);
                context.SaveChanges();
            }
        }
        catch (DbException e)
        {
            return Result.Failure<Skill, DbException>(e);
        }
        
        return Result.Success<Skill, DbException>(skill);
    }

    public Result<Skill, DbException> GetSkill(int id)
    {
        
        var skill = context.Skill.Find(id);
        
        try
        {
            return Result.Success<Skill, DbException>(skill);
        }
        catch (DbException e)
        {
            return Result.Failure<Skill, DbException>(e);
        }
        
    }
    
}