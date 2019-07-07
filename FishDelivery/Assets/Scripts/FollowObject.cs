using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{

    public GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        if (!obj)
        {
            Debug.Log("enter");
            obj = GameObject.Find("Tank Frame");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = obj.transform.position;
        transform.rotation = obj.transform.rotation;
    }
}
