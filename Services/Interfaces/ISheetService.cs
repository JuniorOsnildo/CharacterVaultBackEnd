using CharacterVaulBack.DTOs.Sheet;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public interface ISheetService
{
    public Result<Sheet, string> CreateSheet(CreateSheetDto sheet);
    
    public Result<string, string> DeleteSheet(int sheetId);

    public Result<Sheet, string> UpdateSheet(UpdateSheetDto sheetDto);
    
    public Result<Sheet, string> GetSheet(GetSheetDto sheet);

    public Result<Sheet[], string> GetAllSheetIds(GetAllSheetsDto getAllSheetsDto);
}