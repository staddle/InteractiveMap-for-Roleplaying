using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour {

    public int renderDistance = 15; //TODO: abhängig von angezeigtem Bildbereich machen
    public GameObject Canvas;
    Grid grid;
    UIScript uiScript;
    public List<Panel> panelList;
	// Use this for initialization
	void Start () { //anchorPoint is bottom-left
        grid = GetComponentInParent<Grid>();
        panelList = new List<Panel>();
        uiScript = Canvas.GetComponent<UIScript>();
        GameObject panelObjects = new GameObject("panelObjects");
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int y = -renderDistance; y <= renderDistance; y++)
            {
                GameObject newGO = new GameObject(x + "-" + y);
                newGO.AddComponent<SpriteRenderer>();
                newGO.AddComponent<SpriteScript>();
                SpriteRenderer SR = newGO.GetComponent<SpriteRenderer>();
                SR.sprite = SpriteScript.getSprite(0);
                
                newGO.AddComponent<BoxCollider2D>();
                newGO.transform.position = grid.CellToWorld(new Vector3Int(x, y, 0));
                newGO.transform.parent = panelObjects.transform;
                panelList.Add(new Panel(newGO, x, y));
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!uiScript.isMoveCursorActive && Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.z = 0;
            Vector3Int cellPos = grid.WorldToCell(worldPoint);
            Debug.Log(cellPos);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector2(cellPos.x, cellPos.y), new Vector2(float.Epsilon, float.Epsilon), 0f);
            if (colliders.Length > 0)
            {
                Debug.Log(colliders[0].transform);
                colliders[0].GetComponent<SpriteScript>().changeColor(uiScript.colorSelected);
            } 
        }
	}

    public void onClearButton()
    {
        Destroy(GameObject.Find("panelObjects"));
        grid = GetComponentInParent<Grid>();
        panelList = new List<Panel>();
        uiScript = Canvas.GetComponent<UIScript>();
        GameObject panelObjects = new GameObject("panelObjects");
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int y = -renderDistance; y <= renderDistance; y++)
            {
                GameObject newGO = new GameObject(x + "-" + y);
                newGO.AddComponent<SpriteRenderer>();
                newGO.AddComponent<SpriteScript>();
                SpriteRenderer SR = newGO.GetComponent<SpriteRenderer>();
                SR.sprite = SpriteScript.getSprite(0);

                newGO.AddComponent<BoxCollider2D>();
                newGO.transform.position = grid.CellToWorld(new Vector3Int(x, y, 0));
                newGO.transform.parent = panelObjects.transform;
                panelList.Add(new Panel(newGO, x, y));
            }
        }
    }
}
