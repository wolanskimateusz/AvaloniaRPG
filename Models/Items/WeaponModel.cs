using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Models.Items;

public class WeaponModel : ItemModel, IItemStats
{
    
    public int Strength { get; set; } = 10;
    public int Defence => 0;
    public int Agility => 0;
    public int Intelligence => 0;
    public override SlotType SlotType => SlotType.Weapon;
}