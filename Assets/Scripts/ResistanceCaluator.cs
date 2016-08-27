using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResistanceCaluator : MonoBehaviour {
	
	//Color codes for resistor in number order
	Material[] code = new Material[12];
	void Start (){
		//load all materials into an array in order
		for(int k =0; k<12; k++){
			code [k] = Resources.Load ("Materials/bands/b"+k.ToString(),typeof(Material)) as Material;
		}
	}
	//method to return which color a number is
	private Material getColor(int num){
		return code [num];
	}

	//method to return an array of colors based on resistances
	public List<Material> convertToColor(float ohms, int units){
		//list to store colors
		List<Material> colors = new List<Material>();

		//Create string from ohms input value
		string sOhms = ohms.ToString();

		//make sure it is atleast 3 digits(for 3 bands)
		while (sOhms.Length < 2) {
				sOhms = sOhms + "0";
		}
		//ohms = float.Parse (sOhms);
		sOhms = sOhms.Replace (".","");
		foreach (char x in sOhms) {
			//add a color for each value
			colors.Add (getColor(int.Parse(""+x)));
			if (colors.Count == 2)
					break;
		}
		//add the multiplier band
		colors.Add (getColor (getMulIndex (ohms,units)));
		return colors;
}
	private int getMulIndex(float ohms, int units){
		//create size variable to keep track of by what value 10^x you are multiplying the first 2 color bands by
		int size = -2;
		//add units to size (normal ohms = 10^(0*3) = 1 ohm, kilo ohms = 10^(1*3) = 1000 ohms etc)
		size += units*3;
		//convert float to a string
		string sOhms = ohms.ToString ();
		if (ohms >= 1) {					
			//bump up size for each digit before the decimal
			foreach (char value in sOhms) {
				if (value != '.') {
					size += 1;
				} else {
					break;
				}
			}
		}
		// if the size is still negative, loop backwards
		if (size < 0) {			
			size = 12 + size;
		}
		return size;
	}
	public void changeColor(float ohms, int units){
		//change color
		//load all bands into an array
		GameObject[] bands = new GameObject[3];
		for (int i = 1; i <=3; i++) {
			string band = "band" + i.ToString ();
			bands [i-1] = GameObject.FindGameObjectWithTag (band);
		}
		//get colors and store in list
		List<Material> colors = convertToColor(ohms, units);
		//for each band, set the color to the color based on the inputed resistance
		foreach(GameObject band in bands){	
			//set next band's color to next color in list
			band.GetComponent<Renderer> ().material.color = colors [0].color;
			//remove first color in list
			colors.RemoveAt (0);
		}
	}
	public void updateToleranceBand(int tol){		
		GameObject bandTol = GameObject.FindGameObjectWithTag ("bandTol");
		if (tol == 0) {
			bandTol.GetComponent<Renderer> ().material.color = code [11].color;
		} else if (tol == 1) {
			bandTol.GetComponent<Renderer> ().material.color = code [10].color;
		} 
	}
}