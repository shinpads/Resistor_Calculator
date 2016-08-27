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
	Dropdown tolPer;
	Text tolText;
	void Start(){
		resistor = GameObject.FindGameObjectWithTag ("resistor");
		resInput = GameObject.Find ("input_resistance").GetComponent<InputField>();
		tolPer = GameObject.Find ("drop_tolerance").GetComponent<Dropdown> ();
		tolText = GameObject.Find ("text_ohmsRange").GetComponent<Text> ();

	}
	//UPDATE RANGE BELOW RESISTANCE INPUT
	void updateRange(int tolPercent, float resistance){
		tolPercent = (tolPercent + 1) * 5;
		float tolValue = resistance * tolPercent * 0.01f;
		tolText.text = "(" + (resistance - tolValue).ToString () + " - " + (resistance + tolValue).ToString () +")";
	}

	//OHMS INPUT---------------------------------------------
	static float resistance;  
    public void ohmsInput(string input) {
		if(input=="")
			input="0";
		if(input [input.Length-1] == '.')
			input += "0";
		// for four bands: (rounding last digit)
		if (input.Length == 3) {
			if(float.Parse(input) > 1)
				resInput.text = (int.Parse(input) / 10 * 10).ToString();
		}
		resistance = float.Parse(input); 
		updateRange (percentIndex, resistance);
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
		updateRange (percent , resistance);
		percentIndex = percent;
		resistor.GetComponent<ResistanceCaluator> ().updateToleranceBand (percent);
	}
	//BAND AMOUNT DROP DOWN-------------------------------------
	static int bandCount;
	public void bandAmountSelect(int bands){
		bandCount = bands + 5;

	}


}
