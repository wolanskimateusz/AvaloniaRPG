using System.Collections.ObjectModel;
using Avalonia.Controls;
using Avalonia.Input;
using AvaloniaRPG.Data;
using AvaloniaRPG.Models;
using AvaloniaRPG.ViewModels.Inventory;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels;



public partial class BackpackViewModel : PageViewModel
{
    
    public ObservableCollection<ItemSlot> BackpackSlots { get; } = new ObservableCollection<ItemSlot>();
    
    public BackpackViewModel()
    {
        PageName = ApplicationPageNames.Backpack;
        
        for (int i = 0; i < 40; i++)
            BackpackSlots.Add(new ItemSlot());

        // Dla testu dajemy 2 itemy
        BackpackSlots[0].Item = new ItemModel { Name = "Sword" };
        BackpackSlots[5].Item = new ItemModel { Name = "Shield" };
    }
    
}