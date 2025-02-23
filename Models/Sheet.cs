﻿using System.ComponentModel.DataAnnotations;

namespace CharacterVaulBack.Models;

public class Sheet
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Race { get; set; }
    public string Origin  { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int strength { get; set; }
    public int dexterity { get; set; }
    public int constitution { get; set; }
    public int intelligence { get; set; }
    public int wisdom { get; set; }
    public int charisma { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
}