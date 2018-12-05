using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridScript : MonoBehaviour {

    public CreateMenu createMenu;
    public GameObject Canvas;
    Grid grid;
    UIScript uiScript;
    public List<Panel> panelList;
    public int xV, yV;
    public LineFactory lineFactory;
    public float lineThiccccccness = 0.03f;
    public float theta_scale = 0.01f;        //Set lower to add more points
    public int size; //Total number of points in circle
    public float radius = 3f;
    Vector2 startPoint, endPoint;
    Line line1, line2, line3, line4;
    Vector3Int oldMarkedStart, oldMarkedEnd;
    LineRenderer lineRenderer;
    Vector3 startCircle, endCircle;
    bool end = false;
    // Use this for initialization
    void Start() { //anchorPoint is bottom-left
        
        float sizeValue = (2.0f * Mathf.PI) / theta_scale;
        size = (int)sizeValue;
        size++;
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.black;
        lineRenderer.endColor = Color.black;
        lineRenderer.startWidth = 0.1f;
        lineRenderer.endWidth = 0.1f;
        lineRenderer.positionCount = size;
        lineRenderer.sortingOrder = 1;


        end = false;
        xV = PlayerPrefs.GetInt("x-Value");
        yV = PlayerPrefs.GetInt("y-Value");
        grid = GetComponentInParent<Grid>();
        panelList = new List<Panel>();
        uiScript = Canvas.GetComponent<UIScript>();
        GameObject panelObjects = new GameObject("panelObjects");
        for (int x = -((int)((double)xV/2)+(xV%2)); x <= (int)((double)xV/2); x++) //makes it so that it iterates from -x/2 (+1 if x = odd) to +x/2 // ex: x=21 ==> iterates from -11 to +10
        {
            for (int y = -((int)((double)yV / 2) + (yV % 2)); y <= (int)((double)yV / 2); y++)
            {
                GameObject newGO = new GameObject(x + "/" + y);
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
        if (!uiScript.isMoveCursorActive && Input.GetKey(KeyCode.Mouse0) && !EventSystem.current.IsPointerOverGameObject() && uiScript.colorSelected != -1)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.z = 0;
            Vector3Int cellPos = grid.WorldToCell(worldPoint);
            if (cellPos.x >= -((int)((double)xV / 2) + (xV % 2)) && cellPos.x <= (int)((double)xV / 2) && cellPos.y >= -((int)((double)yV / 2) + (yV % 2)) && cellPos.y <= (int)((double)yV / 2))
            {
                //Debug.Log(cellPos);
                /**Collider2D[] colliders = Physics2D.OverlapBoxAll(new Vector2(cellPos.x, cellPos.y), new Vector2(float.Epsilon, float.Epsilon), 0f);
                if (colliders.Length > 0)
                {
                    Debug.Log(colliders[0].transform);
                    colliders[0].GetComponent<SpriteScript>().changeColor(uiScript.colorSelected);
                } **/
                GameObject.Find(cellPos.x + "/" + cellPos.y).GetComponent<SpriteScript>().changeColor(uiScript.colorSelected);
            }
        }
        if(uiScript.isSquareCursorActive && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0))
            {
                clearLines();
                var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                
                line1 = lineFactory.GetLine(pos, pos, lineThiccccccness, Color.black);
                line2 = lineFactory.GetLine(pos, pos, lineThiccccccness, Color.black);
                line3 = lineFactory.GetLine(pos, pos, lineThiccccccness, Color.black);
                line4 = lineFactory.GetLine(pos, pos, lineThiccccccness, Color.black);
                startPoint = line1.start;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                line1 = null;
                endPoint = line3.end;
                Debug.Log(startPoint + " " + endPoint);
                markPanelsRect(startPoint, endPoint);
                clearLines();
            }

            if(line1 != null)
            {
                line1.end = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, line1.start.y);
                line2.end = new Vector2(line2.start.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                line3.start = line1.end;
                line4.start = line2.end;
                line3.end = new Vector2(line3.start.x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
                line4.end = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, line4.start.y);
            }
        }

        if(uiScript.isCircleCursorActive && !EventSystem.current.IsPointerOverGameObject())
        {
            //bool end = false;
            if (Input.GetMouseButtonDown(0))
            {
                end = false;
                startCircle = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }else if (Input.GetMouseButtonUp(0))
            {
                end = true; //draw circle finally and mark any panels in circle
                markPanelsCirc(new Vector3(startCircle.x + radius * -Mathf.Sign(startCircle.x - endCircle.x), startCircle.y + radius * -Mathf.Sign(startCircle.y - endCircle.y),0), radius);
            }
            if (!end && Input.GetKey(KeyCode.Mouse0))
            {
                endCircle = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if(Mathf.Abs(startCircle.x-endCircle.x) < Mathf.Abs(startCircle.y - endCircle.y))
                {
                    radius = (float)0.5 * Mathf.Abs(startCircle.x - endCircle.x);
                }
                else
                {
                    radius = (float)0.5*Mathf.Abs(startCircle.y - endCircle.y);
                }
                Vector3 pos; //make dependent from mouse location
                float theta = 0f;
                for (int i = 0; i < size; i++)
                {
                    theta += (2.0f * Mathf.PI * theta_scale);
                    float x = radius * Mathf.Cos(theta);
                    float y = radius * Mathf.Sin(theta);
                    x += startCircle.x + radius * -Mathf.Sign(startCircle.x - endCircle.x);
                    y += startCircle.y + radius * -Mathf.Sign(startCircle.y - endCircle.y);
                    pos = new Vector3(x, y, 0);
                    lineRenderer.SetPosition(i, pos);
                }
            }
        }
	}

    public void markPanelsCirc(Vector3 m, float radius)
    {
        Vector3Int gridM = grid.WorldToCell(m);
        for(int x = gridM.x; x < gridM.x+radius; x++)
        {
            for(int y = gridM.y; y < gridM.y+radius; y++)
            {
                if ((x - gridM.x) * (x - gridM.x) + (y - gridM.y) * (y - gridM.y) <= radius * radius)
                {
                    GameObject.Find(x + "/" + y).GetComponent<SpriteScript>().markPanel();
                    GameObject.Find(gridM.x-x + "/" + y).GetComponent<SpriteScript>().markPanel();
                    GameObject.Find(x + "/" + (gridM.y-y)).GetComponent<SpriteScript>().markPanel();
                    GameObject.Find(gridM.x - x + "/" + (gridM.y - y)).GetComponent<SpriteScript>().markPanel();
                }
            }
        }
    }

    public void clearLines()
    {
        var activeLines = lineFactory.GetActive();

        foreach (var line in activeLines)
        {
            line.gameObject.SetActive(false);
        }
    }

    void markPanelsRect(Vector2 p1, Vector2 p2)
    {
        removeMarks();
        if (p1.x >= p2.x) {
            float x2 = p1.x;
            p1.x = p2.x;
            p2.x = x2;
        }

        if (p1.y >= p2.y)
        {
            float y2 = p1.y;
            p1.y = p2.y;
            p2.y = y2;
        }

        Vector3Int p1Int = grid.WorldToCell(p1);
        Vector3Int p2Int = grid.WorldToCell(p2);
        oldMarkedStart = p1Int;
        oldMarkedEnd = p2Int;
        Debug.Log(p1Int + " " + p2Int);
        for (int x=p1Int.x+1; x<p2Int.x; x++)
        {
            for(int y = p1Int.y+1; y<p2Int.y; y++)
            {
                GameObject.Find(x + "/" + y).GetComponent<SpriteScript>().markPanel();
            }
        }
    }

    void removeMarks()
    {
        for (int x = oldMarkedStart.x + 1; x < oldMarkedEnd.x; x++)
        {
            for (int y = oldMarkedStart.y + 1; y < oldMarkedEnd.y; y++)
            {
                GameObject.Find(x + "/" + y).GetComponent<SpriteScript>().unmarkPanel();
            }
        }
    }

    public void onClearButton()
    {
        Destroy(GameObject.Find("panelObjects"));
        Start();
    }
}
