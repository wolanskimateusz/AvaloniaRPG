using System.Diagnostics;
using System.Runtime.Serialization;
using AvaloniaRPG.Data;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaRPG.ViewModels;

public partial class FightViewModel : PageViewModel
{
    private readonly IEnemyService _enemyService;
    private readonly ICharacterService _characterService;
    private readonly IFightService _fightService;

    [ObservableProperty]
    private EnemyModel _enemy;
    
    [ObservableProperty]
    private CharacterModel _character;

    [ObservableProperty]
    private bool _isLogExpanded = true;

    [ObservableProperty] 
    private string _enemyHpDisplay;
    
    [ObservableProperty]
    private string _characterHpDisplay;
    public FightViewModel(IEnemyService enemyService,  ICharacterService characterService, IFightService fightService)
    {
        PageName = ApplicationPageNames.Fight;
        
        _enemyService = enemyService;
        _characterService = characterService;
        _fightService = fightService;
        
        _enemy = GetEnemy();
        Debug.WriteLine("Przed załadowaniem");
        _character = GetCharacter();
        Debug.WriteLine("Po załadowaniu");
        // tymczasowe pokazywanie hp
        EnemyHpDisplay = SetCurrentEnemyHpDisplay();
        CharacterHpDisplay = SetCurrentCharacterHpDisplay();
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

    private string SetCurrentEnemyHpDisplay()
    {
        var hp = $"{Enemy.CurrentHp} / {Enemy.MaxHp}";
        return hp;
    }
    
    private string SetCurrentCharacterHpDisplay()
    {
        var hp = $"{Character.CurrentHp} / {Character.MaxHp}";
        return hp;
    }
    
    [RelayCommand]
    private void PlayerAttack()
    {
        Debug.WriteLine("Rozpoczecie Ataku");
        var playerDmg = _fightService.CalculatePlayerAttack(Character);
        Debug.WriteLine($"Gracz atakuje za " + playerDmg);
        var dmgTaken = _fightService.CalculateEnemyDmgTaken(Enemy, playerDmg);
        Debug.WriteLine($"Enemy Otrzymuje " + dmgTaken);
        Enemy.CurrentHp -= dmgTaken;
        Debug.WriteLine($"Enemy Hp " + Enemy.CurrentHp);
        EnemyHpDisplay = SetCurrentEnemyHpDisplay();
    }
}