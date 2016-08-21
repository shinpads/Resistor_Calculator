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
		while (sOhms.Length != 3) {
			if (sOhms.Length < 3) {
				//add 0 (black) if it is not
				sOhms = sOhms + "0";
			} else if(sOhms.Length > 3) {
				sOhms.Remove (sOhms.Length - 1);
			}
		}
		foreach (char x in sOhms) {
			//add a color for each value
			colors.Add (getColor(int.Parse(""+x)));
		}

		colors.Add (getColor (getMulIndex (ohms,units)));
		foreach (Material co in colors) {
			Debug.Log (co);
		}
		return colors;
}
	private int getMulIndex(float ohms, int units){		
		ohms = ohms * Mathf.Pow (10,units);
		string sOhms = ohms.ToString ();
		int size = 0;
		Debug.Log (sOhms);
		foreach (char value in sOhms) {
			if (value != '.') {
				size += 1;
			}
		}
		if (size < 3) {			
			size = 12 - size;
		}
		return size;
	}
	public void changeColor(float ohms, int units){
		//change color
		//load all bands into an array
		GameObject[] bands = new GameObject[4];
		for (int i = 1; i < 5; i++) {
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
}