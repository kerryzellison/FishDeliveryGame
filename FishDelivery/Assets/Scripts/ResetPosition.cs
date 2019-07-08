using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResetPosition : MonoBehaviour
{
    Vector3 lastWaypointPos;
    Quaternion lastWaypointRot;
    //public WaypointInfo _waypointInfo;
    [HideInInspector] public TurnTheGameOn.ArrowWaypointer.WaypointController _wpController;
    public Transform currentRespawn;
    public TurnTheGameOn.ArrowWaypointer.Waypoint _waypoint;
    [HideInInspector] public TurnTheGameOn.ArrowWaypointer.WaypointController.WaypointComponents[] currentRespawnArr;
    int waypointIterator;

    private bool hitFirstWaypoint, doOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        lastWaypointPos = transform.position;
        lastWaypointRot = transform.rotation;
        //currentTarget = _wpController.currentWaypoint;
        currentRespawnArr = _wpController.waypointList;
        doOnce = false;
        hitFirstWaypoint = false;
    }


    // Update is called once per frame
    void Update()
    {
        /* if(_waypointInfo.waypointDisabled) {
            lastWaypointPos = _waypointInfo.waypointPos;
            lastWaypointRot = _waypointInfo.waypointRot;
            _waypointInfo.waypointDisabled = false;
            Debug.Log(lastWaypointPos + " " + "Waypoint location loaded");
            _waypoint = currentRespawnArr[waypointIterator].waypoint;
            
        } */

        if(currentRespawnArr[waypointIterator].waypoint.enabled) {
            _waypoint = currentRespawnArr[waypointIterator].waypoint;
        }
        
        if(Input.GetKey(KeyCode.H) && hitFirstWaypoint/* && currentTarget.position != _wpController.currentWaypoint.position */) {
            transform.position = _waypoint.transform.position;
            transform.rotation = _waypoint.transform.rotation;
            Debug.Log("Reset pressed " + "Current target is " + _waypoint.name + " waypointIterator = " + waypointIterator);
            
        }
        else if(!hitFirstWaypoint && Input.GetKeyDown(KeyCode.H)) {
            transform.position = lastWaypointPos;
            transform.rotation = lastWaypointRot;
        }
    }

    void OnTriggerEnter(Collider other) {
        hitFirstWaypoint = true;

        
        // First time good in same level, second time resets 1-2 waypoints behind preferred.
        // Switches between 1-2 in other playthroughs.
        // Sometimes hitFirstWaypoint not triggered? 
        // Maybe other.enabled not good, since it might turn off before getting to statement
        if(/* other != null &&  */other.name.Contains("Waypoint") && other.enabled) {
                waypointIterator++;
             if(!doOnce) {
            waypointIterator = 0;
            doOnce = true;
            } 
            
            Debug.Log("Waypoint hit" + _waypoint.name);
            
        }
    }

}
