using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Models;

public class ItemModel
{
    public string Name  { get; set; }
    public virtual SlotType SlotType => SlotType.None;
}