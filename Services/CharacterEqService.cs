using System.Collections.ObjectModel;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Services;

public class CharacterEqService : ICharacterEqService
{
    private readonly ICharacterService _characterService;
    private readonly IInventoryService _inventoryService;

    public CharacterModel Character { get; private set; }
    public ObservableCollection<ItemSlot> EquipmentSlots { get; private set; }

    public CharacterEqService(ICharacterService characterService, IInventoryService inventoryService)
    {
        _characterService = characterService;
        _inventoryService = inventoryService;

        LoadContext();
    }

    public void LoadContext()
    {
        Character = _characterService.GetCharacter();
        EquipmentSlots = _inventoryService.GetEquipmentSlots();
        _characterService.UpdateCharacterStats(Character, EquipmentSlots);
    }

    public void RefreshStats()
    {
        _characterService.UpdateCharacterStats(Character, EquipmentSlots);
    }
}