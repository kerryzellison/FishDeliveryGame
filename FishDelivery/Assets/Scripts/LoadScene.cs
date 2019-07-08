using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    Animator anim;
    private string sceneToLoad;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToNextScene(string sceneName)
    {
        if (sceneToLoad == null)
        {
            Debug.Log("Tried to fade to scene: " + sceneName);
            sceneToLoad = sceneName;
            anim.SetTrigger("FadeOut");
        }
        else
        {
            Debug.Log("SceneToLoad was not null, but instead: " + sceneToLoad);
            anim.SetTrigger("FadeOut");
        }
    }

    public void LoadNextScene()
    {
        Debug.Log("Loading next scene");
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
        sceneToLoad = null;
    }

    public void SetSceneToLoad(string sceneName)
    {
        Debug.Log("Set next mission to: " + sceneName);
        sceneToLoad = sceneName;
    }
}