using AvaloniaRPG.Models;

namespace AvaloniaRPG.ViewModels;

public partial class CharacterViewModel : ViewModelBase
{
    public CharacterModel Character { get; }
    public CharacterViewModel()
    {
        Character = new CharacterModel("Geralt", 5, 120, 100);
    }
    
    public string Name => Character.Name;
    public int Level => Character.Level;
    public int MaxHp => Character.MaxHp;
    public int CurrentHp => Character.CurrentHp;
}