//Copyright 2013, Aaron Gutierrez, All rights reserved.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SpaceShip : MonoBehaviour
{

    PlayerControls shipControls;            //New unity InputSystem =====V: 0.9.0
    Rigidbody shipRB;                       //To apply Physics on the ship
    public float thrust;                    //force we add to the ship
    static bool IsAccelerating;             //Bool to check if the ship is accelerating
    public float MAX_VELOCITY;              //Max velocity to control speed of the ship
    private float currenVelocity;           //The curent velocity of the Rigidbody from Ship


    //Starts Before Start 
    private void Awake()
    {  
        //We initzialize the new PlayerControls from the new Unity Input System
        shipControls = new PlayerControls();       

        //We call the Gameplay(Action Map) and and link each button to a function;
        //Using Lambda Expresion
        // "call action from action map" "+=" "ctx(Context)" "=>" perform Function  

        //SHIP ACCELERATION DECELERATION 
        shipControls.GamePlay.Accelerate.performed += pressingDownAccelerate => Accelerate();
        shipControls.GamePlay.Accelerate.canceled += pressingDownAccelerate => Decelerate();


        //CONSTANTS
        MAX_VELOCITY = 0.2f;
       
    }
    
    private void Start()
    {

        //INITZIALIZING VARIABLES
        shipRB =transform.GetComponent<Rigidbody>();
        thrust = 5f;
        IsAccelerating = false; 
        currenVelocity = shipRB.velocity.z;
    }
 
    private void FixedUpdate()
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
