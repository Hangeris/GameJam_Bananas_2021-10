using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinRandom : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1;
    private Vector3 randomVectorRotation;
    
    private void Start()
    {
        randomVectorRotation = new Vector3(0f.Randomize(128), 0f.Randomize(128), 0f.Randomize(128));
        randomVectorRotation.Normalize();
        randomVectorRotation *= 10f.Randomize(10f, 10);
    }

    private void Update()
    {
        transform.Rotate(randomVectorRotation * rotationSpeed * Time.deltaTime);
    }
}
