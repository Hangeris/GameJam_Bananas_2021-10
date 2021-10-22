using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField]
    private float groundMoveSpeed = 10f;
    [SerializeField]
    private float chunkResetPointOffset;
    [SerializeField]
    private GameObject[] groundChunks;
    [SerializeField]
    private GameObject player;

    private float chunkResetPoint;

    // Start is called before the first frame update
    void Start()
    {
        chunkResetPoint = player.transform.position.z - groundChunks[0].transform.localScale.z / 2 - chunkResetPointOffset;
    }

    // Update is called once per frame
    void Update()
    {
        MoveGround();

    }

    private void MoveGround()
    {
        for (int i = 0; i < groundChunks.Length; i++)
        {
            if(groundChunks[i].transform.position.z <= chunkResetPoint)
            {
                ResetChunk(groundChunks[i].transform);
            }
            else
            {
                MoveChunk(groundChunks[i].transform);
            }
        }
    }

    private void ResetChunk(Transform chunk)
    {
        Vector3 newPos = chunk.position;
        newPos.z += chunk.localScale.z * groundChunks.Length;
        chunk.position = newPos;
    }

    private void MoveChunk(Transform chunk)
    {
        float movement = groundMoveSpeed * Time.deltaTime;
        Vector3 newPos = chunk.position;
        newPos.z -= movement;
        chunk.position = newPos;
    }
}
