using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoost : MonoBehaviour
{
    public RigidBodyInfo rbInfo;
    public float boostDuration, boostMultiplier;
    private Coroutine boostCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.tag == "BoostPad") {
            StopBoost();
            boostCoroutine = StartCoroutine(BoostPad());
        }
    }

    IEnumerator BoostPad() 
    {
        // speed * boostMultiplier
        yield return new WaitForSeconds(boostDuration);
        // speed / boostMultiplier
        
        
    }

    void StopBoost() {
        if(boostCoroutine == null) {
            StopCoroutine(BoostPad());
            boostCoroutine = null;
        }
    }
}
