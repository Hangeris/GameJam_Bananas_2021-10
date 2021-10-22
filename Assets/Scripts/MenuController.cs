using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
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
