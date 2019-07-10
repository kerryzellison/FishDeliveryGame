using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer2D : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        /// Rotate towards target on x and y axis, but maintain z rotation
        transform.LookAt(new Vector3(target.position.x, transform.position.y, target.position.z));
        //transform.eulerAngles = new Vector3(target.eulerAngles.x, target.eulerAngles.y, transform.eulerAngles.z);
    }
}
