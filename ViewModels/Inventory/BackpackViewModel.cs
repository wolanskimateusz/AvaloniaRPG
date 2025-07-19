using System.Collections.ObjectModel;
using AvaloniaRPG.Data;
using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels;



public partial class BackpackViewModel : PageViewModel
{
    
    public ObservableCollection<ItemSlot> Slots { get; } = new ObservableCollection<ItemSlot>();
    
    public BackpackViewModel()
    {
        PageName = ApplicationPageNames.Backpack;
        for (int i = 0; i < 40; i++)
            Slots.Add(new ItemSlot());

        // Dla testu dajemy 2 itemy
        Slots[0].Item = new ItemModel { Name = "Sword" };
        Slots[5].Item = new ItemModel { Name = "Shield" };
    }
}