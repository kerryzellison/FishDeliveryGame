using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnginePitch : MonoBehaviour
{
    public AudioSource engineSound;
    public GameObject player;
    private RigidBodyInfo rigidBodyInf;

    void Start()
    {
        if (player = GameObject.FindGameObjectWithTag("Player"))
            Debug.Log("EnginePitch Script: Player object found");

        if (player != null)
        {
            rigidBodyInf = player.GetComponent<RigidBodyInfo>();
            engineSound = player.GetComponent<AudioSource>();
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
