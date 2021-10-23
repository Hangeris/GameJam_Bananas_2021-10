using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartScaleUp : MonoBehaviour
{
    private Vector3 targetScale;
    [SerializeField] private float scaleAmount = 1f;
    [SerializeField] private float randomAdditionalScale = 0f;
    [SerializeField] private float scaleUpDuration = 1;
    [SerializeField] private List<LeanTweenType> easeTypes = new List<LeanTweenType>() {LeanTweenType.easeOutCubic, LeanTweenType.easeOutElastic, LeanTweenType.easeOutBounce};

    void Start()
    {
        targetScale = scaleAmount.Randomize(randomAdditionalScale, scaleAmount) * Vector3.one; 
        transform.localScale = Vector3.one * 0.01f;
        LeanTween.scale(gameObject, targetScale, scaleUpDuration).setEase(easeTypes.GetRandom());
    }

}
