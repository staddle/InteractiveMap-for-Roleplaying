﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScript : MonoBehaviour {

    public Sprite blueSquare;
    public Sprite greenSquare;
    public Sprite yellowSquare;
    public Sprite brownSquare;
    public Sprite blueGreySquare;
    // Use this for initialization
    void Start () {
        blueSquare = Resources.Load<Sprite>("Sprites/blue-square");
        greenSquare = Resources.Load<Sprite>("Sprites/green-square");
        yellowSquare = Resources.Load<Sprite>("Sprites/yellow-square");
        brownSquare = Resources.Load<Sprite>("Sprites/brown-square");
        blueGreySquare = Resources.Load<Sprite>("Sprites/blueGrey-square");
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void changeColor(int color) //0=blue 1=blueGrey 2=green 3=brown 4=yellow
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        switch (color)
        {
            case 0:
                spriteRenderer.sprite = blueSquare;
                break;
            case 1:
                spriteRenderer.sprite = blueGreySquare;
                break;
            case 2:
                spriteRenderer.sprite = greenSquare;
                break;
            case 3:
                spriteRenderer.sprite = brownSquare;
                break;
            case 4:
                spriteRenderer.sprite = yellowSquare;
                break;
        }
    }

    public static Sprite getSprite(int color)
    {
        switch (color)
        {
            case 0:
                return Resources.Load<Sprite>("Sprites/blue-square");
            case 1:
                return Resources.Load<Sprite>("Sprites/blueGrey-square");
            case 2:
                return Resources.Load<Sprite>("Sprites/green-square");
            case 3:
                return Resources.Load<Sprite>("Sprites/brown-square");
            case 4:
                return Resources.Load<Sprite>("Sprites/yellow-square");
            default:
                return Resources.Load<Sprite>("Sprites/blue-square");
        }
    }
}