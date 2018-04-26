using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour {

	bool facingleft = false;
	bool keyHeld = false;
	bool animating = false;


	SpriteRenderer sr;

	public Sprite walkRight0;
	public Sprite walkRight1;
	public Sprite walkRight2;
	public Sprite walkLeft0;
	public Sprite walkLeft1;
	public Sprite walkLeft2;





	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			facingleft = true;
			keyHeld = true;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			facingleft = false;
			keyHeld = true;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) {
			keyHeld = true;
		}

		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
			keyHeld = false;
			animating = false;
			if (facingleft) {
				sr.sprite = walkLeft1;
			} else {
				sr.sprite = walkRight1;
			}
		}


		if (keyHeld && facingleft) {
			Debug.Log ("WALKING LEFT");
			if (animating == false) {
				animating = true;
				StartCoroutine (walkLeft ());
			}
		}
		if (keyHeld && !facingleft) {
			if (animating == false) {
				animating = true;
				Debug.Log ("WALKING RIGHT");
				StartCoroutine (walkRight ());
			}
		}
	}

	IEnumerator walkRight(){
		while (keyHeld) {
			sr.sprite = walkRight0;
			yield return new WaitForSeconds (.2f);
			sr.sprite = walkRight1;
			yield return new WaitForSeconds (.2f);
			if (keyHeld) {
				sr.sprite = walkRight2;
				yield return new WaitForSeconds (.2f);
				sr.sprite = walkRight1;
				yield return new WaitForSeconds (.2f);
			}
			
		}
	}
	IEnumerator walkLeft(){
		while (keyHeld) {
			sr.sprite = walkLeft0;
			yield return new WaitForSeconds (.2f);
			sr.sprite = walkLeft1;
			yield return new WaitForSeconds (.2f);
			if (keyHeld) {
				sr.sprite = walkLeft2;
				yield return new WaitForSeconds (.2f);
				sr.sprite = walkLeft1;
				yield return new WaitForSeconds (.2f);
			}

		}
	}
}
