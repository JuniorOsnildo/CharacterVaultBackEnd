using CharacterVaulBack.DTOs.Skill;
using CharacterVaulBack.Services;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;


[ApiController]
[Route("[controller]")]

public class SkillController(ISkillService skillService) : ControllerBase
{
    [HttpPost]
    [Route("skills")]
    public IActionResult CreateSkill([FromBody] CreateSkillDto createSkillDto)
    {
        var result = skillService.CreateSkill(createSkillDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpDelete]
    [Route("delete")]
    public IActionResult DeleteSkill([FromBody] DeleteSkillDto deleteSkillDto)
    {
        var result = skillService.DeleteSkill(deleteSkillDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPatch]
    [Route("update")]
    public IActionResult UpdateSkill([FromBody] UpdateSkillDto updateSkillDto)
    {
        var result = skillService.UpdateSkill(updateSkillDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
}