using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private GameObject car;
    private RigidBodyInfo rigidBodyInf;
    private ResourceSystem resourceSystem;

    public Text speedText;
    float speed = 0;

    void Start()
    {
            car = GameObject.Find("Wheel Collider Car");
            resourceSystem = GameObject.Find("ResourceManager").GetComponent<ResourceSystem>();
            rigidBodyInf = car.GetComponent<RigidBodyInfo>();
    }

    void Update()
    {
        speed = (int)rigidBodyInf.speed * 3.6f;
        speedText.text = speed.ToString() + " km/h";
    }
}
