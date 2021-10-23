using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Awake()
    {
        EventManager.ResetAllEvents();
    }

    public void BTN_StartGame()
    {
        Transition.Fade(
            1, 
            () => SceneManager.LoadScene((int)SceneName.GameScene, LoadSceneMode.Single), 
            () => EventManager.RequestGameStart());
    }

    public void BTN_ExitGame()
    {
        Application.Quit();
    }
}
