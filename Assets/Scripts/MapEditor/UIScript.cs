using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public GameObject moveCursor0;
    public GameObject moveCursor1;
    public bool isMoveCursorActive = true;
    public int colorSelected = 0;

    // Use this for initialization
    void Start()
    {
        isMoveCursorActive = true;
        colorSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onColorClicked(int color)
    {
        colorSelected = color;
    }

    public void onMoveClicked0()
    {
        moveCursor0.SetActive(false);
        moveCursor1.SetActive(true);
        isMoveCursorActive = true;
    }

    public void onMoveClicked1()
    {
        moveCursor1.SetActive(false);
        moveCursor0.SetActive(true);
        isMoveCursorActive = false;
    }
}
