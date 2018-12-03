using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class createRectangle : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Vector2[] vertices2D = new Vector2[] {
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0),
            new Vector2(0,0),
        };

        Vector3[] vertices3D = System.Array.ConvertAll<Vector2, Vector3>(vertices2D, v => v);
        var triangulator = new Triangulator(vertices2D);
        var indices = triangulator.Triangulate();
        var colors = Enumerable.Range(0, vertices3D.Length)
            .Select(i => Random.ColorHSV())
            .ToArray();
        var mesh = new Mesh { vertices = vertices3D, triangles = indices, colors = colors };
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
        var meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = new Material(Shader.Find("Sprites/Default"));
        var filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
