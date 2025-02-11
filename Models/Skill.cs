using System.ComponentModel.DataAnnotations;

namespace CharacterVaulBack.Models.Context;

public class Skill
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Source { get; set; }
    public int SheetId { get; set; }
    public Sheet Sheet { get; set; }
}