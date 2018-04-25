using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkScript : MonoBehaviour {
    
	void Start () {
		
	}
	
	void Update () {
        Transform.position.z = Transform.position.y; 

	}
}
