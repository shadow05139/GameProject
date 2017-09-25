using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {


    public Transform[] targetPositions;

    Vector3 currentPosition;
    int nextPosition;

    public float moveSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;

        transform.position = Vector3.MoveTowards(currentPosition, targetPositions[nextPosition].position, moveSpeed);

        if (currentPosition == targetPositions[nextPosition].position)
        {
            nextPosition++;
            if (nextPosition >= targetPositions.Length)
            {
                nextPosition = 0;
            }
        }
        

    }

}
