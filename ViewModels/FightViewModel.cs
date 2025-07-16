using System.Runtime.Serialization;
using AvaloniaRPG.Data;
using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.ViewModels;

public partial class FightViewModel : PageViewModel
{
    private readonly IEnemyService _enemyService;

    [ObservableProperty]
    private EnemyModel _enemy;
    public FightViewModel(IEnemyService enemyService)
    {
        PageName = ApplicationPageNames.Fight;
        _enemyService = enemyService;
        _enemy = GetEnemy();
    }

    private EnemyModel GetEnemy()
    {
        var enemy = _enemyService.GetEnemy();
        return enemy;
    }
}