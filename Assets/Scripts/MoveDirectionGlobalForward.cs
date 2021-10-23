using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirectionGlobalForward : MonoBehaviour, IMoveDirection
{
    public Vector3 FindDirection()
    {
        return GameController.EnemyMoveDirection.normalized;
    }
}
