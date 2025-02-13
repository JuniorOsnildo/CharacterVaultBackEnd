using CharacterVaulBack.DTOs.Skill;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;
using CharacterVaulBack.Services.Interfaces;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services;

public class SkillService(ISkillRepository skillRepository) : ISkillService
{
    public Result<Skill, string> CreateSkill(CreateSkillDto skillDto)
    {
        var newSkill = new Skill
        {
            Name = skillDto.Name,
            Source = skillDto.Source ?? "",
            SheetId = skillDto.SheetId,
        };
        
        var result = skillRepository.CreateSkill(newSkill);
        
        return result.Match(
            success => Result.Success<Skill, string>(success),
            failure => Result.Failure<Skill, string>(failure.Message)
        );
    }

    public Result<string, string> DeleteSkill(DeleteSkillDto skillDto)
    {
        
        var result = skillRepository.DeleteSkill(skillDto.SkillId);
 
        return result.Match(
            success => Result.Success<string, string>(success),
            failure => Result.Failure<string, string>(failure.Message)
        );
    }

    public Result<Skill, string> UpdateSkill(UpdateSkillDto skillDto)
    {
        
        var existingSkillResult = skillRepository.GetSkill(skillDto.SkillId);

        var existingSkill = existingSkillResult.Value;
        
        var skillUpdates = new Skill
        {
            Name = skillDto.Name ?? existingSkill.Name,
            Source = skillDto.Source ?? existingSkill.Source, 
            Id = skillDto.SkillId,
            SheetId = skillDto.SheetId,
        };

        var result = skillRepository.UpdateSkill(skillUpdates);

        return result.Match(
            success => Result.Success<Skill, string>(success),
            failure => Result.Failure<Skill, string>(failure.Message)
        );

    }
    
}