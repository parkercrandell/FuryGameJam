using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Nina Demirjian and Parker Crandell 2018
//Script that manages what gets displayed on the screen (texts from other people)

public class CanvasScript : MonoBehaviour {

	//List of public variables that are in the canvas. Accessing them so we can update
	//the text field through code

	public Text text; //the text that is displayed
	public Image cellphone; //reference to the cellphone image 

	float timer = 1f;

	// Use this for initialization
	void Start () {
		//When the game begins, start running the texts that are coming in
		StartCoroutine (runTexts ());
		
	}
		

	//void that just has list of texts to run, in order, with times.
	//create message with string creates the message
	//the yield return new makes it so that theres a delay between texts that are sent
	IEnumerator runTexts(){
		createMessage ("Hi this is a test",0);
		yield return new WaitForSeconds (4f);
		createMessage ("test number 2",0);
		yield return new WaitForSeconds (6f);
		createMessage ("test over", 0);


	}


	//Just a helper method to change the text on the screen and add to the rage level.
	void createMessage(string newMessage, int rageAdd){
		text.text = newMessage;
		ScoreAndTime.addToRage (rageAdd);
	}


}
