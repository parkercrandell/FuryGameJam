using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Nina Demirjian and Parker Crandell 2018

//Class that manages the Score and the time in the game.
//time counts down.

public class ScoreAndTime : MonoBehaviour {

	//Variables for time and score. I made them static so that they can
	//be accessed by any class. Change number here to change how much time
	//the player starts with

	float timeLeft = 150f; //not accesible; just for float
	public static int timeLeftInt; //accessible, integer
	public static int score = 0;

	public static int rageLevel = 0;

	void Start () {}
	
	// Update is called once per frame
	void Update () {

		//This is the time count down. I convert time left to an integer so
		//that printing it out will not produce long ugle decimals and it will
		//just display the time left in integers
		timeLeft = timeLeft - Time.deltaTime;
		timeLeftInt = (int) timeLeft;
		//Debug.Log (timeLeftInt); //debugging
		
	}

	//A public static void to add a value to the score. The void takes in an integer
	//as a parameter and adds that value to the score. 
	public static void addToScore(int numToAdd){
		score += numToAdd;
	}

	//A public static void to add a value to the rage level. The void takes in an integer
	//as a parameter and adds that value to the rage. Rage is used to determine how much damage
	//the player does to object/how strong she is.
	public static void addToRage(int numToAdd){
		rageLevel += numToAdd;
	}
}
