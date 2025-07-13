namespace AvaloniaRPG.Models;

public class CharacterModel
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int MaxHp { get; set; }
    public int CurrentHp { get; set; }

    public CharacterModel(string name,  int level, int maxHp, int currentHp)
    {
        Name = name;
        Level = level;
        MaxHp = maxHp;
        CurrentHp = currentHp;
    }
}