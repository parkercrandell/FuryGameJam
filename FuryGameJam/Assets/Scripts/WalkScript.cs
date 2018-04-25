﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {

    public Rigidbody2D myRigidBody;
    public float thrust = 1;
    public float dragValue = 1;
    public int directionFaced;
    public float attackRange = 1;
    public float kickMagnitude = 1; 

    int UP = 0;
    int RIGHT = 1;
    int DOWN = 2;
    int LEFT = 3;
        
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        myRigidBody.drag = dragValue;
        WalkFuction();
        Kick();

    }

    //Movement Script Here
    //Takes in arrow keys and adds force to character in respective direction
    //Applies *thrust* force even if you move diagonally
    //If you move in a cardnal direction, your position is updated
    public void WalkFuction()
    {

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.AddForce(new Vector2(0.707f, 0.707f) * thrust);
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.AddForce(new Vector2(-0.707f, 0.707f) * thrust);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.AddForce(new Vector2(0.707f, -0.707f) * thrust);
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.AddForce(new Vector2(-0.707f, -0.707f) * thrust);
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                myRigidBody.AddForce(transform.up * thrust);
                directionFaced = UP;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myRigidBody.AddForce(transform.right * -thrust);
                directionFaced = LEFT;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                myRigidBody.AddForce(transform.up * -thrust);
                directionFaced = DOWN;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                myRigidBody.AddForce(transform.right * thrust);
                directionFaced = RIGHT;
            }
        }
    }

    //Raycasts towards cardinal directions according to the position variable (set in WalkFunction);
    //returns RigidBody of object
    //Character has to be on IgnoreRayCast Layer
    public Rigidbody2D GetFacedObject()
    {
        Rigidbody2D rb;
        Vector2 direction = new Vector2(0,0);
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);
        
        if (directionFaced == UP)
        {
            direction = transform.up;
        }
        else if (directionFaced == RIGHT)
        {
            direction = transform.right;
        }
        else if (directionFaced == DOWN)
        {
            direction = -transform.up;
        }
        else if (directionFaced == LEFT)
        {
            direction = -transform.right;
        }

        rb = Physics2D.Raycast(origin, direction, attackRange).rigidbody;
        Debug.DrawRay(origin, direction);

        return rb;
    }

    //Takes Rigidbody and returns the code to call fuctions from
    //could add a check of whether the rigidbody is null or not?
    public ObjectScript GetObjectCode(Rigidbody2D r)
    {
        return r.GetComponent<ObjectScript>();
    }

    //Checks if the z key had been pressed then calls Launch from the object detected from the FacedObject
    //applies throwMagnitude to object
    public void Kick()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            Rigidbody2D r = GetFacedObject();
            if (r != null && r.tag == "Object")
            {
                GetObjectCode(r).Launch(kickMagnitude, directionFaced);
            }
        }
    }
}