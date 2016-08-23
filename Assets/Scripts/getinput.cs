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


	//OHMS INPUT---------------------------------------------
	static float resistance;

    //Getting input from inputfield
    public void ohmsInput(string input) {
		if(input=="")
			input="0";
		if(input [input.Length-1] == '.')
			input += "0";
		resistance = float.Parse(input);       
		//call changeColor function from resistor object
		resistor.GetComponent<ResistanceCaluator> ().changeColor (resistance,units);
    }

	//DROPDOWN INPUT---------------------------------------------
	static int units; 
	public void dropSelect(int selection){
		units = selection;
		resistor.GetComponent<ResistanceCaluator> ().changeColor (resistance,units);
	}


}
