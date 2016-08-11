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

	//method to return an array of colors based on resistance
	Color[] convertToColor(int ohms){
		//array to store colors
		Color[] colors = new Color[3];
		string sOhms = ohms.ToString ();
		for(int i = 0; i < sOhms.Length; i++)
			colors[i] = getColor (int.Parse(sOhms[i]));

	}
}
