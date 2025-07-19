using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels.Inventory;

public class ItemSlot : ObservableObject
{
    private ItemModel _item;
    public ItemModel Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }
}