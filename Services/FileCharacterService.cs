using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;

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
}