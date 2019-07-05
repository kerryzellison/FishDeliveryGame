using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPosition : MonoBehaviour
{
    Vector3 lastWaypointPos;
    Quaternion lastWaypointRot;
    public WaypointInfo _waypointInfo;
    public TurnTheGameOn.ArrowWaypointer.WaypointController _wpController;
    public Transform currentRespawn;
    public TurnTheGameOn.ArrowWaypointer.Waypoint _waypoint;
    public TurnTheGameOn.ArrowWaypointer.WaypointController.WaypointComponents[] currentRespawnArr;
    int waypointIterator;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointPos = transform.position;
        lastWaypointRot = transform.rotation;
        //currentTarget = _wpController.currentWaypoint;
        currentRespawnArr = _wpController.waypointList;

    }

    // Update is called once per frame
    void Update()
    {
        if(_waypointInfo.waypointDisabled) {
            lastWaypointPos = _waypointInfo.waypointPos;
            lastWaypointRot = _waypointInfo.waypointRot;
            _waypointInfo.waypointDisabled = false;
            Debug.Log(lastWaypointPos + "" + "Waypoint location loaded");
            _waypoint = currentRespawnArr[waypointIterator].waypoint;
            
        }
        // Iterate through currentRespawnArr[] to find previous waypoint from currentwaypoint. 
        
        if(Input.GetKey(KeyCode.H )/* && currentTarget.position != _wpController.currentWaypoint.position */) {
            //transform.position = currentTarget.position;
            transform.rotation = lastWaypointRot;
            Debug.Log("Reset pressed");
        }
    }

}
