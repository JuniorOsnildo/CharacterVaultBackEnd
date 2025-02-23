using System.Data.Common;
using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CharacterVaulBack.Models.Context;
using CharacterVaulBack.Repositories.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Components.Sections;

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
        catch (DbException e)
        {
            return Result.Failure<Sheet, DbException>(e);
        }
        
        
    }

    public Result<string, DbException> DeleteSheet(int id)
    {

        var sheetRemove = context.Sheets.Find(id)!;
        context.Sheets.Remove(sheetRemove);

        try
        {
            context.SaveChanges();
            return Result.Success<string, DbException>("Sheet deleted");
        }
        catch (DbException e)
        {
            return Result.Failure<string, DbException>(e);
        }

    }
    
    public Result<Sheet, DbException> UpdateSheet(Sheet sheet)
    {
        
        var sheetUpdate = context.Sheets.Find(sheet.Id);

        try
        {
            if (sheetUpdate is not null)
            {
                context.Entry(sheetUpdate).CurrentValues.SetValues(sheet);
                context.SaveChanges();
            }
        }
        catch (DbException e)
        {
            return Result.Failure<Sheet, DbException>(e);
        }
        
        return Result.Success<Sheet, DbException>(sheet);
    }


    public Result<Sheet, DbException> GetSheet(int id)
    {
        var sheet = context.Sheets.Find(id);

        try
        {
            return Result.Success<Sheet, DbException>(sheet!);
        }
        catch (DbException e)
        {
            return Result.Failure<Sheet, DbException>(e);
        }
    }

    public Result<Sheet[], DbException> GetAllSheetIds(int userId)
    {
        var user = context.Users.Find(userId)!;
        
        var sheets = context.Sheets.
            Where(s => s.UserId == userId).
            Select(s => s).
            ToArray();
        

        try
        {
            return Result.Success<Sheet[], DbException>(sheets);
        }
        catch (DbException e)
        {
            return Result.Failure<Sheet[], DbException>(e);
        }
        
    }
}