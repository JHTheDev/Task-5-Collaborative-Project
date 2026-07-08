using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedLimit : MonoBehaviour
{
    [Header("Car")]
    public Rigidbody carRb;

    [Header("Speed Limit")]
    public float speedLimit = 50f; // km/h

    [Header("Game Over")]
    public string gameOverSceneName = "GameOver";

    private bool playerInsideZone = false;

    private void Update()
    {
        if (!playerInsideZone || carRb == null)
            return;

        float speedKPH = carRb.velocity.magnitude * 3.6f;

        if (speedKPH > speedLimit)
        {
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideZone = false;
        }
    }
}