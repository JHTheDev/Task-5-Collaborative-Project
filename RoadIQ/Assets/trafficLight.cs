using System.Collections;
using UnityEngine;

public class trafficLight : MonoBehaviour
{

    public GameObject redLight;
    public GameObject yellowLight;
    public GameObject greenLight;

    public float yellowTime = 2f;
    public float redTime = 5f;

    private bool changing = false;

    void Start()
    {
        SetLights(false, false, true); // Green on
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !changing)
        {
            StartCoroutine(TrafficSequence());
        }
    }
    
    
    IEnumerator TrafficSequence()
    {
        changing = true;

        // Green → Yellow
        SetLights(false, true, false);
        yield return new WaitForSeconds(yellowTime);

        // Yellow → Red
        SetLights(true, false, false);
        yield return new WaitForSeconds(redTime);

        // Red → Yellow
        SetLights(false, true, false);
        yield return new WaitForSeconds(yellowTime);

        // Yellow → Green
        SetLights(false, false, true);

        changing = false;
    }

    void SetLights(bool red, bool yellow, bool green)
    {
        redLight.SetActive(red);
        yellowLight.SetActive(yellow);
        greenLight.SetActive(green);
        
    }
}


