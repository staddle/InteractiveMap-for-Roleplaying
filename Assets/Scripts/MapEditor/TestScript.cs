using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        //Debug.Log(Input.mousePosition + " " + Camera.main.ScreenToViewportPoint(Input.mousePosition));
    }
}
