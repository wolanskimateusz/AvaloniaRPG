using System.Collections.ObjectModel;
using AvaloniaRPG.Models;
using AvaloniaRPG.Models.Items;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Interfaces;

public interface IInventoryService
{
    public WeaponModel GetWeapon();
    
    ObservableCollection<ItemSlot> GetEquipmentSlots();
    ObservableCollection<ItemSlot> GetBackpackSlots(CharacterModel Character, ObservableCollection<ItemSlot> BackpackSlots);
}