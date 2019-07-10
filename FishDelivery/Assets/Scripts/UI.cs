using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;
    public GroundBoost nitroBoost;
    public MissionManager missionManager;
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
    private int currentFishAmount = 0;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        resourceSystem = GetComponent<ResourceSystem>();
        rigidBodyInf = player.GetComponent<RigidBodyInfo>();
        moneyText2.text = resourceSystem.GetMoney().ToString() + "¥";
        moneyText1.text = "+0¥";
        currentFishAmount = missionManager.fishLeft;
        fishText.text = currentFishAmount + "/" + missionManager.fishMax;

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
        speed = rigidBodyInf.speed * 3.6f;
        speed = (int)speed;
        speedText.text = speed.ToString() + " km/h";

        if (!inGameHub)
        {
            time = (int)Time.time;
            timeText.text = time + " sec";
            boostText.text = "Nitro: " + NitroPercentage().ToString() + "%";
            moneyText1.text = "+" + missionManager.missionMoneyAmount.ToString() + "¥";
            if (missionManager.fishLeft != currentFishAmount)
            {
                // Flash UI red for a moment YYY
                fishText.text = missionManager.fishLeft + "/" + missionManager.fishMax;
                currentFishAmount = missionManager.fishLeft;
                StartCoroutine(UpdateFishCount());
            }
        }

    }

    IEnumerator UpdateFishCount()
    {
        fishText.color = Color.red;
        yield return new WaitForSeconds(2);
        fishText.color = new Color(0.2924528f, 0.2924528f, 0.2924528f, 0.8470588f);
    }

    private int NitroPercentage()
    {
        float nitro = (nitroBoost._nitroAmount / nitroBoost.nitroMax) * 100;
        return (int)nitro;
    }
}
