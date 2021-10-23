using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static Vector3 EnemyMoveDirection = -Vector3.forward;
    private float finishedGameTime;

    private float[] bestTimes = new float[] { 0, 0, 0 };

    private void OnEnable()
    {
        EventManager.OnGameStart += OnGameStart;
        EventManager.OnPlayerDie += BTN_TestDie;
    }
    private void OnDisable()
    {
        EventManager.OnGameStart -= OnGameStart;
        EventManager.OnPlayerDie -= BTN_TestDie;
    }

    public void BTN_TestDie()
    {
        finishedGameTime = FindObjectOfType<GameTimer>().GetTotalInGameTime();
        SceneManager.sceneLoaded += ShowTime;
        Transition.Fade(1, () => SceneManager.LoadScene((int)SceneName.GameOverScene), null);
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(.5f);
    }
    
    private void OnGameStart()
    {
        
    }

    private void ShowTime(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= ShowTime;
        TextMeshProUGUI gameOverUI = null;
        var TMPUIs = GameObject.FindObjectsOfType<TextMeshProUGUI>();
        foreach(var x in TMPUIs)
        {
            if(x.name == "EndText")
            {
                gameOverUI = x;
                break;
            }
        }
        
        gameOverUI.text = string.Format("Uh oh, looks like you went bananas\nYou survived for: {0:0.00} seconds", finishedGameTime);
        
 
    }
}
