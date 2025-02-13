﻿using CharacterVaulBack.DTOs.Sheet;
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
            UserId = sheetDto.UserId,
        };

        var result = sheetRepository.CreateSheet(newSheet);

        return result.Match(
            success => Result.Success<Sheet, string>(success),
            failure => Result.Failure<Sheet, string>(failure.Message)
        );
    }

    public Result<string, string> DeleteSheet(DeleteSheetDto sheetDto)
    {

        var result = sheetRepository.DeleteSheet(sheetDto.SheetId);
 
        return result.Match(
            success => Result.Success<string, string>(success),
            failure => Result.Failure<string, string>(failure.Message)
        );
    }

    public Result<Sheet, string> UpdateSheet(UpdateSheetDto sheetDto)
    {
        var existingSheetResult = sheetRepository.GetSheet(sheetDto.SheetId);
        
        var existingSheet = existingSheetResult.Value;

        var sheet = new Sheet
        {
            Name = sheetDto.Name ?? existingSheet.Name,
            Race = sheetDto.Race ?? existingSheet.Race,
            Origin = sheetDto.Origin ?? existingSheet.Origin,
            Class = sheetDto.Class ?? existingSheet.Class,
            Level = sheetDto.Level ?? existingSheet.Level,
            HP = sheetDto.Hp ?? existingSheet.HP,
            MP = sheetDto.Mp ?? existingSheet.MP,
            UserId = sheetDto.UserId,
            Id = sheetDto.SheetId
        };
        
        var result = sheetRepository.UpdateSheet(sheet);
        
        return result.Match(
            success => Result.Success<Sheet, string>(success),
            failure => Result.Failure<Sheet, string>(failure.Message)
        );
    }
    
}