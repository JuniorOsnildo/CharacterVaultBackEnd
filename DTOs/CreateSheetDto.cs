namespace CharacterVaulBack.DTOs;

public class CreateSheetDto
{
    public string Name { get; set; }
    public string Race { get; set; }
    public string Origin  { get; set; }
    public string Class { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public int MP { get; set; }
    public int UserId { get; set; }
}