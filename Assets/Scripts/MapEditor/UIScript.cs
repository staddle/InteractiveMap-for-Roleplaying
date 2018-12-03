using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    public GameObject moveCursor0;
    public GameObject moveCursor1;
    public GameObject squareCursor0;
    public GameObject squareCursor1;
    public GameObject circleCursor0;
    public GameObject circleCursor1;
    public GameObject black0;
    public GameObject black1;
    public GameObject black2;
    public GameObject black3;
    public GameObject black4;
    public bool isMoveCursorActive = true;
    public bool isSquareCursorActive = false;
    public bool isCircleCursorActive = false;
    public int colorSelected = 0;
    int colorActive;

    // Use this for initialization
    void Start()
    {
        isMoveCursorActive = true;
        isSquareCursorActive = false;
        colorSelected = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onColorClicked(int color)
    {
        disableAllButtons();
        colorSelected = color;
        colorBG(color);
    }

    public void onMoveClicked0()
    {
        disableAllButtons();
        //moveCursor0.SetActive(false);
        moveCursor1.SetActive(true);
        isMoveCursorActive = true;
    }

    public void onMoveClicked1()
    {
        moveCursor1.SetActive(false);
        moveCursor0.SetActive(true);
        isMoveCursorActive = false;
    }

    public void onSquareClicked0()
    {
        disableAllButtons();;
        squareCursor1.SetActive(true);
        isSquareCursorActive = true;
    }

    public void onSquareClicked1()
    {
        squareCursor1.SetActive(false);
        squareCursor0.SetActive(true);
        isSquareCursorActive = false;
    }

    public void onCircleClicked0()
    {
        disableAllButtons();
        circleCursor1.SetActive(true);
        isCircleCursorActive = true;
    }

    public void onCircleClicked1()
    {
        circleCursor1.SetActive(false);
        circleCursor0.SetActive(true);
        isCircleCursorActive = false;
    }

    void colorBG(int color)
    {
        if(color == -1)
        {
            black0.SetActive(false);
            black1.SetActive(false);
            black2.SetActive(false);
            black3.SetActive(false);
            black4.SetActive(false);
            colorSelected = -1;
        }
        else
        {
            switch (color)
            {
                case 0:
                    black0.SetActive(true);
                    break;
                case 1:
                    black1.SetActive(true);
                    break;
                case 2:
                    black2.SetActive(true);
                    break;
                case 3:
                    black3.SetActive(true);
                    break;
                case 4:
                    black4.SetActive(true);
                    break;
                default:
                    black0.SetActive(true);
                    break;
            }
        }
    }

    void disableAllButtons()
    {
        colorBG(-1);
        onSquareClicked1();
        onMoveClicked1();
        onCircleClicked1();
    }
}
