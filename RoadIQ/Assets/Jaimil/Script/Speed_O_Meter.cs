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
    public float speedKPH;

    void Update()
    {

        // Calculate speed
        currentSpeed = carRb.velocity.magnitude;

        if (showKPH)
        {
            speedKPH = currentSpeed * speedmultiplyer;
            speedText.text = Mathf.RoundToInt(speedKPH) + " km/h";
        }
      
    }
}