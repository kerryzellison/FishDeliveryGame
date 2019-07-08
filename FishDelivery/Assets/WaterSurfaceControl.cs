using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSurfaceControl : MonoBehaviour
{
    public GameObject waterPlane;
    Vector3 normal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        normal = waterPlane.transform.position - transform.position;

        waterPlane.transform.up = normal;
    }
}
