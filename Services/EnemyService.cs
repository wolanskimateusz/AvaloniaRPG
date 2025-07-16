using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace AvaloniaRPG.Services;

public class EnemyService : IEnemyService
{
    public EnemyModel GetEnemy()
    {
        var enemy = new EnemyModel
        {
            Name = "Enemy2",
            CurrentHp = 100,
            MaxHp = 100,
            Attack = 25,
            Defence = 5
        };
        return enemy;
    }
    
}