using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartScaleUp : MonoBehaviour
{
    private Vector3 defaultScale;
    [SerializeField] private float scaleUpDuration = 1;
    [SerializeField] private List<LeanTweenType> easeTypes;

    void Start()
    {
        defaultScale = transform.localScale; 
        transform.localScale = Vector3.one * 0.01f;
        LeanTween.scale(gameObject, defaultScale, scaleUpDuration).setEase(easeTypes.GetRandom());
    }

}
