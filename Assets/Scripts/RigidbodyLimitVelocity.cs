using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyLimitVelocity : MonoBehaviour
{
    [SerializeField] private float maxVelocity = 5;
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }
    }
}
