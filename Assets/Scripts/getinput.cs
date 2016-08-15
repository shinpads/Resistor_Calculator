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
    private int resistance;
    //Getting input from inputfield
    public void GetInput(string input) {
        int getRes = int.Parse(input);
        resistance = getRes;
		//call changeColor function from resistor object
		resistor.GetComponent<ResistanceCaluator> ().changeColor (resistance);
    }



}
