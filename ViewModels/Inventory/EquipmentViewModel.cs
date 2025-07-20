using System.Collections.ObjectModel;
using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels.Inventory;

public partial class EquipmentViewModel : PageViewModel
{
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
    
    public EquipmentViewModel()
    {
        EquipmentSlots.Add(Neckless);
        EquipmentSlots.Add(Helmet);
        EquipmentSlots.Add(Buff);
        EquipmentSlots.Add(Weapon);
        EquipmentSlots.Add(Armor);
        EquipmentSlots.Add(SecondHand);
        EquipmentSlots.Add(Gloves);
        EquipmentSlots.Add(Boots);
        EquipmentSlots.Add(Ring);
        
        
        Helmet.Item = new ItemModel { Name = "Iron Helmet" };
        Weapon.Item = new ItemModel { Name = "Axe" };
        SecondHand.Item = new ItemModel { Name = "Shield" };
        Armor.Item = new ItemModel { Name = "Armor" };
        Neckless.Item = new ItemModel { Name = "Neckless" };
        Ring.Item = new ItemModel { Name = "Ring" };
        Boots.Item = new ItemModel { Name = "Boots" };
        Gloves.Item = new ItemModel { Name = "Gloves" };
        Buff.Item = new ItemModel { Name = "Buff" };
        
    }
}