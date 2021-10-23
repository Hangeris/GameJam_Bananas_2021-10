using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private float totalInGameTime;
    
    private void OnEnable()
    {
        EventManager.OnGameStart += OnGameStart;
        EventManager.OnPlayerDie += OnPlayerDie;
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= OnGameStart;
        EventManager.OnPlayerDie -= OnPlayerDie;
    }

    public float GetTotalInGameTime()
    {
        return totalInGameTime;
    }
    
    private void OnGameStart()
    {
        StartCoroutine(IncreaseDifficultyRoutine());
    }
    
    private void OnPlayerDie()
    {
        StopAllCoroutines();
    }
    
    IEnumerator IncreaseDifficultyRoutine()
    {
        while (true)
        {
            yield return null;
            totalInGameTime += Time.deltaTime;
        }
    }
    
}
