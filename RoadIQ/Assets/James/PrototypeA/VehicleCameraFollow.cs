using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    [SerializeField] float smoothTime = 0.15f;
    private Vector3 velocity = Vector3.zero;


    [SerializeField] private Transform target;



    [SerializeField] private float rotationSpeed = 5f;
    public Vector3 rotationOffset = new Vector3(0f, 0f, -10f);

    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 targetPosition = target.position + offset;

        // Position follows target and rotates with it
        Vector3 targetPosition = target.position + target.rotation * offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        // Smoothly match target rotation
        Quaternion targetRotation = target.rotation;
        Quaternion desiredRotation = target.rotation * Quaternion.Euler(rotationOffset);

        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);


        

    }

    

    
   

        

}