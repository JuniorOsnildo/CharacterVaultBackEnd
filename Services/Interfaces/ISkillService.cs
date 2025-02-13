using CharacterVaulBack.DTOs.Skill;
using CharacterVaulBack.Models.Context;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public interface ISkillService
{
    public Result<Skill, string> CreateSkill(CreateSkillDto skill);
    
    public Result<string, string> DeleteSkill(DeleteSkillDto skill);
    
    public Result<Skill, string> UpdateSkill(UpdateSkillDto skillDto);
}
