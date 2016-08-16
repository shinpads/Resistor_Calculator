using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResistanceCaluator : MonoBehaviour {

	//Color codes for resistor in number order
	private static string[] code = {"black","brown","red","orange","yellow","green","blue","violet","grey","white"};


	//method to return what value a certain color will represent
	int getNum(string c){
		for (int i = 0; i < code.Length; i++)
			if (code [i] == c)
				return i;
		return -1;
	}
	//method to return which color a number is
	string getColor(int n){
		return code [n];
	}	 

	//method to return an array of colors based on resistances
	public List<string> convertToColor(int ohms){
		//list to store colors
		List<string> colors = new List<string>();
		//Create string from ohms input value
		string sOhms = ohms.ToString();
		//make sure it is atleast 3 digits(for 3 bands)
		while (sOhms.Length < 3) {
			//add 0 (black) if it is not
			sOhms = sOhms + "0";
		}
		foreach (char x in sOhms) {
			//add a color for each value
			colors.Add (getColor(int.Parse(""+x)));
		}
		return colors;
}

	//method to take in a list of colors and return the amount in ohms
	int convertToOhms(List<string> colors){
		//list of four colors
		//string to hold the numbers
		string ohms = "";
		//loop through all colors in the list
		foreach (string col in colors) {
			//loop through all the colors in the code array
			for (int k = 0; k < code.Length; k++)
			//find when they match
				if (col == code [k]) {
					//add the corresponding number to the ohms string
					ohms += k;
					//break out of the foor loop
					break;
				}
		}
		//create integer to return
		int iohms = int.Parse (ohms);
		return iohms;
	}



	//start method
	void Start(){	      
        /*    
		//test
		List<string> resis = convertToColor (152);
		foreach (string col in resis) {
			Debug.Log (col);
		}
		//test2
		int ohms = convertToOhms(resis);
		Debug.Log (ohms);
		*/
	}

	public void changeColor(int ohms){
		//change color
		//string to store final colors
		string outPut = "";
		//get colors and store in list
		List<string> colors = convertToColor(ohms);
		//add each color in list to string
		foreach (string col in colors) {
			outPut += col + ", ";
		}
		//print out
		Debug.Log (outPut);
	}

}
