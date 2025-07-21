using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels.Inventory;

public partial class ItemSlot : ObservableObject
{
    [ObservableProperty]
    private ItemModel? _item;
    
    public string? DisplayName => Item?.Name;
   
}