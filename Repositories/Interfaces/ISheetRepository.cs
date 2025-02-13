using System.Data.Common;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories.Interfaces;

public interface ISheetRepository
{
    public Result<Sheet, DbException> CreateSheet(Sheet sheet);
    
    public Result<string, DbException> DeleteSheet(int sheetId);

    public Result<Sheet, DbException> GetSheet(int sheetId);

    public Result<Sheet, DbException> UpdateSheet(Sheet sheet);
}