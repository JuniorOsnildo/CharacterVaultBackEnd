using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;

namespace CharacterVaulBack.Repositories;

public class SheetRepository(ConnectionContext context) : ISheetRepository
{
    public void CreateSheet(CreateSheetDto sheet)
    {
        var newSheet = new Sheet
        {
            Name = sheet.Name,
            Race = sheet.Race,
            Origin = sheet.Origin,
            Class = sheet.Class,
            Level = sheet.Level,
            HP = sheet.HP,
            MP = sheet.MP,
            
        };
        
        context.Sheets.Add(newSheet);
        context.SaveChanges();
    }
}