using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionController : MonoBehaviour
{
    Animator anim;
    private string sceneToLoad;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToNextScene(string sceneName)
    {
        Debug.Log("Tried to fade to scene: " + sceneName);
        sceneToLoad = sceneName;
        anim.SetTrigger("FadeOut");
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}