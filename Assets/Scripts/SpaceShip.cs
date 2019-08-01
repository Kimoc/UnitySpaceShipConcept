//Copyright 2019, Aaron Gutierrez, All rights reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



/*todo
    Adjust forces and controls to get a smoother flight experience


 */

public class SpaceShip : MonoBehaviour
{

    PlayerControls shipControls;            //New unity InputSystem =====V: 0.9.0
    Rigidbody shipRB;                       //To apply Physics on the ship
    public float thrust;                    //force we add to the ship
    public float rotationSpeed;             //the speed in wich the ship can rotate                                     
    static bool IsAccelerating;             //Bool to check if the ship is accelerating
    public float MAX_VELOCITY;              //Max velocity to control speed of the ship
    private float currenVelocity;           //The curent velocity of the Rigidbody from Ship
    public Vector2 rotate;                  //Rotation value (yaw == y axis  pitch == x axis) 
    public float roll;                      //Value aplyed to the rotation on the x axis of the ship
    public bool isRotatingLeft;             //Bool to chek if the ship is rotating left on the z axis
    public bool isRotatinRight;             //Bool to chek if the ship is rotating right on the z axis            
    //Starts Before Start 
    private void Awake()
    {  //CONSTANTS
        MAX_VELOCITY = 0.5f;
        //We initzialize the new PlayerControls from the new Unity Input System
        shipControls = new PlayerControls();       

        //We call the Gameplay(Action Map) and and link each button to a function
        // "call action from action map" "+=" "ctx(Context)" "=>" perform Function  
        //For more info lookup Lambda Expresions
        //SHIP ACCELERATION DECELERATION ==> R2 button
        shipControls.GamePlay.Accelerate.performed += pressingDownAccelerate => Accelerate();
        shipControls.GamePlay.Accelerate.canceled += pressingDownAccelerate => Decelerate();
        //SHIP PITCH AND YAW ==> Left stick
        shipControls.GamePlay.RotateShip.performed += rotatingShip => rotate= rotatingShip.ReadValue<Vector2>();
        shipControls.GamePlay.RotateShip.canceled += rotatingShip => rotate =Vector2.zero;
        //ShHIP ROTATION lEFT==> L1
        shipControls.GamePlay.RotateLeft.performed += rollLeft => RollLeft();
        shipControls.GamePlay.RotateLeft.canceled += rollLeft =>isRotatingLeft=false;
        //SHIP ROTATION RIGHT ==> R1
        shipControls.GamePlay.RotateRight.performed += rollRight => RollRight();
        shipControls.GamePlay.RotateRight.canceled += rollRight => isRotatinRight = false;

    }
    
    private void Start()
    {

        //INITZIALIZING VARIABLES
        shipRB =transform.GetComponent<Rigidbody>();
        thrust = 5f;
        rotationSpeed = 100f;
        IsAccelerating = false; 
        currenVelocity = shipRB.velocity.z;
        roll = 100f;
    }
 
    private void FixedUpdate() //Fixed update because we are using physics
    {
        //ACCELERATION AND VELOCITY CHECK
        currenVelocity = shipRB.velocity.z;
        if (IsAccelerating)
        {
            shipRB.AddForce(transform.forward * thrust * Time.deltaTime);
        }
        if (currenVelocity > MAX_VELOCITY)
        {
            shipRB.AddForce(transform.forward * thrust * Time.deltaTime*-1);
            Debug.Log("Max velocidad alcanzada");
        }
        //PITCH YAW
        Vector2 rotation = new Vector2(rotate.y, rotate.x)*rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.World);
        //ROLL
        if (isRotatingLeft)
        {
            Vector3 rolling = new Vector3(0f,0f, rotationSpeed * Time.deltaTime);
            transform.Rotate(rolling,Space.World);
        }
        if (isRotatinRight)
        {
            Vector3 rolling = new Vector3(0f, 0f, rotationSpeed * -1 * Time.deltaTime);
            transform.Rotate(rolling, Space.World);
        }
    }

    void RollLeft() 
    {
        isRotatingLeft=true;
        
    }
    void RollRight()
    {
        isRotatinRight=true;
    }
    void Accelerate()
    {
        IsAccelerating = true;
    }
    void Decelerate()
    {
        IsAccelerating = false;
    }
    void OnEnable()
    {
        shipControls.GamePlay.Enable();
    }
    private void OnDisable()
    {
        shipControls.GamePlay.Disable();
    }
}
