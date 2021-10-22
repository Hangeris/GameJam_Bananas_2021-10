using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public void BTN_TestDie()
    {
        Transition.Fade(1, () => SceneManager.LoadScene((int)SceneName.MenuScene), null);
    }
    
}
