using System.Collections.Generic;

public class EnemyManager : Singleton<EnemyManager>
{
    private List<Enemy> _enemies;

    public int Count
    {
        get => _enemies.Count;
    }

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        _enemies = new List<Enemy>();
    }

    public void AddEnemy(Enemy enemy)
    {
        _enemies.Add(enemy);
    }

    public void RemoveEnemy(Enemy enemy)
    {
        _enemies.Remove(enemy);
    }
    
}
