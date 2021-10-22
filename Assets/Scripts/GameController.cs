using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    private void OnEnable()
    {
        EventManager.OnGameStart += OnGameStart;
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= OnGameStart;
    }

    public void BTN_TestDie()
    {
        Transition.Fade(1, () => SceneManager.LoadScene((int)SceneName.MenuScene), null);
    }
    
    private void OnGameStart()
    {
        
    }
    
    
}
