using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

    public CharacterModel Character { get; set; } = null!;
    public ObservableCollection<ItemSlot> EquipmentSlots { get; } = new();

    private ItemSlot Helmet { get; } = new ItemSlot();
    private ItemSlot Armor { get; } = new ItemSlot();
    private ItemSlot Weapon { get; } = new ItemSlot();
    private ItemSlot SecondHand { get; } = new ItemSlot();
    private ItemSlot Boots { get; } = new ItemSlot();
    private ItemSlot Gloves { get; } = new ItemSlot();
    private ItemSlot Neckless { get; } = new ItemSlot();
    private ItemSlot Ring { get; } = new ItemSlot();
    private ItemSlot Buff { get; } = new ItemSlot();
    
    public EquipmentViewModel(IInventoryService inventoryService, ICharacterService characterService)
    {
        _characterService = characterService;
        _inventoryService = inventoryService;
        SetEqSlots();
        SetItems();
        
        
    }
    private void SetEqSlots()
    {
        AddSlot(Neckless, "Neckless");
        AddSlot(Helmet, "Helmet");
        AddSlot(Buff, "Buff");
        AddSlot(Weapon, "Weapon");
        AddSlot(Armor, "Armor");
        AddSlot(SecondHand, "SecondHand");
        AddSlot(Gloves, "Gloves");
        AddSlot(Boots, "Boots");
        AddSlot(Ring, "Ring");
        
    }
    
    private void AddSlot(ItemSlot slot, string slotName)
    {
        slot.PropertyChanged += (s, e) => OnSlotChanged(slotName, s, e);
        EquipmentSlots.Add(slot);
    }
    
    private void OnSlotChanged(string slotName, object? sender, PropertyChangedEventArgs e)
    {
        if (Character == null)
        {
            Debug.WriteLine("Character is null – skipping stat update");
            return;
        }
        
        if (e.PropertyName == nameof(ItemSlot.Item))
        {
            Debug.WriteLine($"{slotName} slot changed – updating character stats");
            _characterService.UpdateCharacterStats(Character,EquipmentSlots);
        }
    }

    private void SetItems()
    {
        Helmet.Item = new ItemModel { Name = "Iron Helmet" };
        Weapon.Item = _inventoryService.GetWeapon();
        SecondHand.Item = new ItemModel { Name = "Shield" };
        Armor.Item = new ItemModel { Name = "Armor" };
        Neckless.Item = new ItemModel { Name = "Neckless" };
        Ring.Item = new ItemModel { Name = "Ring" };
        Boots.Item = new ItemModel { Name = "Boots" };
        Gloves.Item = new ItemModel { Name = "Gloves" };
        Buff.Item = new ItemModel { Name = "Buff" };
    }
    
    [RelayCommand]
    private void ChangeWeapon()
    {
        var newWeapon = new WeaponModel { Name = "Sword", Strength = 5 };
        Weapon.Item = newWeapon;
    }


}