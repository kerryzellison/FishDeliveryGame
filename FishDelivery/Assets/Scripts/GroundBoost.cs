using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoost : MonoBehaviour
{
    //public RigidBodyInfo rbInfo;
    public Rigidbody carRB;
    float boostDuration = 2000f, boostMultiplier = 2f;
    private Coroutine boostCoroutine;
    private bool boostOnce = true;
    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
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
        if(boostOnce) {
        carRB.velocity = carRB.velocity * boostMultiplier;
        boostOnce = false;           
        }

        Debug.Log("Pad boosted" + boostMultiplier);
        // speed * boostMultiplier
        yield return new WaitForSeconds(boostDuration);
        // speed / boostMultiplier
        carRB.velocity = carRB.velocity / boostMultiplier;
        boostOnce = true;
        
        
    }

    public void nitroBoost() {
        carRB.velocity = carRB.velocity * boostMultiplier;
    }

    void StopBoost() {
        if(boostCoroutine == null) {
            StopCoroutine(BoostPad());
            boostCoroutine = null;
        }
    }
}
