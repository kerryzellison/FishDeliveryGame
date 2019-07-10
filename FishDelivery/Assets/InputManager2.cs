﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager2 : MonoBehaviour
{
    //input Managers tasks:
    //register input from controller
    //differentiate between players
    //translate input into action to call in form of functions from other script
    //keeps track of the state of the car


    public int playerNumber = 0;

    //input button names
    string camY;
    string camX;
    string reset;
    string vertical;
    string horizontal;
    string accelerate;
    string reverse;
    string jump;
    string shoot;

    string nitro;

    string DebugReset;
    // stick values
    float verticalVal;

    float horizontalVal;


    //states
    public bool IsGrounded;
    public bool IsDriving;
    bool HasSpikyWheels;
    bool HasJumped;
    bool IsUpsideDown;
    bool HasShot;
    bool HasHit;
    bool IsSwinging;
    bool BrakeNotReverse;
    bool HasTiltedHorizontal;
    bool HasTiltedVertical;

    //connected scripts
    DriveController dc;
    CameraController cc;

    GroundBoost gb;

    void Start()
    {
        //set input to playernumber
        camY = "CamY"+playerNumber;
        camX = "CamX"+playerNumber;
        reset = "Reset"+playerNumber;
        vertical = "Vertical"+playerNumber;
        horizontal = "Horizontal"+playerNumber;
        accelerate = "Accelerate"+playerNumber;
        reverse = "Reverse"+playerNumber;
        jump = "Jump"+playerNumber;
        shoot = "Shoot"+playerNumber;
        DebugReset = "DebugReset"+playerNumber;
        nitro = "Nitro"+playerNumber;

        dc = GetComponent<DriveController>();
        //cc = GameObject.Find("Main Camera").GetComponent<CameraController>();
        gb = GetComponent<GroundBoost>();
    }

    // Update is called once per frame
    void Update()
    {


//******Camera movement******
        float camYVal = Input.GetAxis(camY);
        if(camYVal !=0)
        {
            //Debug.Log("camY "+ camYVal);
        }

        float camXVal = Input.GetAxis(camX);
        if(camXVal !=0)
        {
            //Debug.Log("camX "+ camXVal);
        }

        if(camYVal !=0|| camXVal !=0)
        {
            //cc.RotateCamera(camYVal, camXVal);
        }

// ******Car movement******
        verticalVal = Input.GetAxis(vertical);
        horizontalVal = Input.GetAxis(horizontal);
        
        //Steering
        if (HasTiltedHorizontal)
        {
            dc.Steer(horizontalVal);
        }
        else
        {
            dc.Steer(0);
        }
            
        if(!IsGrounded &&  (HasTiltedHorizontal || HasTiltedVertical))
        {
            //Debug.Log("air steer");
            dc.AerialSteer(horizontalVal, verticalVal);
        }

        //Accelerate
        if(Input.GetButton(accelerate) && IsGrounded)
        {
           //Debug.Log("Accelerate");
           IsDriving = true;
           dc.Accelerate(1);
        }
        if(Input.GetButtonUp(accelerate))
        {
           //Debug.Log("Accelerate");
           dc.Accelerate(0);
        }

        //Reverse or Brake
        if(Input.GetButtonDown(reverse))
        {
            if(IsDriving)
            {
                BrakeNotReverse = true;
            }
            else
            {
                BrakeNotReverse = false;
            }
        }

        if (Input.GetButton(reverse) && IsGrounded)
        {
            if (BrakeNotReverse)
            {
                //Debug.Log("Brake");
                dc.Brake(1);
            }
            else
            {
                IsDriving = true;
                dc.Reverse(1);
            }
        }

        if (Input.GetButtonUp(reverse))
        {
           dc.Brake(0);
           dc.Reverse(0);
        }

//*****Abilities*****
        if(Input.GetButton(jump))
        {
            Debug.Log("Jump");
           dc.Rocket();
        }

//*****Abilities*****
        if(Input.GetButtonDown(DebugReset))
        {
           //Debug.Log("Jump");
           dc.ResetRotation();

        }

            
        if(Input.GetButton(nitro)) {
            gb.nitroBoost();
        }

        //Check States
        IsGrounded = dc.CheckWheelsGrounded();
        HasJumped = !IsGrounded;
        HasTiltedHorizontal = SetStickBool(horizontalVal);
        HasTiltedVertical = SetStickBool(verticalVal);


    }        
    public void SetIsDriving(bool boolean)
    {
        IsDriving = boolean;
    }

    private bool SetStickBool(float val)
    {
        if(val == 0)
        {
            return false;
        }
        return true;
    }
}