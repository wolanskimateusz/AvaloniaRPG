using AvaloniaRPG.Models;

namespace AvaloniaRPG.Interfaces;

public interface ICharacterService
{
    CharacterModel GetCharacter();
    void SaveCharacter(CharacterModel character);  
}