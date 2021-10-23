using UnityEngine;

public class RotateTowardsVelocity : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 5;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        if (rb.velocity.magnitude <= 0)
        {
            return;
        }
        
        var targetRotation = Quaternion.LookRotation(rb.velocity.normalized, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed);
    }
}
