using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoost : MonoBehaviour
{
    //public RigidBodyInfo rbInfo;
    public Rigidbody carRB;
    public float boostDuration = 2000f, boostMultiplier, nitroBoostMultiplier, nitroDepletion = 15f, nitroStart, nitroMin = 0f, nitroMax = 500f, nitroAdd;

    /* float nitroAmount {
        get {return nitroAmount;}
        set {_nitroAmount = Mathf.Clamp(nitroStart, nitroMin, nitroMax); }
    } */
    
    public float _nitroAmount;
    private Coroutine boostCoroutine;
    private bool boostOnce = true;

    [HideInInspector] public int coinAmount = 50;
    public MissionManager ms;
    public AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        carRB = GetComponent<Rigidbody>();
        float _nitroAmount = Mathf.Clamp(nitroStart, nitroMin, nitroMax);
        //nitroAdd = 50;
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
                audioManager.Play("NitroPickup");
            }
            other.gameObject.SetActive(false);
            Debug.Log("Amount of nitro left = " + _nitroAmount); 

        }

        if(other.tag == "CoinPickup") {
            ms.MissionMoneyAdd(coinAmount);
            audioManager.Play("CoinPickup");
            Debug.Log("Yen picked up " + coinAmount);
            other.gameObject.SetActive(false);
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
        carRB.AddForce(transform.forward * nitroBoostMultiplier, ForceMode.Impulse);
        _nitroAmount -= Time.deltaTime * nitroDepletion;
        }
        else if(_nitroAmount < 0f){
            _nitroAmount = 0;
        }

        

    }

    void StopBoostPad() {
        if(boostCoroutine == null) {
            StopCoroutine(BoostPad());
            boostCoroutine = null;
        }
    }
}
