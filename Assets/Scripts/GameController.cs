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

    IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
        EventManager.RequestGameStart();
    }
    
    private void OnGameStart()
    {
        
    }
    
    
}
