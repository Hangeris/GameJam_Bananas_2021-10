using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 1;
    private IMoveDirection moveDirection;

    private void Awake()
    {
        moveDirection = GetComponent<IMoveDirection>();
    }

    private void FixedUpdate()
    {
        var direction = moveDirection.FindDirection();
        rb.AddForce(moveSpeed * Time.fixedDeltaTime * direction);
    }
}
