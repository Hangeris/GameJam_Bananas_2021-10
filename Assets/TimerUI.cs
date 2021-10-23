using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    private GameTimer gameTimer;
    
    private void Awake()
    {
        gameTimer = FindObjectOfType<GameTimer>();
    }

    private void Update()
    {
        float allSeconds = gameTimer.GetTotalInGameTime();
        int minutes = (int)allSeconds / 60;
        int seconds = (int)allSeconds - ((int)minutes * 60);
        
        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
