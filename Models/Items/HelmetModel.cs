using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Models.Items;

public class HelmetModel : ItemModel, IItemStats
{
    private IItemStats _itemStatsImplementation;
    public int Strength => 0;

    public int Defence => 0;

    public int Intelligence { get; set; } =  10;
    
    public override SlotType SlotType => SlotType.Helmet;
}