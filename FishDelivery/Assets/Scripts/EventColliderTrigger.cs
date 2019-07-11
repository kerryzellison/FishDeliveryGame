using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventColliderTrigger : MonoBehaviour
{
    private GameObject player;
    public UnityEvent thisEvent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == player.gameObject)
        {
            if (thisEvent != null)
            {
                Debug.Log("Collided with event trigger!");
                thisEvent.Invoke();

            } else
            {
                Debug.Log("No events to trigger!");
            }
            
        }
    }

}
