using System.Collections.ObjectModel;
using AvaloniaRPG.Models.Items;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Interfaces;

public interface IInventoryService
{
    public WeaponModel GetWeapon();
    
    ObservableCollection<ItemSlot> GetEquipmentSlots();
}