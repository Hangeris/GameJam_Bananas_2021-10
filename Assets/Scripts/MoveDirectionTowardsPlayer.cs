using UnityEngine;

public class MoveDirectionTowardsPlayer : MonoBehaviour, IMoveDirection
{
    private Player player;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    public Vector3 FindDirection()
    {
        return (player.transform.position - transform.position).normalized;
    }
}
