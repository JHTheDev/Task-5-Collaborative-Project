using UnityEngine;
using System.Collections;

public class IndicatorLight : MonoBehaviour
{
    public Light indicatorLight;
    public KeyCode toggleKey = KeyCode.F;
    public float flashInterval = 0.5f;

    private bool isFlashing = false;
    private Coroutine flashRoutine;

    void Start()
    {
        indicatorLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            isFlashing = !isFlashing;

            if (isFlashing)
            {
                flashRoutine = StartCoroutine(FlashLight());
            }
            else
            {
                StopCoroutine(flashRoutine);
                indicatorLight.enabled = false;
            }
        }
    }

    IEnumerator FlashLight()
    {
        while (true)
        {
            indicatorLight.enabled = !indicatorLight.enabled;
            yield return new WaitForSeconds(flashInterval);
        }
    }
}