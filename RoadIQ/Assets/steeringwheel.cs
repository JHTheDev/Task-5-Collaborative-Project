using UnityEngine;

public class SteeringWheel : MonoBehaviour
{
    [Header("Steering Settings")]
    public float maxRotation = 540f;      // 1.5 rotations each direction
    public float rotationSpeed = 720f;    // Degrees per second
    public float returnSpeed = 500f;      // Return-to-center speed

    private float currentRotation = 0f;

    void Update()
    {
        float steerInput = 0f;

        // A / Left Arrow
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            steerInput = -1f;

        // D / Right Arrow
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            steerInput = 1f;

        if (steerInput != 0f)
        {
            currentRotation += steerInput * rotationSpeed * Time.deltaTime;
            currentRotation = Mathf.Clamp(currentRotation, -maxRotation, maxRotation);
        }
        else
        {
            currentRotation = Mathf.MoveTowards(
                currentRotation,
                0f,
                returnSpeed * Time.deltaTime
            );
        }

        // Rotate wheel around local Z axis
        transform.localRotation = Quaternion.Euler(-currentRotation, -90f, 90f);
    }
}
