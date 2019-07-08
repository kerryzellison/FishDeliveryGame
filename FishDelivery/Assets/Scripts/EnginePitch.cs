using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePitch : MonoBehaviour
{
    public AudioSource engineSound;
    private GameObject car;
    private RigidBodyInfo rigidBodyInf;

    void Start()
    {
        car = GameObject.Find("Wheel Collider Car");
        rigidBodyInf = car.GetComponent<RigidBodyInfo>();
    }

    void Update()
    {
        engineSound.pitch = (rigidBodyInf.speed/60 + 1);
    }
}
