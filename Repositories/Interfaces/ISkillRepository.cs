using System.Data.Common;
using CharacterVaulBack.Models.Context;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories.Interfaces;

public interface ISkillRepository
{
    public Result<Skill, DbException> CreateSkill(Skill skill);
    
    public Result<string, DbException> DeleteSkill(int skillId);
    
    public Result<Skill, DbException> UpdateSkill(Skill skill);
    
    public Result<Skill, DbException> GetSkill(int skillId);
}