using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;

namespace CharacterVaulBack.Services.Interfaces;

public interface ISheetService
{
    public void CreateSheet(CreateSheetDto sheet);
}