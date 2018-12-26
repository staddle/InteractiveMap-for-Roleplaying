using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class POIScript : MonoBehaviour {

    public GameObject input_Name, input_Desc, input_Tags;
    public Color color = Color.clear;
    public GameObject createButton;
    public TMP_InputField inputname, inputdesc, inputtags;
    void Start () {
        //createButton.SetActive(false);
        inputname = input_Name.GetComponent<TMP_InputField>();
        inputdesc = input_Desc.GetComponent<TMP_InputField>();
        inputtags = input_Tags.GetComponent<TMP_InputField>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeColor(string hex)
    {
        float r, g, b;
        if (hex.Contains("#"))
        {
            r = hexToFloat(hex.Substring(hex.IndexOf('#') + 1, 2));
            g = hexToFloat(hex.Substring(hex.IndexOf('#') + 3, 2));
            b = hexToFloat(hex.Substring(hex.IndexOf('#') + 5, 2));
            //Debug.Log(r +" "+ g +" "+b);
        }
        else
        {
            r = g = b = 0;
        }
        color = new Color(r/255, g/255, b/255);
    }

    float hexToFloat(string hexString)
    {
        Debug.Log(hexString);
        /*uint num = uint.Parse(hexString, System.Globalization.NumberStyles.AllowHexSpecifier);

        byte[] floatVals = BitConverter.GetBytes(num);
        return BitConverter.ToSingle(floatVals, 0);*/
        return (float) int.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
    }

    public void check()
    {
        if(inputname.text!=null)
        {
            createButton.SetActive(true);
        }
    }

    public void setButtonUnactive()
    {
        createButton.SetActive(false);
    }
}
