using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIScript : MonoBehaviour {

    public GameObject input_Name, input_Desc, input_Tags;
    public Color color;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeColor(string hex)
    {
        float r, g, b;
        if (hex.Contains("#"))
        {
            r = float.Parse(hex.Substring(hex.IndexOf('#'), 2),System.Globalization.NumberStyles.HexNumber);
            g = float.Parse(hex.Substring(hex.IndexOf('#')+2, 2), System.Globalization.NumberStyles.HexNumber);
            b = float.Parse(hex.Substring(hex.IndexOf('#')+4, 2), System.Globalization.NumberStyles.HexNumber);
        }
        else
        {
            r = g = b = 0;
        }
        color = new Color(r, g, b);
    }
}
