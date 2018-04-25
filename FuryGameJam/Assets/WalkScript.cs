using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {

    public Rigidbody2D myRigidBody;
    public float thrust = 1;
    public float dragValue;
        
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        myRigidBody.drag = dragValue;

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
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myRigidBody.AddForce(transform.right * -thrust);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                myRigidBody.AddForce(transform.up * -thrust);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                myRigidBody.AddForce(transform.right * thrust);
            }
        }
    }
}