using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class trafficLight : MonoBehaviour
{
    // Set the variables of gameobjects
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


    // Wait until the player tigger an invisible collider for the traffic light to start
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger") && !changing)
        {
            Console.WriteLine("triggeed");
            StartCoroutine(TrafficSequence());
        }
    }
    
    
    // An Ienumerator is essentially a method used to create coroutines.
    // This will enable another another function
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


    // AI was used for help
}


