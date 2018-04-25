using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

    public Rigidbody2D myRigidbody;
    public float maxLaunchDeviationPercent = 0.2f;

    int UP = 0;
    int RIGHT = 1;
    int DOWN = 2;
    int LEFT = 3;

	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
	}
	

	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
	}
    
    //Adds force times M in direction according to dir 
    public void Launch(float m, int dir)
    {
        float devation = Random.Range(-maxLaunchDeviationPercent, maxLaunchDeviationPercent);
        if (dir == UP)
        {
            myRigidbody.AddForce( new Vector2(devation,1) * m);
        }
        else if (dir == RIGHT)
        {
            myRigidbody.AddForce( new Vector2(1, devation) * m);
        }
        else if (dir == DOWN)
        {
            myRigidbody.AddForce( new Vector2(devation, 1) * -m);
        }
        else if (dir == LEFT)
        {
            myRigidbody.AddForce( new Vector2(1, devation) * -m);
        }
    }

}
