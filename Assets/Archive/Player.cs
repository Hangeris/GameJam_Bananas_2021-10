using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int health = 3;
    [SerializeField]
    private int maxHealth = 3;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float movementBounds;

    private float initialPosition;

    public UnityEvent<int> OnPlayerDamaged;

    private Animator anim;
    
    private static readonly int IsStrafing = Animator.StringToHash("IsStrafing");
    private static readonly int Direction = Animator.StringToHash("Direction");

    private void Start()
    {
        anim = GetComponent<Animator>();
        OnPlayerDamaged = new UnityEvent<int>();
        initialPosition = gameObject.transform.position.x;
        health = maxHealth;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        float input = Input.GetAxis("Horizontal");
        if (input != 0)
        {
            anim.SetBool(IsStrafing, true);
            anim.SetFloat(Direction, input);
            var newPos = gameObject.transform.position;
            newPos.x += input * movementSpeed * Time.deltaTime;
            if (newPos.x > initialPosition + movementBounds)
                newPos.x = initialPosition + movementBounds;
            else if (newPos.x < initialPosition - movementBounds)
                newPos.x = initialPosition - movementBounds;

            gameObject.transform.position = newPos;
        }
        else
        {
            anim.SetBool(IsStrafing, false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag($"Obstacle"))
        {
            DamagePlayer();
        }
    }

    private void DamagePlayer()
    {
        health--;
        OnPlayerDamaged.Invoke(health);
    }
}
