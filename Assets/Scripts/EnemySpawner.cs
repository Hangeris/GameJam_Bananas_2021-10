using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> spawnableEnemies = null;
    private List<Enemy> spawnedEnemies = null;

    private void Start()
    {
        spawnedEnemies = new List<Enemy>();
    }

    [ContextMenu("Doo doo")]
    public void DooDoo()
    {
        Spawn();
    }
    
    public void Spawn()
    {
        if (spawnableEnemies == null)
        {
            return;
        }

        Enemy randomEnemy = Instantiate(spawnableEnemies.GetRandom(), transform.position, transform.rotation);

        spawnedEnemies.Add(randomEnemy);
    }
    
}
