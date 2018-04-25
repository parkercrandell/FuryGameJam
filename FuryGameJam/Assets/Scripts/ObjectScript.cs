using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

    public Rigidbody2D myRigidbody;

    int UP = 0;
    int RIGHT = 1;
    int DOWN = 2;
    int LEFT = 3;

	void Start () {
        myRigidbody.GetComponent<Rigidbody2D>();
	}
	

	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
	}
    
    //Adds force times M in direction according to dir 
    public void Launch(float m, int dir)
    {
        if (dir == UP)
        {
            myRigidbody.AddForce(transform.up * m);
        }
        else if (dir == RIGHT)
        {
            myRigidbody.AddForce(transform.right * m);
        }
        else if (dir == DOWN)
        {
            myRigidbody.AddForce(-transform.up * m);
        }
        else if (dir == LEFT)
        {
            myRigidbody.AddForce(-transform.right * m);
        }
    }
}
