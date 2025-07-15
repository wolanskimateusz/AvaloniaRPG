namespace AvaloniaRPG.Models;

public class CharacterModel
{
    public string Name { get; set; } = "John Doe";
    public int Level { get; set; } = 1;
    public int MaxHp { get; set; } = 100;
    public int CurrentHp { get; set; } = 100;
    public int Experience { get; set; } = 0;
    public int Strength { get; set; } = 3;
    public int Dexterity { get; set; } = 3;
    public int Intelligence { get; set; } = 3;


}