using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDirectionTransformForward : MonoBehaviour, IMoveDirection
{
    public Vector3 FindDirection()
    {
        return transform.forward.normalized;
    }
}
