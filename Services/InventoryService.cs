using System.Collections.ObjectModel;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using AvaloniaRPG.Models.Items;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Services;

public class InventoryService : IInventoryService
{
    private readonly ObservableCollection<ItemSlot> _equipmentSlots;

    private readonly ObservableCollection<ItemSlot> _backpackSlots;
    
    private ItemSlot Helmet { get; } = new() {SlotType = SlotType.Helmet};
    private ItemSlot Armor { get; } = new() {SlotType = SlotType.Armor};
    private ItemSlot Weapon { get; } = new() {SlotType = SlotType.Weapon};
    private ItemSlot SecondHand { get; } = new() {SlotType = SlotType.SecondHand};
    private ItemSlot Boots { get; } = new() {SlotType = SlotType.Boots};
    private ItemSlot Gloves { get; } = new() {SlotType = SlotType.Gloves};
    private ItemSlot Neckless { get; } = new() {SlotType = SlotType.Neckless};
    private ItemSlot Ring { get; } = new() {SlotType = SlotType.Ring};
    private ItemSlot Buff { get; } = new() {SlotType = SlotType.Buff};
    
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

        _backpackSlots = new ObservableCollection<ItemSlot>();
       setBackpackSlots(_backpackSlots);

        SetSampleItems();
    }
    
    private void SetSampleItems()
    {
        Helmet.Item = new HelmetModel { Name = "Iron Helmet", Intelligence = 10};
        Weapon.Item = new WeaponModel { Name = "Sword", Strength = 5 };
        SecondHand.Item = new ItemModel { Name = "Shield" };
        Armor.Item = new ItemModel { Name = "Armor" };
        Neckless.Item = new ItemModel { Name = "Neckless" };
        Ring.Item = new ItemModel { Name = "Ring" };
        Boots.Item = new ItemModel { Name = "Boots" };
        Gloves.Item = new ItemModel { Name = "Gloves" };
        Buff.Item = new ItemModel { Name = "Buff" };
    }

    private void setBackpackSlots(ObservableCollection<ItemSlot> BackpackSlots)
    {
        {
            for (int i = 0; i < 40; i++) 
                BackpackSlots.Add(new ItemSlot { SlotType = SlotType.None});
            
            //temp itemy
            
            BackpackSlots[5].Item = new WeaponModel { Name = "Axe" , Strength = 10};
            BackpackSlots[2].Item = new HelmetModel { Name = "Helmet", Intelligence = 5};

        };
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

    public ObservableCollection<ItemSlot> GetBackpackSlots(CharacterModel Character, ObservableCollection<ItemSlot> BackpackSlots)
    {
        return _backpackSlots;
    }
}