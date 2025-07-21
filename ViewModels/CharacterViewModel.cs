using System.ComponentModel;
using System.Diagnostics;
using AvaloniaRPG.Data;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using AvaloniaRPG.ViewModels.Inventory;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaRPG.ViewModels;

public partial class CharacterViewModel : PageViewModel
{
    
    private readonly ICharacterService  _characterService;
    
    [ObservableProperty]
    private CharacterModel _character;
    
    public BackpackViewModel Backpack { get; }
    public  EquipmentViewModel Equipment { get; }
    public CharacterViewModel( ICharacterService characterService, BackpackViewModel backpack,  EquipmentViewModel equipment)
    {
        PageName = ApplicationPageNames.Character;
        _characterService = characterService;
        _character = _characterService.GetCharacter();
        Backpack = backpack;
        Equipment = equipment;
        Equipment.Character = Character;
        _characterService.UpdateCharacterStats(Character, equipment.EquipmentSlots);
    }
    [RelayCommand]
    private void SaveCharacter()
    {
        Debug.WriteLine("SaveCharacter called");
        _characterService.SaveCharacter(Character);
    }
    
    
 
}