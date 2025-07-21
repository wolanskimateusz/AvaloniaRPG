using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using AvaloniaRPG.Models.Items;
using AvaloniaRPG.ViewModels.Inventory;

namespace AvaloniaRPG.Services;

public class FileCharacterService : ICharacterService
{
    private readonly string _filePath = "characters.json";
    

    public CharacterModel GetCharacter()
    {
        if(!File.Exists(_filePath)) return new CharacterModel();
        
        var json =  File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<CharacterModel>(json) ??  new CharacterModel();

    }
    
    public void SaveCharacter(CharacterModel character)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        
        var json = JsonSerializer.Serialize(character, options);
        try
        {
            File.WriteAllText(_filePath, json);
            Debug.WriteLine($"File saved to {_filePath}");
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving file: {ex.Message}");
        }
    }

    public CharacterModel GetCharacterBaseStats()
    {
        return GetCharacter();
    }
    

    public void UpdateCharacterStats(CharacterModel character ,ObservableCollection<ItemSlot> equipmentSlots)
    {
        var characterBase = GetCharacterBaseStats();
        character.Strength = characterBase.Strength;
        Debug.WriteLine($"Base strength: {characterBase.Strength}");
        
        foreach (var slot in equipmentSlots)
        {
            if (slot.Item is IItemStats itemStats)
            {
                character.Strength += itemStats.Strength;
            }
        }
        Debug.WriteLine($"new strength: {character.Strength}");
    }
}