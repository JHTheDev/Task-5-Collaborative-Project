using UnityEngine;
using System;
using System.Collections.Generic;
using TMPro;

public class CarController : MonoBehaviour
{
    public enum ControlMode
    {
        Keyboard,
        Buttons
    };

    public enum Axel
    {
        Front,
        Rear
    }

    // NEW: Gear modes
    public enum GearState
    {
        Park,
        Reverse,
        Neutral,
        Drive
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelModel;
        public WheelCollider wheelCollider;
        public GameObject wheelEffectObj;
        public ParticleSystem smokeParticle;
        public Axel axel;
    }

    public ControlMode control;

    [Header("Movement")]
    public float maxAcceleration = 30f;
    public float turnSensitivity = 1f;
    public float maxSteerAngle = 30f;
    public int maxSpeed = 40;

    [Header("Gearbox")]
    public GearState currentGear = GearState.Park;

    public int currentDriveGear = 1;
    public int maxDriveGear = 5;

    // Torque multiplier for each gear
    public float[] gearRatios =
    {
        3.5f, // Gear 1
        2.8f, // Gear 2
        2.0f, // Gear 3
        1.5f, // Gear 4
        1.0f  // Gear 5
    };

    [Header("Physics")]
    public Vector3 _centerOfMass;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    public float score = 0;
    public TextMeshProUGUI ScoreText;

    private Rigidbody carRb;

    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carRb.centerOfMass = _centerOfMass;
        carRb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    void FixedUpdate()
    {
        
        

        
        Steer();
        AnimateWheels();
    }
    private void Update()
    {
        GearInput();
        GetInputs();
        Move();
    }
    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    // ---------------- GEAR INPUT ----------------

    void GearInput()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            currentGear = GearState.Park;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            currentGear = GearState.Reverse;
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            currentGear = GearState.Neutral;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            currentGear = GearState.Drive;
        }
    }

    // ---------------- AUTOMATIC SHIFTING ----------------

    /*void UpdateAutomaticGearbox()
    {
        float speed = carRb.velocity.magnitude;

        if (speed > 30 && currentDriveGear < 5)
            currentDriveGear = 5;

        else if (speed > 24 && currentDriveGear < 4)
            currentDriveGear = 4;

        else if (speed > 18 && currentDriveGear < 3)
            currentDriveGear = 3;

        else if (speed > 10 && currentDriveGear < 2)
            currentDriveGear = 2;

        else
            currentDriveGear = 1;
    }*/

    // ---------------- SPEED LIMIT ----------------

   /* void MaxSpeed()
    {
        if (carRb.velocity.magnitude > maxSpeed)
        {
            carRb.velocity =
                carRb.velocity.normalized * maxSpeed;
        }
    }*/

    // ---------------- MOVE ----------------

    void Move()
    {
        //MaxSpeed();

        float torque = 0;

        switch (currentGear)
        {
            case GearState.Park:

                // lock wheels
                foreach (var wheel in wheels)
                {
                    wheel.wheelCollider.brakeTorque = 5000;
                    wheel.wheelCollider.motorTorque = 0;
                   
                }
                return;

            case GearState.Neutral:

                torque = 0;
                break;

            case GearState.Reverse:

                if (moveInput <= 0)
                {
                    torque = 600 * maxAcceleration * moveInput;
                }
                
                break;

            case GearState.Drive:

                //UpdateAutomaticGearbox();

                /*foreach (var wheel in wheels)
                {
                    wheel.wheelCollider.motorTorque = 600 * maxAcceleration * moveInput * Time.fixedDeltaTime;

                }*/
                torque =
                    600 *
                    maxAcceleration *
                    moveInput;

                break;
        }

        

        foreach (var wheel in wheels)
        {
            if (Input.GetKey(KeyCode.Space))
            {

                wheel.wheelCollider.brakeTorque = 3000;
                wheel.wheelCollider.motorTorque = 0;
            }

            wheel.wheelCollider.brakeTorque = 0;
            
            
            wheel.wheelCollider.motorTorque =
                torque * Time.fixedDeltaTime;
        }
    }

    // ---------------- STEERING ----------------

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.axel == Axel.Front)
            {
                float steerAngle =
                    steerInput *
                    turnSensitivity *
                    maxSteerAngle;

                wheel.wheelCollider.steerAngle =
                    Mathf.Lerp(
                        wheel.wheelCollider.steerAngle,
                        steerAngle,
                        0.6f);
            }
        }
    }

    // ---------------- WHEEL ANIMATION ----------------

    void AnimateWheels()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;

            wheel.wheelCollider.GetWorldPose(
                out pos,
                out rot);

            wheel.wheelModel.transform.position = pos;
            wheel.wheelModel.transform.rotation = rot;
        }
    }

    // ---------------- SCORE ----------------

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            score++;

            ScoreText.text = score.ToString();

            other.gameObject.SetActive(false);
        }
    }
}