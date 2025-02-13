namespace CharacterVaulBack.DTOs.Skill;

public class CreateSkillDto
{
    public string Name { get; set; }
    public string? Source { get; set; }
    public int SheetId { get; set; }
}