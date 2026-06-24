using UnityEngine;
using TMPro;

public class Speedometer : MonoBehaviour
{
    [Header("References")]
    public Rigidbody carRb;
    public TextMeshProUGUI speedText;
    public float speedmultiplyer;

    [Header("Settings")]
    public bool showKPH = true;

    private float currentSpeed;

    void Update()
    {
        if (carRb == null || speedText == null)
            return;

        // Calculate speed
        currentSpeed = carRb.velocity.magnitude;

        if (showKPH)
        {
            float speedKPH = currentSpeed * speedmultiplyer;
            speedText.text = Mathf.RoundToInt(speedKPH) + " km/h";
        }
        else
        {
            float speedMPH = currentSpeed * 2.237f;
            speedText.text = Mathf.RoundToInt(speedMPH) + " mph";
        }
    }
}