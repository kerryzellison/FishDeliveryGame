using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    // public AudioSource waterSplash;
    public GameObject water;
    public ResourceSystem resourceSystem;
    public UI ui;

    [HideInInspector]
    public int missionMoneyAmount = 0;
    public int fishMax, fishLeft;
    public int fishValue = 100;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == water.gameObject)
        {
            // waterSplash.Play();
            ResetMission();
            Debug.Log("Collided with water");
        }
    }

    public void ResetMission()
    {
        SceneManager.LoadScene(Application.loadedLevel); //Load scene called Game
    }

    public void MissionMoneyAdd(int amount)
    {
        missionMoneyAmount = missionMoneyAmount + amount;
    }

    public void LostFish()
    {
        if (fishLeft > 0)
        {
            fishLeft--;
        } else
        {
            ResetMission();
        }

    }

    public void MissionAward()
    {
        missionMoneyAmount = missionMoneyAmount + (fishValue * fishLeft);
        resourceSystem.AddMoney(missionMoneyAmount);
        ui.inGameHub = true;
    }
}
