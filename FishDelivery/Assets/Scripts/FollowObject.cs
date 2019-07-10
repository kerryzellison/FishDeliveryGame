using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public GameObject followPos;
    Rigidbody rb;
    Vector3 deltaPos;
    public float multiplier;
    public float maxDistance;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        transform.parent=null;
    }

    // Update is called once per frame
    void Update()
    {
        
        deltaPos = followPos.transform.position-transform.position;

        if (deltaPos.magnitude > maxDistance)
        {
            transform.position = followPos.transform.position - deltaPos.normalized*maxDistance;
        }

        rb.AddForce(deltaPos*multiplier*Time.deltaTime);
    }
}
