using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public class SkillService(ISkillRepository skillRepository) : ISkillService
{
    public Result<Skill, string> CreateSkill(CreateSkillDto skillDto)
    {
        var newSkill = new Skill
        {
            Name = skillDto.Name,
            Source = skillDto.Source,
            SheetId = skillDto.SheetId,
        };
        
        var result = skillRepository.CreateSkill(newSkill);
        
        return result.Match(
            success => Result.Success<Skill, string>(success),
            failure => Result.Failure<Skill, string>(failure.Message)
        );
    }
}