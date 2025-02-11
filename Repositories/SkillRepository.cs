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
}