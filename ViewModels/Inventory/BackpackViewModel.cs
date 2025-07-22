using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaRPG.Data;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using AvaloniaRPG.ViewModels.Inventory;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels;



public partial class BackpackViewModel : PageViewModel
{

    private readonly IInventoryService  _inventoryService;
    private readonly ICharacterService _characterService;
    public ObservableCollection<ItemSlot> BackpackSlots { get; set; }
    public CharacterModel Character { get; set; } = null!;
    
    public BackpackViewModel(IInventoryService inventoryService, ICharacterService characterService)
    {
        _inventoryService = inventoryService;
        _characterService = characterService;

        BackpackSlots = _inventoryService.GetBackpackSlots(Character, BackpackSlots);

    }
    
}