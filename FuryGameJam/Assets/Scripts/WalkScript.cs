using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nina Demirjian and Parker Crandell 2018

public class WalkScript : MonoBehaviour {

    public Rigidbody2D myRigidBody;
    public SpriteRenderer mySprite;
    public ScoreAndTime MyScore;
    public float ragePercent;
    public float thrust = 1;
    public float maxThrustBoost = 20;
    public float dragValue = 1;
    public int directionFaced;
    public float attackRange = 1;
    public float bashDamage = 3;
    public float maxRageDamage = 4; 
    public float kickMagnitude = 100;
    public float maxRageKickMagnitude = 100;


    int UP = 0;
    int RIGHT = 1;
    int DOWN = 2;
    int LEFT = 3;
        
    void Start() {
        myRigidBody = GetComponent<Rigidbody2D>();
        mySprite = GetComponent<SpriteRenderer>();
        //MyScore = GameObject.Find("Timer").GetComponent<ScoreAndTime>();
    }

    void Update()
    {
        ragePercent = (ScoreAndTime.rageLevel / 100f);
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);

        myRigidBody.drag = dragValue;
        WalkFuction();
        Kick();
        Bash();
    }

    //Movement Script Here
    //Takes in arrow keys and adds force to character in respective direction
    //Applies *thrust* force even if you move diagonally
    //If you move in a cardnal direction, your position is updated
    //applies additional maxThrustBoost multiplied by ragePercent
    public void WalkFuction()
    {

        if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.AddForce(new Vector2(0.707f, 0.707f) * (thrust + (maxThrustBoost * ragePercent)));   
        }
        else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.AddForce(new Vector2(-0.707f, 0.707f) * (thrust + (maxThrustBoost * ragePercent)));
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
        {
            myRigidBody.AddForce(new Vector2(0.707f, -0.707f) * (thrust + (maxThrustBoost * ragePercent)));
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
        {
            myRigidBody.AddForce(new Vector2(-0.707f, -0.707f) * (thrust + (maxThrustBoost * ragePercent)));
        }
        else
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                myRigidBody.AddForce(transform.up * (thrust + (maxThrustBoost * ragePercent)));
                directionFaced = UP;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                myRigidBody.AddForce(transform.right * -(thrust + (maxThrustBoost * ragePercent)));
                directionFaced = LEFT;
                mySprite.flipX = true;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                myRigidBody.AddForce(transform.up * -(thrust + (maxThrustBoost * ragePercent)));
                directionFaced = DOWN;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                myRigidBody.AddForce(transform.right * (thrust + (maxThrustBoost * ragePercent)));
                directionFaced = RIGHT;
                mySprite.flipX = false;
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
    //Animates kick
    //applies additional maxRageKickMagnitude multiplied by ragePercent
    public void Kick()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GetComponent<Animator>().ResetTrigger("Kick");
            GetComponent<Animator>().SetTrigger("Kick");
            Rigidbody2D r = GetFacedObject();
            if (r != null && r.tag == "Object") ;
            {
                GetObjectCode(r).Launch(kickMagnitude + (maxRageKickMagnitude * ragePercent), directionFaced);
            }
        }
    }

    //Checks if the x key had been pressed then calls LoseHealth from the object detected from the FacedObject
    //applies bashDamage to object
    //Animates Bash
    //applies additional maxRageDamage multiplied by ragePercent
    public void Bash()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetComponent<Animator>().ResetTrigger("Bash");
            GetComponent<Animator>().SetTrigger("Bash");
            Rigidbody2D r = GetFacedObject();
            if (r != null && r.tag == "Object")
            {
                GetObjectCode(r).LoseHealth(bashDamage + (maxRageDamage * ragePercent));
            }
        }

    }
}