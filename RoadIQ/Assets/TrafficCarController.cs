/*using UnityEngine;

public class TrafficCarController : MonoBehaviour
{
    public WaypointPath path;

    public float speed = 10f;
    public float turnSpeed = 5f;

    private int currentPoint = 0;

    void Update()
    {
        FollowPath();
    }    void FollowPath()
    {
        Transform target = path.points[currentPoint];

        // Move
        transform.position =
            Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime);

        // Rotate toward target

        if (direction != Vector3.zero)
        {
        Vector3 direction =
            (target.position - transform.position);
            Quaternion targetRotation =
                Quaternion.LookRotation(direction);

            transform.rotation =
                Quaternion.Lerp(
                    transform.rotation,
                    targetRotation,
                    turnSpeed * Time.deltaTime);
        }

        // Reach point
        if (Vector3.Distance(
            transform.position,
            target.position) < 2f)
        {
            currentPoint++;

            if (currentPoint >= path.points.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
*/