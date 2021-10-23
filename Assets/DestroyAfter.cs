using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
    [SerializeField] private float duration = 20;
    private Enemy enemy;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        Destroy(gameObject, duration);
    }

    private void OnDestroy()
    {
        EventManager.EnemyDestroyed(enemy);
    }
}
