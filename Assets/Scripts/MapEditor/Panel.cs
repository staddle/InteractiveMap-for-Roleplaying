using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel {

    public int x, y;
    public GameObject sprite;

    public Panel(GameObject panelObject, int xCoord, int yCoord)
    {
        sprite = panelObject;
        x = xCoord;
        y = yCoord;
    }
}
