/*using System.IO;
using UnityEngine;

public Transform detectionPoint;
public float detectionDistance = 7f;

void FollowPath()
{
    bool obstacle = Physics.Raycast(
        detectionPoint.position,
        detectionPoint.forward,
        detectionDistance);

    float currentSpeed = speed;

    if (obstacle)
    {
        currentSpeed = 0;
    }

    Transform target = path.points[currentPoint];

    transform.position =
        Vector3.MoveTowards(
            transform.position,
            target.position,
            currentSpeed * Time.deltaTime);

}*/