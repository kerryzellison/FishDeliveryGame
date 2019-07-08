using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSurfaceControl : MonoBehaviour
{
    public GameObject waterPlane;

    public GameObject WaterObj;
    Mesh mesh;
    List< Vector3> vertices;
    Vector3 normal;

    // Start is called before the first frame update
    void Start()
    {
        mesh = WaterObj.GetComponent<MeshFilter>().mesh;
        vertices = GetTopCornerVertices(mesh);
    }

    // Update is called once per frame
    void Update()
    {
        normal = CalculateWaterNormal(waterPlane.transform.position, transform.position);
        
        for (int i = 0; i < vertices.Count; i++)
        {
            //vertices[i].y;
        }

    }

    private Vector3 CalculateWaterNormal(Vector3 from, Vector3 to)
    {
        Vector3 normal = (from - to).normalized;
        waterPlane.transform.up = normal;
        return normal;
    }

    private List<Vector3> GetTopCornerVertices( Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;

        List< Vector3> topVerts= new List<Vector3>();

        for (int i = 0; i < vertices.Length; i++)
        {
            if (vertices[i].y == 0.5)
            {
                topVerts.Add(transform.TransformPoint (vertices[i]));   
            }
        }


        return topVerts;

    }
}
