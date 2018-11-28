using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public int sensitivity = 5;
    public int maxZoomSize = 100;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Camera cam = GetComponent<Camera>();
        Vector3 oldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && cam.orthographicSize+ (-1 * Input.GetAxis("Mouse ScrollWheel") * sensitivity) > 0 && cam.orthographicSize + (-1 * Input.GetAxis("Mouse ScrollWheel") * sensitivity)< maxZoomSize)
        {
            cam.orthographicSize += -1 * Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            Vector3 newMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position -= newMouse-oldMouse;
        }
	}
}
