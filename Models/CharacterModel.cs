using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.Models;

public  partial class CharacterModel : ObservableObject
{
    public string Name { get; set; } = "John Doe";
    public int Level { get; set; } = 1;
    public int MaxHp { get; set; } = 100;
    public int CurrentHp { get; set; } = 100;
    public int Experience { get; set; } = 0;

    [ObservableProperty] 
    private int strength;
    public int Dexterity { get; set; } = 3;
    public int Intelligence { get; set; } = 3;
    public int Defence { get; set; } = 3;


}