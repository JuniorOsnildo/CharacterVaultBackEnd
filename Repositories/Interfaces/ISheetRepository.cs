using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;

namespace CharacterVaulBack.Repositories.Interfaces;

public interface ISheetRepository
{
    public void CreateSheet(CreateSheetDto sheet);
}