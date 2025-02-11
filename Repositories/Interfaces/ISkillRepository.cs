using System.Data.Common;
using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models.Context;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories.Interfaces;

public interface ISkillRepository
{
    public Result<Skill, DbException> CreateSkill(Skill skill);
}