using AvaloniaRPG.Models;

namespace AvaloniaRPG.Interfaces;

public interface IFightService
{
    // Player
    int CalculatePlayerAttack(CharacterModel character);
    int CalculatePlayerDmgTaken(CharacterModel character, int enemyAttack);
    
    // Enemy
    int CalculateEnemyAttack(EnemyModel enemy);
    int CalculateEnemyDmgTaken(EnemyModel enemy, int playerAttack);
}