using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public AudioSource waterSplash;
    public GameObject water;
    public ResourceSystem resourceSystem;

    [HideInInspector]
    public int missionMoneyAmount = 0;
    public int fishMax, fishLeft;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == water.gameObject)
        {
            waterSplash.Play();
            ResetMission();
            Debug.Log("Collided with water");
        }
    }

    public void ResetMission()
    {
        SceneManager.LoadScene(Application.loadedLevel); //Load scene called Game
    }

    public void missionMoneyAdd(int amount)
    {
        missionMoneyAmount = missionMoneyAmount + amount;
    }

    public void lostFish()
    {
        if (fishLeft >= 0) 
        fishLeft--;
    }
}
