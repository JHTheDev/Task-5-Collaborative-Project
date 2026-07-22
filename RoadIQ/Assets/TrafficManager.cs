/*using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    public GameObject trafficPrefab;

    public Transform[] spawnPoints;

    public int numberOfCars = 5;

    void Start()
    {
        for (int i = 0; i < numberOfCars; i++)
        {
            int randomSpawn =
                Random.Range(
                    0,
                    spawnPoints.Length);

            Instantiate(
                trafficPrefab,
                spawnPoints[randomSpawn].position,
                spawnPoints[randomSpawn].rotation);
        }
    }
}*/