using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using AvaloniaRPG.Models.Items;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaRPG.ViewModels.Inventory;

public partial class EquipmentViewModel : PageViewModel
{
    private readonly IInventoryService _inventoryService;
    private readonly ICharacterService _characterService;
    private readonly ICharacterContextService _characterContextService;

    public CharacterModel Character { get; set; } = null!;
    
    public  ObservableCollection<ItemSlot> EquipmentSlots { get; }

    
    public EquipmentViewModel(IInventoryService inventoryService, ICharacterService characterService, ICharacterContextService characterContextService)
    {
        Debug.WriteLine("EqViewModel update 1");
        _characterService = characterService;
        _inventoryService = inventoryService;
       // _characterContextService = characterContextService;
        EquipmentSlots = _inventoryService.GetEquipmentSlots();
        
        SetPropertyChangedHandlers();
        Debug.WriteLine("EqViewModel update 2");
    }
    
    private void SetPropertyChangedHandlers()
    {
        foreach (var slot in EquipmentSlots)
        {
            slot.PropertyChanged += OnSlotChanged;
        }
    }
    
    private void OnSlotChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (Character == null)
        {
            Debug.WriteLine("Character is null – skipping stat update");
            return;
        }

        if (e.PropertyName == nameof(ItemSlot.Item))
        {
            Debug.WriteLine("Slot changed – updating character stats");
            _characterService.UpdateCharacterStats(Character, EquipmentSlots);
        }
    }
    
    
    [RelayCommand]
    private void ChangeWeapon()
    {
        var newWeapon = new WeaponModel { Name = "Sword", Strength = 10 };
        var weaponSlot = EquipmentSlots.FirstOrDefault(slot => slot.Item is WeaponModel);
        if (weaponSlot != null)
            weaponSlot.Item = newWeapon;
    }


}