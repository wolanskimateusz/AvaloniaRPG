using System.ComponentModel;
using System.Diagnostics;
using AvaloniaRPG.Data;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaRPG.ViewModels;

public partial class CharacterViewModel : PageViewModel
{
    
    private readonly ICharacterService  _characterService;
    
    [ObservableProperty]
    private CharacterModel _character;
    public CharacterViewModel( ICharacterService characterService)
    {
        PageName = ApplicationPageNames.Character;
        _characterService = characterService;
        _character = GetCharacter();
    }
    [RelayCommand]
    private void SaveCharacter()
    {
        Debug.WriteLine("SaveCharacter called");
        _characterService.SaveCharacter(Character);
    }

    private CharacterModel GetCharacter()
    {
        var character = _characterService.GetCharacter();
        Debug.WriteLine($"Loaded character: {character?.Name ?? "null"}");
        return character;
    }
    
 
}