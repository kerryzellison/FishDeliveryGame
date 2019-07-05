using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 waypointPos;
    public Quaternion waypointRot;
    public bool waypointDisabled = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDisable() {
        waypointPos = transform.position;
        waypointRot = transform.rotation;
        waypointDisabled = true;
        Debug.Log("Waypoint Disabled");
    }
}
