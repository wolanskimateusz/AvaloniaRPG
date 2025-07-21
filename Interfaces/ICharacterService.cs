using System.Collections.ObjectModel;
using AvaloniaRPG.Models;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Interfaces;

public interface ICharacterService
{
    CharacterModel GetCharacter();
    void SaveCharacter(CharacterModel character);
    
    CharacterModel GetCharacterBaseStats();
    

    void UpdateCharacterStats(CharacterModel character, ObservableCollection<ItemSlot> equipmentSlots);
}