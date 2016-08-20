using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ResistanceCaluator : MonoBehaviour {
	
	//Color codes for resistor in number order
	Material[] code = new Material[12];
	int units = 0;
	void Start (){
		//load all materials into an array in order
		for(int k =0; k<12; k++){
			code [k] = Resources.Load ("Materials/bands/b"+k.ToString(),typeof(Material)) as Material;
		}
	}
	//method to return which color a number is
	Material getColor(int num){
		return code [num];
	}
	//method to return an array of colors based on resistances
	public List<Material> convertToColor(int ohms){
		//list to store colors
		List<Material> colors = new List<Material>();
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
	public void changeColor(int ohms){
		//change color
		//load all bands into an array
		GameObject[] bands = new GameObject[4];
		for (int i = 1; i < 5; i++) {
			string band = "band" + i.ToString ();
			bands [i-1] = GameObject.FindGameObjectWithTag (band);
		}
		//get colors and store in list
		List<Material> colors = convertToColor(ohms);
		//for each band, set the color to the color based on the inputed resistance
		foreach(GameObject band in bands){	
			band.GetComponent<Renderer> ().material.color = colors [0].color;
			colors.RemoveAt (0);
		}
	}
}