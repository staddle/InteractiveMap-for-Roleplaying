using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel {

    public int x, y;
    public GameObject sprite;
    public int c;

    public Panel(GameObject panelObject, int xCoord, int yCoord, int color)
    {
        sprite = panelObject;
        x = xCoord;
        y = yCoord;
        c = color;
    }
}
