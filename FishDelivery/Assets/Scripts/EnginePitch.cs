using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePitch : MonoBehaviour
{
    public AudioSource engineSound;
    public GameObject car;
    private RigidBodyInfo rigidBodyInf;

    void Start()
    {
        if (car != null)
        {
            rigidBodyInf = car.GetComponent<RigidBodyInfo>();
        }
        else
        {
            Debug.Log("Car GameObject not attached to EnginePitch script in SoundManager!");
        }
        
    }

    void Update()
    {
        engineSound.pitch = (rigidBodyInf.speed/60 + 1);
    }
}
