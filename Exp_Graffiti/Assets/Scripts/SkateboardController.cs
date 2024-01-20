using System.Collections;
using System.Collections.Generic;
using System.IO;
using GridSystem;
using UnityEngine;

public class SkateboardController : MonoBehaviour
{
    [Header("Wheels")]
    [SerializeField]
    private WheelCollider leftFront;
    [SerializeField]
    private WheelCollider rightFront;
    [SerializeField]
    private WheelCollider leftBack;
    [SerializeField]
    private WheelCollider rightBack;
    
    [Header("Movement")]
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float breakingForce;
    [SerializeField]
    private float maxTurnAngle;

    [Header("Trail")]
    [SerializeField]
    private GameObject tail;
    [SerializeField]
    private GameObject trailPrefab;
    [SerializeField]
    private float trailGenerateCD = 1;
    private bool canGenerateTrail = true;
    private float trailTimer = 0;

    [Header("Paint")]
    [SerializeField]
    private Color testColor1;
    [SerializeField]
    private GridGenerator gridGenerator;
    private Color currentColor;


    
    private float currentAcceleration = 0f;
    private float currentBreakingForce = 0f;
    private float currentTurnAngle = 0f;



    // Start is called before the first frame update
    void Start()
    {
        currentColor = testColor1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            this.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0);
        }
    }

    private void FixedUpdate() 
    {
        //handle forward/backward
        currentAcceleration = acceleration * Input.GetAxis("Vertical");
        
        //handle break
        
        if(Input.GetKey(KeyCode.Space))
        {
            currentBreakingForce = breakingForce;
            if(gridGenerator != null)
            {
                gridGenerator.UpdateGridColor(transform.position, currentColor);
            }
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

        // if(currentAcceleration >= 0.1f || currentTurnAngle >= 0.1f ||
        //    currentAcceleration <= -0.1f || currentTurnAngle <= -0.1f)
        // {
        //     if(canGenerateTrail)
        //     {
        //         //GenerateTrails();
        //     }
        // }

        // trailTimer += 0.1f;
        // if(trailTimer > trailGenerateCD)
        // {
        //     canGenerateTrail = true;
        //     trailTimer = 0;
        // }
    }

    private void GenerateTrails()
    {
        if(trailPrefab == null) { return; }
        Vector3 trailPosition = tail.transform.position;
        trailPosition.y = -0.001f;
        GameObject trail = Instantiate(trailPrefab, trailPosition, Quaternion.identity);
        trail.transform.SetParent(null);
        canGenerateTrail = false;
    }

    public void ChangeColor(Color colorToChange)
    {
        currentColor = colorToChange;
    }
}
