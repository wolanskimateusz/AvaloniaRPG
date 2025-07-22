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
    private readonly IInventoryService _inventoryService;
    
    [ObservableProperty]
    private CharacterModel _character;
    
    public BackpackViewModel Backpack { get; }
    public  EquipmentViewModel Equipment { get; }
    public CharacterViewModel(ICharacterService characterService, BackpackViewModel backpack,  EquipmentViewModel equipment, IInventoryService inventoryService)
    {
        PageName = ApplicationPageNames.Character;
        _characterService = characterService;
        _inventoryService = inventoryService;
        _character = _characterService.GetCharacter();
        Backpack = backpack;
        Backpack.Character = Character;
        Equipment = equipment;
        Equipment.Character = Character;
        _characterService.UpdateCharacterStats(Character, equipment.EquipmentSlots);
        _inventoryService.GetBackpackSlots(Character, backpack.BackpackSlots);
    }
    [RelayCommand]
    private void SaveCharacter()
    {
        Debug.WriteLine("SaveCharacter called");
        _characterService.SaveCharacter(Character);
    }
    
    
 
}