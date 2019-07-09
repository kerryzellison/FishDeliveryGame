using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoost : MonoBehaviour
{
    //public RigidBodyInfo rbInfo;
    public Rigidbody carRB;
    public float boostDuration = 2000f, boostMultiplier = 2f, nitroDepletion = 15f, nitroStart, nitroMin = 0f, nitroMax = 500f, nitroAdd;

    /* float nitroAmount {
        get {return nitroAmount;}
        set {_nitroAmount = Mathf.Clamp(nitroStart, nitroMin, nitroMax); }
    } */
    
    public float _nitroAmount;
    private Coroutine boostCoroutine;
    private bool boostOnce = true, nitroBoosting = false;
    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        float _nitroAmount = Mathf.Clamp(nitroStart, nitroMin, nitroMax);
        //nitroAdd = 50;
    }
    
    void Update() {
        if(nitroBoosting) {
            _nitroAmount -= Time.deltaTime * nitroDepletion;
        }
    }

    void OnTriggerEnter(Collider other) {
        
        if(other.tag == "BoostPad") {
            StopBoostPad();
            boostCoroutine = StartCoroutine(BoostPad());
        }
        if(other.tag == "NitroPickup") {
            if(_nitroAmount > nitroMax - nitroAdd) {
                _nitroAmount = nitroMax;
            }
            else {
            _nitroAmount += nitroAdd;
            
            }
            other.gameObject.SetActive(false);
            Debug.Log("Amount of nitro left = " + _nitroAmount); 

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
        Debug.Log("Nitro remaining = " + _nitroAmount);
        if(_nitroAmount > 0f) {
        nitroBoosting = true;
        carRB.velocity = carRB.velocity * boostMultiplier;
        }
        else {
            _nitroAmount = 0;
            nitroBoosting = false;
        }

        

    }

    void StopBoostPad() {
        if(boostCoroutine == null) {
            StopCoroutine(BoostPad());
            boostCoroutine = null;
        }
    }
}
