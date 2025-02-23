using CharacterVaulBack.DTOs.Sheet;
using CharacterVaulBack.Models;
using CharacterVaulBack.Repositories.Interfaces;
using CharacterVaulBack.Services.Interfaces;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services;

public class SheetService(ISheetRepository sheetRepository) : ISheetService
{
    public Result<Sheet, string> CreateSheet(CreateSheetDto sheetDto)
    {
        var newSheet = new Sheet
        {
            Name = sheetDto.Name ?? "",
            Race = sheetDto.Race ?? "",
            Origin = sheetDto.Origin ?? "",
            Class = sheetDto.Class ?? "",
            Level = sheetDto.Level ?? 0 ,
            HP = sheetDto.Hp ?? 0,
            MP = sheetDto.Mp ?? 0,
            strength = sheetDto.strength ?? 0,
            dexterity = sheetDto.dexterity ?? 0,
            constitution = sheetDto.constitution ?? 0,
            intelligence = sheetDto.intelligence ?? 0,
            wisdom = sheetDto.wisdom ?? 0,
            charisma = sheetDto.charisma ?? 0,
            UserId = sheetDto.UserId,
        };

        var result = sheetRepository.CreateSheet(newSheet);

        return result.Match(
            success => Result.Success<Sheet, string>(success),
            failure => Result.Failure<Sheet, string>(failure.Message)
        );
    }

    public Result<string, string> DeleteSheet(int sheetId)
    {

        var result = sheetRepository.DeleteSheet(sheetId);
 
        return result.Match(
            success => Result.Success<string, string>(success),
            failure => Result.Failure<string, string>(failure.Message)
        );
    }

    public Result<Sheet, string> UpdateSheet(UpdateSheetDto sheetDto)
    {
        
        var sheet = new Sheet
        {
            Name = sheetDto.Name ?? "",
            Race = sheetDto.Race ?? "",
            Origin = sheetDto.Origin ?? "",
            Class = sheetDto.Class ?? "",
            Level = sheetDto.Level ?? 0,
            HP = sheetDto.Hp ?? 0,
            MP = sheetDto.Mp ?? 0,
            strength = sheetDto.strength ?? 0,
            dexterity = sheetDto.dexterity ?? 0,
            constitution = sheetDto.constitution ?? 0,
            intelligence = sheetDto.intelligence ?? 0,
            wisdom = sheetDto.wisdom ?? 0,
            charisma = sheetDto.charisma ?? 0,
            UserId = sheetDto.UserId,
            Id = sheetDto.SheetId
        };
        
        var result = sheetRepository.UpdateSheet(sheet);
        
        return result.Match(
            success => Result.Success<Sheet, string>(success),
            failure => Result.Failure<Sheet, string>(failure.Message)
        );
    }

    public Result<Sheet, string> GetSheet(GetSheetDto sheetDto)
    {
        var result = sheetRepository.GetSheet(sheetDto.SheetId);
 
        return result.Match(
            success => Result.Success<Sheet, string>(success),
            failure => Result.Failure<Sheet, string>(failure.Message)
        );
    }

    public Result<Sheet[], string> GetAllSheetIds(GetAllSheetsDto getAllSheetsDto)
    {
        var result = sheetRepository.GetAllSheetIds(getAllSheetsDto.UserId);

        return result.Match(
            success => Result.Success<Sheet[], string>(success),
            failure => Result.Failure<Sheet[], string>(failure.Message)
        );
    }
    
}