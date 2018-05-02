using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nina Demirjian and Parker Crandell 2018

public class ObjectScript : MonoBehaviour {

	//Variable setup
    public Rigidbody2D myRigidbody;
    public SpriteRenderer mySprite;
    public ScoreAndTime MyScore;
    public float maxLaunchDeviationPercent = 0.9f;
    public float maxHealth = 5;
    public float health;
    public int scoreWhenBroken = 100;
    public int scoreOnCollision = 20;
    public float maxLaunchBoostWhileDamaged = 50;
    public float damageOnCollision = 2;

    public Color white = new Color(255 / 255, 255 / 255, 255 / 255);
    public Color damagedColor = new Color(255 / 255, 86 / 255, 86 / 255);

    int UP = 0;
    int RIGHT = 1;
    int DOWN = 2;
    int LEFT = 3;

	void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        MyScore = GameObject.Find("Timer").GetComponent<ScoreAndTime>();
        health = maxHealth;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        white = new Color(255 / 255, 255 / 255, 255 / 255);
        damagedColor = new Color(255 / 255, 86 / 255, 86 / 255);
    }


    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        mySprite.color = Color.Lerp(white, damagedColor, ((maxHealth - health) / maxHealth));

        if (health < 1)
        {
            ScoreAndTime.addToScore(scoreWhenBroken);
            Destroy(gameObject);
        }
    }

    //h is how much health to be subrtacted from helath
    public void LoseHealth(float h)
    {
        health -= h;
    }
    
    //Adds force times M in direction according to dir 
    //Adds additional maxLaunchBoostWhileDamaged multiplied by health percentage
    public void Launch(float m, int dir)
    {
        float devation = Random.Range(-maxLaunchDeviationPercent, maxLaunchDeviationPercent);
        m = m + (maxLaunchBoostWhileDamaged * ((maxHealth - health) / maxHealth));  

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

    //adds respective scoreOnCollision and damageOnCollision upon colliding with object or wall
    void OnCollisionEnter2D (Collision2D coll)
    {
        if (coll.gameObject.tag == "Object" || coll.gameObject.tag == "Wall")
        {
            ScoreAndTime.addToScore(scoreOnCollision);
            LoseHealth(damageOnCollision);
        }
    }
}
