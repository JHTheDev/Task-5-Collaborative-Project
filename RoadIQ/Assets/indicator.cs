using UnityEngine;
using System.Collections;

public class IndicatorLight : MonoBehaviour
{
    public Light rightindicatorLight;
    public Light leftindicatorLight;
    public KeyCode LIndicatortoggleKey = KeyCode.J;
    public KeyCode RIndicatortoggleKey = KeyCode.K;
    public float flashInterval = 0.5f;

    private bool isFlashing = false;
    private Coroutine flashRoutine;

    void Start()
    {
        rightindicatorLight.enabled = false;
        rightindicatorLight.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(RIndicatortoggleKey))
        {
            isFlashing = !isFlashing;

            if (isFlashing)
            {
                flashRoutine = StartCoroutine(FlashLight(rightindicatorLight));
            }
            else
            {
                StopCoroutine(flashRoutine);
                rightindicatorLight.enabled = false;
            }
        }

        else if (Input.GetKeyDown(LIndicatortoggleKey))
        {
            isFlashing = !isFlashing;

            if (isFlashing)
            {
                flashRoutine = StartCoroutine(FlashLight(leftindicatorLight));
            }
            else
            {
                StopCoroutine(flashRoutine);
                leftindicatorLight.enabled = false;
            }
            
        }
    }

    IEnumerator FlashLight(Light indicatorLight)
    {
        while (true)
        {

            indicatorLight.enabled = !indicatorLight.enabled;
            yield return new WaitForSeconds(flashInterval);
        }
    }
}