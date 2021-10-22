using System;

public static class EventManager
{
    public static event Action OnGameStart = null;

    public static void ResetAllEvents()
    {
        OnGameStart = null;
    }

    public static void RequestGameStart() => OnGameStart?.Invoke();

}
