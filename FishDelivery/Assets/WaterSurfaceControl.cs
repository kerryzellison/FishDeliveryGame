using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSurfaceControl : MonoBehaviour
{

    public GameObject splashFX;
    GameObject fish;
    public GameObject waterLevel;
    public GameObject top;
    public GameObject WaterObj;
    Vector3 surfacePos;

    Vector3 topPos;
    Vector3 ballPos;
    
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
        topPos = WaterObj.transform.InverseTransformPoint(top.transform.position);
        surfacePos = WaterObj.transform.InverseTransformPoint(waterLevel.transform.position);
        ballPos = WaterObj.transform.InverseTransformPoint(transform.position);
        normal = CalculateWaterNormal(topPos, ballPos);

        Debug.DrawRay(surfacePos,normal, Color.red, 1);
        
        for (int i = 0; i < vertices.Length; i++)
        {

            
            if(vertices[i].y != -0.5)
            {
                vertices[i] = initialVerts[i];//+new Vector3(1,1,1);

                Vector3 u = ((vertices[i]+ new Vector3(0,1,0))-vertices[i]);
                Vector3 w = vertices[i] - surfacePos;
                Debug.DrawRay(vertices[i], w, Color.blue,1);
                float scalar = (Vector3.Dot(-normal, w))/Vector3.Dot(normal,u);
                vertices[i] += scalar * u;
                
                if (vertices[i].y > topPos.y)
                {
                    vertices[i].y = topPos.y;

                    if (waterLevel.transform.childCount ==0)
                    {
                        //Debug.Break();//("Lost Fish");
                        LoseFish();  
                    }
                   
                    //SplashWater(vertices[i], topPos-  vertices[i]);
                   // LowerWaterLevel();
                }
                else
                {
                    //RemoveSplashWater(vertices[i]);
                }
                if (vertices[i].y < -0.5)
                {
                    vertices[i].y = -0.49f;
                }
            }

        }
        mesh.vertices = vertices;
    }

    private Vector3 CalculateWaterNormal(Vector3 from, Vector3 to)
    {
        Vector3 normal = (from - to).normalized;
        waterLevel.transform.up = normal;
        return normal;
    }

    private Vector3 ProjectVertexToPlane(Vector3 vert, Vector3 normal)
    {
        return Vector3.zero;
    }
 

    private void LoseFish()
    {
        fish = Instantiate(splashFX, top.transform.position, Quaternion.identity,waterLevel.transform);
        Destroy(fish,5);
        
    }

    private void LowerWaterLevel()
    {
        waterLevel.transform.position += -waterLevel.transform.up *Time.deltaTime;
        Debug.DrawRay(waterLevel.transform.position, waterLevel.transform.up,Color.red,1);
        Debug.Log("Splash Water");
    }
}
