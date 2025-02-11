using System.Data.Common;
using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories;

public class SheetRepository(ConnectionContext context) : ISheetRepository
{
    public Result<Sheet, DbException> CreateSheet(Sheet sheet)
    {
        
        var newSheet = context.Sheets.Add(sheet);

        try
        {
            context.SaveChanges();
            return Result.Success<Sheet, DbException>(newSheet.Entity);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        
        
    }
}