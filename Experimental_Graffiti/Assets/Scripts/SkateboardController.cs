using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    [SerializeField]
    private WheelCollider leftFront;
    [SerializeField]
    private WheelCollider rightFront;
    [SerializeField]
    private WheelCollider leftBack;
    [SerializeField]
    private WheelCollider rightBack;
    
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float breakingForce;
    [SerializeField]
    private float maxTurnAngle;
    
    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        //handle forward/backward
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        
        //handle break
        if(Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;
        }
        else
        {
            currentBreakingForce = 0;
        }

        //acceleration to front wheels
        rightFront.motorTorque = currentAcceleration;
        leftFront.motorTorque = currentAcceleration;

        //breaking force to all wheels
        rightFront.brakeTorque = currentBreakingForce;
        leftFront.brakeTorque = currentBreakingForce;
        rightBack.brakeTorque = currentBreakingForce;
        leftBack.brakeTorque = currentBreakingForce;

        //handle turn
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        leftFront.steerAngle = currentTurnAngle;
        rightFront.steerAngle = currentTurnAngle;

    }
}
