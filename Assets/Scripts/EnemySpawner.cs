using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> spawnableEnemies = null;
    private List<Enemy> spawnedEnemies = null;

    private void OnEnable()
    {
        EventManager.OnEnemyDestroyed += OnEnemyDestroyed;
    }
    private void OnDisable()
    {
        EventManager.OnEnemyDestroyed -= OnEnemyDestroyed;
    }
    private void Start()
    {
        spawnedEnemies = new List<Enemy>();
    }
    
    public void Spawn()
    {
        if (spawnableEnemies == null)
        {
            return;
        }

        Enemy randomEnemy = Instantiate(spawnableEnemies.GetRandom(), transform.position, transform.rotation, transform);
        spawnedEnemies.Add(randomEnemy);
    }
    
    private void OnEnemyDestroyed(Enemy enemy)
    {
        spawnedEnemies.Remove(enemy);
    }

    
}
