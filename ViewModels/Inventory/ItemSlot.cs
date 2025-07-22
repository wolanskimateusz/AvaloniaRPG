using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels.Inventory;

public enum SlotType
{
    None,
    Weapon,
    Helmet,
    Armor,
    Ring,
    Neckless,
    SecondHand,
    Boots,
    Gloves,
    Buff
}

public partial class ItemSlot : ObservableObject
{
    [ObservableProperty]
    private ItemModel? _item;
    
    [ObservableProperty]
    private SlotType slotType =  SlotType.None;
    
    
    public string? DisplayName => Item?.Name;
    
    partial void OnItemChanged(ItemModel? oldValue, ItemModel? newValue)
    {
        OnPropertyChanged(nameof(DisplayName));
    }
   
}