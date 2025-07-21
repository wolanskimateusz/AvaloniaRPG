using System.Collections.ObjectModel;
using AvaloniaRPG.Models;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Interfaces;

public interface ICharacterEqService
{
    CharacterModel Character { get; }
    ObservableCollection<ItemSlot> EquipmentSlots { get; }
    void LoadContext();
    void RefreshStats();
}