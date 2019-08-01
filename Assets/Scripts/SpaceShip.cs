//Copyright 2019, Aaron Gutierrez, All rights reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



/*todo
    Adjust forces and controls to get a smoother flight experience


 */


//CLASS========================================================================
public class SpaceShip : MonoBehaviour
{

    PlayerControls shipControls;            //New unity InputSystem =====V: 0.9.0
    Rigidbody shipRB;                       //To apply Physics on the ship 
    public float MIN_VELOCITY;              //Min velocity to avoid reversed thrust backwards (its not a ferture of the Ship)
    public float defaultMaxSpeed;           //Max velocity to control speed of the ship
    public float thrustMultiplier;          //Is used to smooth control over ship when using the Y axis on left Stick(Gamepad)
    public float thrust;                    //force we add to the ship
    public float rotationSpeed;             //the speed in wich the ship can rotate                                     
    public bool IsAccelerating;             //Bool to check if the ship is accelerating
    public bool isDecelerating;             //Bool to check if the ship is decelerating
    public bool isRotating;                 //is changing Yaw or Pitch
    public bool isRollingLeft;              //Bool to chek if the ship is rolling left on the z axis
    public bool isRollingRight;             //Bool to chek if the ship is rolling right on the z axis      
    private float currenVelocity;           //The curent velocity of the Rigidbody from Ship
    public Vector2 rotate;                  //Rotation value (yaw == y axis  pitch == x axis) 
    public float roll;                      //Value aplyed to the rotation on the x axis of the ship
          
    //Starts Before Start 
    //AWAKE========================================================================
    private void Awake()
    {  //CONSTANTS
        defaultMaxSpeed = 2f;
        thrustMultiplier = 10f;
        
        //GAME CONTROLS============================================================
        //We initzialize the new PlayerControls from the new Unity Input System
        shipControls = new PlayerControls();
        //We call the Gameplay(Action Map) and and link each button to a function
                                             ///////BUTTON ACTION MAP//////
        //SHIP ACCELERATION DECELERATION ==> R2 button
        shipControls.GamePlay.Accelerate.performed += pressingDownAccelerate => IsAccelerating = true;
        shipControls.GamePlay.Accelerate.canceled += pressingDownAccelerate => IsAccelerating = false;
        //SHIP DECELERATIOn==> L2 button
        shipControls.GamePlay.Decelerate.performed += pressinDownDecelerate => isDecelerating = true;
        shipControls.GamePlay.Decelerate.canceled += pressinDownDecelerate => isDecelerating = false;

        //SHIP PITCH AND YAW ==> Left stick
        shipControls.GamePlay.RotateShip.performed += rotatingShip => rotate= rotatingShip.ReadValue<Vector2>();
        shipControls.GamePlay.RotateShip.canceled += rotatingShip => rotate =Vector2.zero;
        shipControls.GamePlay.RotateShip.performed += rotatingShip => isRotating = true;
        shipControls.GamePlay.RotateShip.canceled += rotatingShip => isRotating = false;

        //ShHIP ROTATION lEFT==> L1
        shipControls.GamePlay.RotateLeft.performed += rollLeft => isRollingLeft = true;
        shipControls.GamePlay.RotateLeft.canceled += rollLeft =>isRollingLeft=false;
        //SHIP ROTATION RIGHT ==> R1
        shipControls.GamePlay.RotateRight.performed += rollRight => isRollingRight = true;
        shipControls.GamePlay.RotateRight.canceled += rollRight => isRollingRight = false;

    }
    //START========================================================================

    private void Start()
    {

        //INITZIALIZING VARIABLES
        shipRB =transform.GetComponent<Rigidbody>();
        thrust = 10f;
        rotationSpeed = 50f;
        IsAccelerating = false;
        isDecelerating = false;
        currenVelocity = shipRB.velocity.z;
        roll = 50f;
    }
    //FIXED UPDATE========================================================================

    private void FixedUpdate() //Fixed update because we are using physics
    {
        //ACCELERATION AND VELOCITY CHECK
        currenVelocity = shipRB.velocity.magnitude;
        //Pushes ship forward 
        if (IsAccelerating)
        {
            shipRB.AddRelativeForce(0f,0f,  thrust * Time.deltaTime);           
        }
         //Pushes ship backwards
        if (isDecelerating)
        {
            shipRB.AddRelativeForce(0f,0f, thrust* Time.deltaTime * -1);   
        }  

        //Checks Speed value from RigidBody component in Ship
        if (currenVelocity > defaultMaxSpeed)
        {
            shipRB.AddRelativeForce(transform.forward * thrust * Time.deltaTime * -1);       
        }
        //PITCH YAW
        if (!isRotating)
        {
            defaultMaxSpeed = 2f;
        }
        if (isRotating)
        {
        Vector2 rotation = new Vector2(rotate.y, rotate.x)*rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation, Space.Self);
            defaultMaxSpeed *= thrustMultiplier * Time.deltaTime;
        }
     
       
        //ROLL
        if (isRollingLeft)
        {
            Vector3 rolling = new Vector3(0f,0f, rotationSpeed * Time.deltaTime);
            transform.Rotate(rolling,Space.Self);
        }
        if (isRollingRight)
        {
            Vector3 rolling = new Vector3(0f, 0f, rotationSpeed * -1 * Time.deltaTime);
            transform.Rotate(rolling, Space.Self);
        }
    }
    //FUNCTIONS========================================================================

    //ENABLE DISABLE CONTROL MAP
    void OnEnable()
    {
        shipControls.GamePlay.Enable();
    }
    private void OnDisable()
    {
        shipControls.GamePlay.Disable();
    }
}
