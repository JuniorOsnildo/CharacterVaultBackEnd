using CharacterVaulBack.DTOs;
using CharacterVaulBack.Services;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;


[ApiController]
[Route("[controller]")]

public class SkillController(ISkillService skillService) : ControllerBase
{
    [HttpPost]
    [Route("skill")]
    public IActionResult CreateSkill([FromBody] CreateSkillDto createSkillDto)
    {
        var result = skillService.CreateSkill(createSkillDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
}