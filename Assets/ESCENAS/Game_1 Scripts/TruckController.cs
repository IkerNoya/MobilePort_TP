using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckController : MonoBehaviour
{
    [SerializeField] List<WheelCollider> throttleWheels;
    [SerializeField] List<WheelCollider> steeringWheels;
    [SerializeField] float strenghCoefficient;
    [SerializeField] float brakeStrengh;
    [SerializeField] float maxTurn;
    [SerializeField] Transform centerMass;
    [SerializeField] Rigidbody rb;
    bool startBrake = false;
    void Start()
    {
        if(centerMass!=null)
            rb.centerOfMass = centerMass.position;
    }

    void Update()
    {
        if (InputManager.Instance.GetAxis("Vertical") <= 0)
        {
            startBrake = true;
        }
        else if(InputManager.Instance.GetAxis("Vertical") > 0)
        {
            startBrake = false;
        }
    }
    void FixedUpdate()
    {
        foreach(WheelCollider wheel in throttleWheels)
        {
            if (!startBrake)
            {
                wheel.motorTorque = strenghCoefficient * Time.deltaTime * InputManager.Instance.GetAxis("Vertical");
                wheel.brakeTorque = 0f;
            }
            else
            {
                wheel.motorTorque = 0f;
                wheel.brakeTorque = brakeStrengh;
            }
        }
        foreach(WheelCollider wheel in steeringWheels)
        {
            wheel.steerAngle = maxTurn * InputManager.Instance.GetAxis("Horizontal");
        }
    }
}
