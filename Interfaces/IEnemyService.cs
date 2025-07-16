using AvaloniaRPG.Models;

namespace AvaloniaRPG.Interfaces;

public interface IEnemyService
{
    public EnemyModel GetEnemy();
    public int EnemyAttack(int attack);
}