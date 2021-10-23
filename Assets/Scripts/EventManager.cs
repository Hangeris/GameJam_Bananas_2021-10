using System;

public static class EventManager
{
    public static event Action OnGameStart = null;
    public static event Action<Enemy> OnEnemyDestroyed = null;

    public static void ResetAllEvents()
    {
        OnGameStart = null;
        OnEnemyDestroyed = null;
    }

    public static void RequestGameStart() => OnGameStart?.Invoke();
    public static void EnemyDestroyed(Enemy enemy) => OnEnemyDestroyed?.Invoke(enemy);

}
