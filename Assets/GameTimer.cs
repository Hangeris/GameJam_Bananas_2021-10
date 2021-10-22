using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.OnGameStart += OnGameStart;
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= OnGameStart;
    }

    private void OnGameStart()
    {
        Debug.Log("Game has been started.");
    }
}
