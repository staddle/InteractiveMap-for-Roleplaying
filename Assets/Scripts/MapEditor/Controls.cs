using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {

    public int sensitivity = 5;
    public int maxZoomSize = 25;
    public double moveXMultiplier = 15;
    public double moveYMultiplier = 15;
    UIScript uiScript;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        uiScript = canvas.GetComponent<UIScript>();
	}
	
	// Update is called once per frame
	void Update () {
        Camera cam = GetComponent<Camera>();
        
        if (Input.GetAxis("Mouse ScrollWheel") != 0 && cam.orthographicSize+ (-1 * Input.GetAxis("Mouse ScrollWheel") * sensitivity) > 0 && cam.orthographicSize + (-1 * Input.GetAxis("Mouse ScrollWheel") * sensitivity)< maxZoomSize)
        {
            Vector3 oldMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            cam.orthographicSize += -1 * Input.GetAxis("Mouse ScrollWheel") * sensitivity;
            Vector3 newMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            cam.transform.position -= newMouse-oldMouse;
        }

        if (uiScript.isMoveCursorActive && Input.GetKey(KeyCode.Mouse0))
        {
            if(Input.GetAxis("Mouse X")!=0)
            {
                cam.transform.position -= new Vector3((float)(Input.GetAxis("Mouse X")*Time.deltaTime*moveXMultiplier), 0, 0);
            }

            if (Input.GetAxis("Mouse Y") != 0)
            {
                cam.transform.position -= new Vector3(0, (float)(Input.GetAxis("Mouse Y") * Time.deltaTime * moveYMultiplier), 0);
            }
        }
	}

    
}
