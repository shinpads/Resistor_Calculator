using UnityEngine;
using System.Collections;
using UnityEngine.UI;
/// <summary>
/// Getting the input from inputField Object Unity.
/// Returning Method Value to Resistance Caluator
/// </summary>
public class getinput : MonoBehaviour {
    //Private class resistance
	GameObject resistor;
	InputField resInput;
	void Start(){
		resistor = GameObject.FindGameObjectWithTag ("resistor");
		resInput = GameObject.Find ("input_resistance").GetComponent<InputField>();

	}	


	//OHMS INPUT---------------------------------------------
	static float resistance;  
    public void ohmsInput(string input) {
		// for four bands: (rounding last digit)
		if (input.Length == 3) {			
			resInput.text = (int.Parse(input) / 10 * 10).ToString();
		}
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
	//TOLERANCE PERCENT DROP DOWN--------------------------------
	static int percentIndex;
	public void toleranceSelect(int percent){
		percentIndex = percent;
		resistor.GetComponent<ResistanceCaluator> ().updateToleranceBand (percent);
	}

}
