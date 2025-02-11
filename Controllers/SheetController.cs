using CharacterVaulBack.DTOs;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;

[ApiController]
[Route("[controller]")]
public class SheetController(ISheetService sheetService) : ControllerBase
{
    [HttpPost]
    [Route("sheet")]
    public IActionResult CreateSheet([FromBody] CreateSheetDto createSheetDto)
    {
        var result = sheetService.CreateSheet(createSheetDto);
        
        return result.IsSuccess 
            ? Ok(result) 
            : BadRequest(result);
        
    }
}