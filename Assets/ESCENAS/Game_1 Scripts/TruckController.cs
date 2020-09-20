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
    [SerializeField] Rigidbody rb;
    [SerializeField] string axisX;
    [SerializeField] string axisY;
    
    bool startBrake = false;

    void Update()
    {
        if (InputManager.Instance.GetAxis(axisY) <= 0)
        {
            startBrake = true;
        }
        else if(InputManager.Instance.GetAxis(axisY) > 0)
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
                wheel.motorTorque = strenghCoefficient * Time.fixedDeltaTime * InputManager.Instance.GetAxis(axisY);
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
            wheel.steerAngle = maxTurn * InputManager.Instance.GetAxis(axisX);
        }
    }
}
