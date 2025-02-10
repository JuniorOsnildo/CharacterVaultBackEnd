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
        sheetService.CreateSheet(createSheetDto);
        return Ok();
    }
}