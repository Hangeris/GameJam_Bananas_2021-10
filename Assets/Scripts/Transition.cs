using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Transition : MonoBehaviour
{
    public static bool InTransition { get; private set; } = false;
    private static Transition instance;

    [SerializeField] private Image overlayImage;
    
    private void Awake()
    {
        CreateSoftInstance();
        
        overlayImage.raycastTarget = false;
        overlayImage.color = Color.clear;
    }
    
    public static void Fade(float duration, Action afterFadeInAction = null, Action afterFadeOutAction = null)
    {
        if (InTransition)
        {
            Debug.LogError("Cannot DoTransition while another transition is still active. Aborting.");
            return;
        }

        var _overlayImage = instance.overlayImage;
        
        _overlayImage.raycastTarget = true;
        InTransition = true;

        LeanTween.color(_overlayImage.rectTransform, Color.black, duration / 2f).setOnComplete(() =>
        {
            afterFadeInAction?.Invoke();
            
            LeanTween.color(_overlayImage.rectTransform, Color.clear, duration / 2f).setOnComplete(() =>
            {
                InTransition = false;
                _overlayImage.raycastTarget = false;
                
                afterFadeOutAction?.Invoke();
            });
        });
    }
    
    private void CreateSoftInstance()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
}
