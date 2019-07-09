using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSurfaceControl : MonoBehaviour
{
    public GameObject waterPlane;

    public GameObject WaterObj;
    Mesh mesh;
    Vector3[] vertices;
    Vector3[] initialVerts;
    Vector3 normal;

    // Start is called before the first frame update
    void Start()
    {
        mesh = WaterObj.GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        initialVerts = vertices;
    }

    // Update is called once per frame
    void Update()
    {
        normal = CalculateWaterNormal(waterPlane.transform.position, transform.position);
        
        for (int i = 0; i < vertices.Length; i++)
        {

            
            if(vertices[i].y != -0.5)
            {
                
                vertices[i] = transform.TransformPoint(initialVerts[i]);//+new Vector3(1,1,1);
                //vertices[i] = ProjectVertexToPlane(vertices[i], transform.TransformDirection(normal));
                //vertices[i] = WaterObj.transform.InverseTransformPoint( vertices[i]);//transform.InverseTransformPoint(vertices[i]);
            }

        }
        mesh.vertices = vertices;
        //Debug.Log(initialVerts[5]);
    }

    private Vector3 CalculateWaterNormal(Vector3 from, Vector3 to)
    {
        Vector3 normal = (from - to).normalized;
        waterPlane.transform.up = normal;
        return normal;
    }

    private Vector3 ProjectVertexToPlane(Vector3 vert, Vector3 normal)
    {
        return Vector3.ProjectOnPlane(vert, normal);
    }
}
