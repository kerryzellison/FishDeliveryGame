using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionManager : MonoBehaviour
{
    public AudioSource waterSplash;
    public GameObject water;

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with something)");

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
}
