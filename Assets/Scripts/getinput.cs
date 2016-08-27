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
	private void updateRange(int tolPercent, float resistance){
		tolPercent = (tolPercent + 1) * 5;
		float tolValue = resistance * tolPercent * 0.01f;
		tolText.text = "(" + (resistance - tolValue).ToString () + " - " + (resistance + tolValue).ToString () +")";
	}
	public void roundOhmInput(string input){
		// Round last digit
		if (input.Length == resInput.characterLimit) {
			//only round if resistance is greater than 1(4 band) or 10(5 band)
			if (float.Parse (input) > Mathf.Pow (10, resInput.characterLimit - 3)){
				resInput.text = (int.Parse(input) / 10 * 10).ToString();

			}
		}
	}
	//OHMS INPUT---------------------------------------------
	static float resistance = 0f;  
    public void ohmsInput(string input) {
		//make sure there is a number
		if(input=="")
			input="0";
		//makesure last char not a decimal
		if(input [input.Length-1] == '.')
			input += "0";
		if (float.Parse (input) >= 1000) {
			input = (int.Parse (input) / 10).ToString ();
			resInput.text = input;
		}
		roundOhmInput (input);
		resistance = float.Parse(input); 
		updateRange (percentIndex, resistance);
		//call changeColor function from resistor object
		resistor.GetComponent<ResistanceCaluator> ().changeColor (resistance,units,bandCount);
    }

	//DROPDOWN INPUT---------------------------------------------
	static int units = 0; 
	public void dropSelect(int selection){
		units = selection;
		resistor.GetComponent<ResistanceCaluator> ().changeColor (resistance,units,bandCount);
	}
	//TOLERANCE PERCENT DROP DOWN--------------------------------
	static int percentIndex = 0;
	public void toleranceSelect(int percent){
		updateRange (percent , resistance);
		percentIndex = percent;
		resistor.GetComponent<ResistanceCaluator> ().updateToleranceBand (percent);
	}
	//BAND AMOUNT DROP DOWN-------------------------------------
	static int bandCount = 4;
	public void bandAmountSelect(int bands){
		resInput.characterLimit = bands + 3;
		bandCount = bands + 4;
		resistor.GetComponent<ResistanceCaluator> ().changeColor (resistance,units,bandCount);
	}


}
