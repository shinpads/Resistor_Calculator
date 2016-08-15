using UnityEngine;
using System.Collections;
/// <summary>
/// Getting the input from inputField Object Unity.
/// Returning Method Value to Resistance Caluator
/// </summary>
public class getinput : MonoBehaviour {
    //Private class resistance
	GameObject resistor;

	void Start(){
		resistor = GameObject.FindGameObjectWithTag ("resistor");
	}	
    private float resistance;
    //Getting input from inputfield
    public void GetInput(string input) {
        float getRes = float.Parse(input);
        resistance = getRes;
		resistor.GetComponent<ResistanceCaluator> ().changeColor (resistance);
        //test
        //Debug.Log("Your Number is " + resistance);
    }



}
