using CharacterVaulBack.DTOs.Sheet;
using CharacterVaulBack.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CharacterVaulBack.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class SheetController(ISheetService sheetService) : ControllerBase
{
    [HttpPost]
    [Route("sheets")]
    public IActionResult CreateSheet([FromBody] CreateSheetDto createSheetDto)
    {
        var result = sheetService.CreateSheet(createSheetDto);
        
        return result.IsSuccess 
            ? Ok(result.Value) 
            : BadRequest(result.Error);
        
    }

    [HttpDelete]
    [Route("delete/{sheetId}")]
    public IActionResult DeleteSheet(int sheetId)
    {
        var result = sheetService.DeleteSheet(sheetId);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpPatch]
    [Route("update")]
    public IActionResult UpdateSheet([FromBody] UpdateSheetDto updateSheetDto)
    {
        var result = sheetService.UpdateSheet(updateSheetDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpGet]
    [Route("get")]
    public IActionResult GetSheet([FromQuery] GetSheetDto getSheetDto)
    {
        var result = sheetService.GetSheet(getSheetDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
    
    [HttpPost]
    [Route("getAll")]
    public IActionResult GetAllSheets([FromBody] GetAllSheetsDto getAllSheetsDto)
    {
        var result = sheetService.GetAllSheetIds(getAllSheetsDto);
        
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }
}

