using UnityEngine;

public class WaypointPath : MonoBehaviour
{
    public Transform[] points;

    void Awake()
    {
        points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}