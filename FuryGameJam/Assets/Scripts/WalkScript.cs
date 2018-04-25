using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {

    public Rigidbody2D myRigidBody;
    public float thrust = 1;
    public float dragValue;
    public int position;
    public float attackRange;
    public Rigidbody2D DIDITWORK;

    int UP = 0;
    int RIGHT = 1;
    int DOWN = 2;
    int LEFT = 3;
        
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    void Update() {

        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        myRigidBody.drag = dragValue;
        WalkFuction();
        DIDITWORK = GetFacedObject();

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
                position = UP;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myRigidBody.AddForce(transform.right * -thrust);
                position = LEFT;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                myRigidBody.AddForce(transform.up * -thrust);
                position = DOWN;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                myRigidBody.AddForce(transform.right * thrust);
                position = RIGHT;
            }
        }
    }

    public Rigidbody2D GetFacedObject()
    {
        Rigidbody2D rb;
        Vector2 direction = new Vector2(0,0);
        Vector2 origin = new Vector2(transform.position.x, transform.position.y);

        if (position == UP)
        {
            direction = transform.up;
        }
        else if (position == RIGHT)
        {
            direction = transform.right;
        }
        else if (position == DOWN)
        {
            direction = -transform.up;
        }
        else if (position == LEFT)
        {
            direction = -transform.right;
        }

        rb = Physics2D.Raycast(origin, direction, attackRange).rigidbody;
        Debug.DrawRay(origin, direction);

        return rb;
    }
}