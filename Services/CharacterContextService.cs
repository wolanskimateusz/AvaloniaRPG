using System.Collections.ObjectModel;
using System.Diagnostics;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Services;

public class CharacterContextService : ICharacterContextService
{
    private readonly ICharacterService _characterService;
    private readonly IInventoryService _inventoryService;

    public CharacterModel Character { get; private set; }
    public ObservableCollection<ItemSlot> EquipmentSlots { get; private set; }

    public CharacterContextService(ICharacterService characterService, IInventoryService inventoryService)
    {
        _characterService = characterService;
        _inventoryService = inventoryService;
    }

    public void LoadContext()
    {
        Character = _characterService.GetCharacter();
        EquipmentSlots = _inventoryService.GetEquipmentSlots();
        _characterService.UpdateCharacterStats(Character, EquipmentSlots);
        Debug.WriteLine("CharacterContextService update");
    }

    public void RefreshStats()
    {
        _characterService.UpdateCharacterStats(Character, EquipmentSlots);
    }
}