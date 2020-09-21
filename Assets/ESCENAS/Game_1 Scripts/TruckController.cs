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
    PlayerScript player;
    
    bool startBrake = false;
    private void Start()
    {
        player = GetComponent<PlayerScript>();
    }

    void Update()
    {
        if (player.state == PlayerScript.State.Delivering)
            return;

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
            if (!startBrake && player.state == PlayerScript.State.Driving)
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
