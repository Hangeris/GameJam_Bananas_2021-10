using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<EnemySpawner> enemySpawners = null;
    
    [SerializeField] private AnimationCurve spawnProbabilityByDifficultyCurve;
    [SerializeField] private AnimationCurve spawnFrequencyByDifficultyCurve;
    
    private GameTimer gameTimer;
    private Difficulty difficulty;
    
    private void OnEnable()
    {
        EventManager.OnGameStart += OnGameStart;
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= OnGameStart;
    }
    private void Awake()
    {
        gameTimer = GetComponent<GameTimer>();
        difficulty = GetComponent<Difficulty>();
    }

    private void OnGameStart()
    {
        StopAllCoroutines();
        StartCoroutine(EnemySpawnRoutine());
    }

    IEnumerator EnemySpawnRoutine()
    {
        while (true)
        {
            float currentTime = gameTimer.GetTotalInGameTime();
            float currentDifficulty = difficulty.Current();
            float frequency = spawnFrequencyByDifficultyCurve.Evaluate(currentDifficulty);
            yield return new WaitForSeconds(1f/frequency);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        var randomSpawner = enemySpawners.GetRandom();
        randomSpawner.Spawn();
    }
    
}
