using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> spawnableObjects = null;
    private List<GameObject> spawnedObjects = null;

    private void Start()
    {
        spawnableObjects = new List<GameObject>();
        spawnedObjects = new List<GameObject>();
    }

    public void Spawn()
    {
        
    }
    
}
