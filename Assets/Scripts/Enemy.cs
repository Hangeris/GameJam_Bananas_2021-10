using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float moveSpeed = 10;
    private IMoveDirection moveDirection;

    private void Awake()
    {
        moveDirection = GetComponent<IMoveDirection>();
    }

    private void Start()
    {
        // TODO: force on start
        // TODO: rotation on start
    }

    private void FixedUpdate()
    {
        // TODO: force towards player
        // force towards local
        // force towards world
        
        if (moveDirection == null)
        {
            return;
        }
        
        var direction = moveDirection.FindDirection();
        rb.AddForce(moveSpeed * Time.fixedDeltaTime * direction);
    }
}
