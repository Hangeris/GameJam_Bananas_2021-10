using UnityEngine;

public class ForceOnStart : MonoBehaviour
{
    [SerializeField] private float startingForce = 3;
    [SerializeField] private float randomAddForce = 5;
    [SerializeField] private float randomRotationDegrees = 0;
    private Rigidbody rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.Rotate(0f.Randomize(randomRotationDegrees), 0f.Randomize(randomRotationDegrees), 0);

        var force = transform.forward * startingForce.Randomize(randomAddForce, startingForce);
        rb.AddForce(force, ForceMode.Impulse);
    }
    
}
