using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScript : MonoBehaviour {

    public Rigidbody2D myRigidbody;
    public BoxCollider2D myBox;
    public ScoreAndTime MyScore;
    public float maxLaunchDeviationPercent = 0.2f;
    public float maxHealth = 5;
    public float health;
    public int scoreWhenBroken = 100;
    public int scoreOnCollision = 20;
    public float damageOnCollision = 2;

    int UP = 0;
    int RIGHT = 1;
    int DOWN = 2;
    int LEFT = 3;

	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        myBox = GetComponent<BoxCollider2D>();
        MyScore = GameObject.Find("Timer").GetComponent<ScoreAndTime>();
        health = maxHealth;
	}
	

	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        if(health < 1)
        {
            ScoreAndTime.addToScore(scoreWhenBroken);
            Destroy(this);
        }
	}

    //h is how much health to be subrtacted from helath
    public void LoseHealth(float h)
    {
        health -= h;
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

    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Object" || coll.gameObject.tag == "Wall")
        {
            ScoreAndTime.addToScore(scoreOnCollision);
            LoseHealth(damageOnCollision);
        }
    }
    



}
