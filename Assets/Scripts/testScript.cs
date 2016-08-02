using UnityEngine;
using System.Collections;

public class testScript : MonoBehaviour {
	//declare new rigidbody
	Rigidbody rig;
	// Use this for initialization
	void Start () {
		//set rigidbody to the attacted rigidbody component
		rig = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		//check if input for key space
		if (Input.GetKey ("space")) {
			//apply force of 10 units in y-axis (up)
			rig.AddForce (new Vector3 (0, 10, 0));
		}		
	}
}
