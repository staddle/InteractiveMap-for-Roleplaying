using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POI {

    public string _name, _desc;
    public Vector2 _pos;
    public List<string> _tags;
    public Color _color;
    public Transform _obj;

    public POI(Transform obj, string name, Vector2 position, string desc, Color color, List<string> tags)
    {
        _obj = obj;
        _name = name; _desc = desc;
        _pos = position;
        _tags = tags;
        _color = color;
    }


}
