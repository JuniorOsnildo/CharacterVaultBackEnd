using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models.Context;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public interface ISkillService
{
    public Result<Skill, string> CreateSkill(CreateSkillDto skill);
}