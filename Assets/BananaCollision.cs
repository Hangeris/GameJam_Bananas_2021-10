using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BananaCollision : MonoBehaviour
{
    [SerializeField] private List<GameObject> particleSystems;
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.rigidbody.AddForce(-other.contacts[0].normal * 100f, ForceMode.Force);
            Instantiate(particleSystems[Random.Range(0, particleSystems.Count)], other.contacts[0].point, Quaternion.identity);
        }
    }
}
