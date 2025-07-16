using System.Diagnostics;
using System.Runtime.Serialization;
using AvaloniaRPG.Data;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels;

public partial class FightViewModel : PageViewModel
{
    private readonly IEnemyService _enemyService;
    private readonly ICharacterService _characterService;

    [ObservableProperty]
    private EnemyModel _enemy;
    
    [ObservableProperty]
    private CharacterModel _character;

    [ObservableProperty]
    private bool _isLogExpanded = true;
    
    public string EnemyHpDisplay => $"{Enemy.CurrentHp} / {Enemy.MaxHp}";
    public string CharacterHpDisplay => $"{Character.CurrentHp} / {Character.MaxHp}";
    public FightViewModel(IEnemyService enemyService,  ICharacterService characterService)
    {
        PageName = ApplicationPageNames.Fight;
        
        _enemyService = enemyService;
        _characterService = characterService;
        _enemy = GetEnemy();
        Debug.WriteLine("Przed załadowaniem");
        _character = GetCharacter();
        Debug.WriteLine("Po załadowaniu");
    }

    private EnemyModel GetEnemy()
    {
        var enemy = _enemyService.GetEnemy();
        return enemy;
    }
    private CharacterModel GetCharacter()
    {
        var character = _characterService.GetCharacter();
        return character;
    }
}