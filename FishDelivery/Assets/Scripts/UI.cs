using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private GameObject car;
    private RigidBodyInfo rigidBodyInf;
    private ResourceSystem resourceSystem;

    [Header("Settings")]
    public bool inGameHub = false;

    [Header("UI Objects")]
    public Text speedText;
    public Text fishText;
    public Text timeText;
    public Text boostText;
    public Text moneyText1;
    public Text moneyText2;
    public Image overlay;
    public Sprite[] spriteOverlay;

    private float speed = 0;
    private float time = 0;

    void Start()
    {
            car = GameObject.Find("Wheel Collider Car");
            resourceSystem = GameObject.Find("ResourceManager").GetComponent<ResourceSystem>();
            rigidBodyInf = car.GetComponent<RigidBodyInfo>();
            moneyText1.text = resourceSystem.GetMoney().ToString() + "¥";

        if (inGameHub)
        {
            // Set up for when in the game hub
            overlay.sprite = spriteOverlay[0];
            boostText.gameObject.SetActive(false);
            fishText.gameObject.SetActive(false);
            timeText.gameObject.SetActive(false);
            moneyText1.gameObject.SetActive(false);
            moneyText2.gameObject.SetActive(true);
        }
    }

    void Update()
    {
        speed = (int)rigidBodyInf.speed * 3.6f;
        speed = (int)speed;
        speedText.text = speed.ToString() + " km/h";

        if (!inGameHub)
        {
            time = (int)Time.time;
            timeText.text = time + " sec";
        }

    }
}
