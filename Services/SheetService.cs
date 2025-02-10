using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CharacterVaulBack.Repositories.Interfaces;
using CharacterVaulBack.Services.Interfaces;

namespace CharacterVaulBack.Services;

public class SheetService(ISheetRepository sheetRepository) : ISheetService
{
    public void CreateSheet(CreateSheetDto sheet)
    {
        sheetRepository.CreateSheet(sheet);
    }
}