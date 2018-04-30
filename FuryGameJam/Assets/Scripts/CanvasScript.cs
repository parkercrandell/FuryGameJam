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
	public Text scoreField;
	public Text timeField;
	public Image cellphone; //reference to the cellphone image 
	public Image rageLevel;


	float timer = 1f;

	// Use this for initialization
	void Start () {
		//When the game begins, start running the texts that are coming in
		StartCoroutine (runTexts ());
	}

	void Update(){
		//Update the score and timer left fields
		scoreField.text = "Score: " + ScoreAndTime.score;
		timeField.text = "Time Remaining: " + ScoreAndTime.timeLeftInt;

		RectTransform rectTrans = cellphone.GetComponent<RectTransform> ();
		timer = timer - Time.deltaTime;
		if (timer < 0 && timer > -.6f) {
			rectTrans.rotation = Quaternion.Euler (0, 0, 5f);
		} else if (timer < -.6f) {
			timer = .6f;
			rectTrans.rotation = Quaternion.Euler (0, 0, -11f);
		}

		if (ScoreAndTime.rageLevel < 100f) {
			Vector3 newScale = new Vector3 (rageLevel.GetComponent<RectTransform> ().localScale.x, ScoreAndTime.rageLevel / 100f, rageLevel.GetComponent<RectTransform> ().localScale.z);

			rageLevel.GetComponent<RectTransform> ().localScale = newScale;
		}



	}
		

	//void that just has list of texts to run, in order, with times.
	//create message with string creates the message
	//the yield return new makes it so that theres a delay between texts that are sent
	IEnumerator runTexts(){
		Color brittany = new Color (1.0f, .8f, .8f, 1f);
		Color chad = new Color (.8f, .8f, 1.0f, 1.0f);
		Color stacy = new Color (.8f, 1f, .8f, 1f);
		Color jessica = new Color (1f, .7f, 1f, 1f);
		createMessage ("",0,chad);
		yield return new WaitForSeconds (2f);
		createMessage ("Chad: Hey Babe, I'll be home soon. Sorry i was at the office so long. ",0,chad);
		yield return new WaitForSeconds (7f);
		createMessage ("Brittany: OMG. Girl. You are never going to believe what Stacy just told me about Chad.",1,brittany);
		yield return new WaitForSeconds (6f);
		createMessage ("Brittany: Stacy said she just saw him holding hands with JESSICA at the mall.", 2, brittany);
		yield return new WaitForSeconds (6f);
		createMessage ("Stacy: Girl, bad news. I think Chad is cheating on you.", 10, stacy);
		yield return new WaitForSeconds (6f);
		createMessage ("Stacy: I'm watching him put his arm around Jessica right now.", 5, stacy);
		yield return new WaitForSeconds (5f);
		createMessage ("Chad: Sorry babe, its actually going to be a while before I'm home. Traffic...", 5, chad);
		yield return new WaitForSeconds (5f);
		createMessage ("Brittany: Hello? Are you ok?", 0, brittany);
		yield return new WaitForSeconds (3f);
		createMessage ("Brittany: Hello? ...", 0, brittany);
		yield return new WaitForSeconds (5f);
		createMessage ("Stacy: OMG bitch no! He just bought her an Auntie Anne's soft pretzel!", 5, stacy);
		yield return new WaitForSeconds (4f);
		createMessage ("Stacy: That's totally what he did for you on your first date!", 2, stacy);
		yield return new WaitForSeconds (5f);
		createMessage ("Chad: I'll make it up to you, I swear. I won't come home this late again.", 2, chad);
		yield return new WaitForSeconds (5f);
		createMessage ("Brittany: You need to call him out before I do it for you.", 0, brittany);
		yield return new WaitForSeconds (5f);
		createMessage ("Stacy: I can't believe Jessica! She knew you guys have been dating for two years!", 3, stacy);
		yield return new WaitForSeconds (5f);
		createMessage ("Jessica: Hey girl, haven't seen you in a while. Let's catch up. Wanna get coffee sometime?", 7, jessica);
		yield return new WaitForSeconds (8f);
		createMessage ("Stacy: Omg... did she just text you?", 2, stacy);
		yield return new WaitForSeconds (3f);
		createMessage ("Stacy: She's such a bad friend!", 1, stacy);
		yield return new WaitForSeconds (4f);
		createMessage ("Brittany: That's it. Im confronting Chad.", 1, brittany);
		yield return new WaitForSeconds (5f);
		createMessage ("Brittany: No one treats my best friend like this!", 1, brittany);
		yield return new WaitForSeconds (5f);
		createMessage ("Stacy: Someone just called Chad... I see him sitting outside of Hot Topic on his phone.", 1, stacy);
		yield return new WaitForSeconds (7f);
		createMessage ("Stacy: Oh shit! He's looking around! I wonder if he knows I'm watching him.", 1, stacy);
		yield return new WaitForSeconds (5f);
		createMessage ("Chad: Babe... Have you talked to Brittany or Stacy at all lately?", 3, chad);
		yield return new WaitForSeconds (5f);
		createMessage ("Chad: Look, you know how dramatic girls can be...", 10, chad);
		yield return new WaitForSeconds (5f);
		createMessage ("Chad: Whatever they told you is a lie. You trust me, right babe?", 10, chad);
		yield return new WaitForSeconds (5f);
		createMessage ("Brittany: I just got off the phone with Chad.", 1, brittany);
		yield return new WaitForSeconds (5f);
		createMessage ("Brittany: He denied everything. God I hate him so much.", 5, brittany);
		yield return new WaitForSeconds (5f);
		createMessage ("Chad: Babe, stay there. I'm coming home right now", 5, chad);
		yield return new WaitForSeconds (5f);
		createMessage ("Stacy: He's leaving? Girl, I think he's coming home. Get ready to call him out", 4, stacy);
		createMessage ("Chad: I'll be home soon. You know you're the only girl for me, right?", 12, chad);
		yield return new WaitForSeconds (5f);


		///add more here...


	}


	//Just a helper method to change the text on the screen and add to the rage level.
	void createMessage(string newMessage, int rageAdd, Color color){
		text.text = newMessage;
		text.color = color;
		ScoreAndTime.addToRage (rageAdd);
	}


}
