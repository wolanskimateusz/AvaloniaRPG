namespace AvaloniaRPG.Models;

public class EnemyModel
{
    public string Name { get; set; } = "Enemy1";
    public int CurrentHp { get; set; } = 100;
    public int MaxHp { get; set; } = 100;
    public int Attack { get; set; } = 20;
    
    public int Defence { get; set; } = 20;

}