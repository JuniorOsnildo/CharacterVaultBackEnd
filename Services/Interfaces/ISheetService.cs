﻿using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Services.Interfaces;

public interface ISheetService
{
    public Result<Sheet, string> CreateSheet(CreateSheetDto sheet);
}