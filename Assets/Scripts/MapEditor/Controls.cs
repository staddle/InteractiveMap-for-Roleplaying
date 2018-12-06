using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Controls : MonoBehaviour {

    public int sensitivity = 5;
    public int maxZoomSize = 25;
    public double moveXMultiplier = 15;
    public double moveYMultiplier = 15;
    UIScript uiScript;
    public GameObject canvas;
    Vector3 oldPos;
    bool oldPosCorrect = false;
	// Use this for initialization
	void Start () {
        uiScript = canvas.GetComponent<UIScript>();
        //oldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

        if (!EventSystem.current.IsPointerOverGameObject() && ((uiScript.isMoveCursorActive && Input.GetKey(KeyCode.Mouse0)) || (!uiScript.isMoveCursorActive && Input.GetKey(KeyCode.Mouse1))))
        {
            if (Input.GetAxis("Mouse X")!=0)
            {
                if (oldPosCorrect)
                {
                    //cam.transform.position -= new Vector3((float)(Input.GetAxis("Mouse X")*Time.deltaTime*moveXMultiplier), 0, 0);
                    cam.transform.position += new Vector3(oldPos.x - Camera.main.ScreenToWorldPoint(Input.mousePosition).x, 0, 0);
                    Debug.Log(oldPos + " " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                
            }

            if (Input.GetAxis("Mouse Y") != 0)
            {
                if (oldPosCorrect)
                {
                    //cam.transform.position -= new Vector3(0, (float)(Input.GetAxis("Mouse Y") * Time.deltaTime * moveYMultiplier), 0);
                    cam.transform.position += new Vector3(0, oldPos.y - Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
                    Debug.Log(oldPos + " " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
                }
                
                
            }
            oldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            oldPosCorrect = true;
        }

        if((uiScript.isMoveCursorActive && Input.GetMouseButtonUp(0)) || (!uiScript.isMoveCursorActive && Input.GetMouseButtonUp(1)))
        {
            oldPosCorrect = false;
        }
	}

    
}
