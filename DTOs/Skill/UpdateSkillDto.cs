namespace CharacterVaulBack.DTOs.Skill;

public class UpdateSkillDto
{ 
    public string? Name { get; set; }
    public string? Source { get; set; }
    public int SkillId { get; set; }
    public int SheetId { get; set; }
}