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
            Health = 100,
            Attack = 25
        };
        return enemy;
    }

    public int EnemyAttack(int attack)
    {
        throw new System.NotImplementedException();
    }
}