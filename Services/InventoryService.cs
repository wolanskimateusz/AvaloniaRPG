using System.Collections.ObjectModel;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using AvaloniaRPG.Models.Items;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Services;

public class InventoryService : IInventoryService
{
    private ObservableCollection<ItemSlot> _equipmentSlots;
    
    private ItemSlot Helmet { get; } = new ItemSlot();
    private ItemSlot Armor { get; } = new ItemSlot();
    private ItemSlot Weapon { get; } = new ItemSlot();
    private ItemSlot SecondHand { get; } = new ItemSlot();
    private ItemSlot Boots { get; } = new ItemSlot();
    private ItemSlot Gloves { get; } = new ItemSlot();
    private ItemSlot Neckless { get; } = new ItemSlot();
    private ItemSlot Ring { get; } = new ItemSlot();
    private ItemSlot Buff { get; } = new ItemSlot();
    
    public InventoryService()
    {
        _equipmentSlots = new ObservableCollection<ItemSlot>
        {
            Neckless,
            Helmet,
            Buff,
            Weapon,
            Armor,
            SecondHand,
            Gloves,
            Boots,
            Ring
        };

        SetSampleItems();
    }
    
    private void SetSampleItems()
    {
        Helmet.Item = new ItemModel { Name = "Iron Helmet" };
        Weapon.Item = new WeaponModel { Name = "Sword", Strength = 5 };
        SecondHand.Item = new ItemModel { Name = "Shield" };
        Armor.Item = new ItemModel { Name = "Armor" };
        Neckless.Item = new ItemModel { Name = "Neckless" };
        Ring.Item = new ItemModel { Name = "Ring" };
        Boots.Item = new ItemModel { Name = "Boots" };
        Gloves.Item = new ItemModel { Name = "Gloves" };
        Buff.Item = new ItemModel { Name = "Buff" };
    }
    
    // tymczasowe przychowywanie eq dla testów
    private WeaponModel _weapon = new WeaponModel {Name = "Axe", Strength = 10};
    private IInventoryService _inventoryServiceImplementation;

    public WeaponModel GetWeapon()
    {
        var weapon = _weapon;
        
        return weapon;
    }

    public ObservableCollection<ItemSlot> GetEquipmentSlots()
    {
        return _equipmentSlots;
    }
}