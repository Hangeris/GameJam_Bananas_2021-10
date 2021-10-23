using System;

public static class EventManager
{
    public static event Action OnGameStart = null;
    public static event Action OnPlayerDie = null;
    public static event Action<Enemy> OnEnemyDestroyed = null;

    public static void ResetAllEvents()
    {
        OnGameStart = null;
        OnEnemyDestroyed = null;
        OnPlayerDie = null;
    }

    public static void RequestGameStart() => OnGameStart?.Invoke();
    public static void PlayerDie() => OnPlayerDie?.Invoke();
    public static void EnemyDestroyed(Enemy enemy) => OnEnemyDestroyed?.Invoke(enemy);

}
