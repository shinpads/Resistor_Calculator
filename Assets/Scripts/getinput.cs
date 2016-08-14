using UnityEngine;
using System.Collections;
/// <summary>
/// Getting the input from inputField Object Unity.
/// Returning Method Value to Resistance Caluator
/// </summary>
public class inputScript : MonoBehaviour {
    //Private class resistance
    private float resistance;
    //Getting input from inputfield
    public void GetInput(string input) {
        float getRes = float.Parse(input);
        resistance = getRes;

        //test
        Debug.Log("Your Number is " + resistance);
    }
    //returning resistance value for other class to use
    public float returnRes() {
        return resistance;
    }
}
