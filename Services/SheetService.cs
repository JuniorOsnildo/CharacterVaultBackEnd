using CharacterVaulBack.DTOs;
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
            Name = sheetDto.Name,
            Race = sheetDto.Race,
            Origin = sheetDto.Origin,
            Class = sheetDto.Class,
            Level = sheetDto.Level,
            HP = sheetDto.HP,
            MP = sheetDto.MP,
            UserId = sheetDto.UserId,
        };

        var result = sheetRepository.CreateSheet(newSheet);

        return result.Match(
            success => Result.Success<Sheet, string>(success),
            failure => Result.Failure<Sheet, string>(failure.Message)
        );
    }
}