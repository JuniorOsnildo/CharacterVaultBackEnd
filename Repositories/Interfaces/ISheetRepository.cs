﻿using System.Data.Common;
using CharacterVaulBack.DTOs;
using CharacterVaulBack.Models;
using CharacterVaulBack.Models.Context;
using CSharpFunctionalExtensions;

namespace CharacterVaulBack.Repositories.Interfaces;

public interface ISheetRepository
{
    public Result<Sheet, DbException> CreateSheet(Sheet sheet);
}