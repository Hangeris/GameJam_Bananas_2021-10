using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    [SerializeField] private AnimationCurve difficultyCurveOverTime;
    private GameTimer gameTimer;
    
    private void Start()
    {
        gameTimer = GetComponent<GameTimer>();
    }

    public float Current()
    {
        return difficultyCurveOverTime.Evaluate(gameTimer.GetTotalInGameTime());
    }
    
}
