using AvaloniaRPG.Interfaces;
using AvaloniaRPG.Models;

namespace AvaloniaRPG.Services;

public class FightService : IFightService
{
    // Player
    public int CalculatePlayerAttack(CharacterModel character)
    {
        var attack = character.Strength + character.Dexterity + character.Intelligence;
        return attack;
    }

    public int CalculatePlayerDmgTaken(CharacterModel character, int enemyAttack)
    {
        var dmgTaken = enemyAttack - character.Defence;
        return dmgTaken;
    }

    
    // Enemy
    public int CalculateEnemyAttack(EnemyModel enemy)
    {
        return enemy.Attack;
    }

    public int CalculateEnemyDmgTaken(EnemyModel enemy, int playerAttack)
    {
        var dmgTaken = playerAttack - enemy.Defence;
        return  dmgTaken;
    }
}