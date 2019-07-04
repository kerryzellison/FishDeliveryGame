using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookBehaviour : MonoBehaviour
{
    public float hookVelocity;
    bool hasHit;
    Rigidbody rb;
    GameObject hookBase;
    ConfigurableJoint joint;
    public float defaultLimit;
    public float hookToHookBase;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hookBase = GameObject.Find("Hook Base");

        joint = GetComponentInParent<ConfigurableJoint>();
        //initialPos = joint.connectedAnchor;
        ResetHook();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hookToHookBase = Vector3.Distance(transform.position,hookBase.transform.position);
        
        if( JointReachedLimit() && !hasHit)
        {
            ResetHook();
        }
        else if(JointReachedLimit() && !hasHit)
        {
            ResetHook();
        }
    }

    void ResetHook()
    {
            rb.velocity=Vector3.zero;
            transform.SetPositionAndRotation(hookBase.transform.position, hookBase.transform.rotation);
            constrainPosition(true);
            hasHit=false;
            transform.SetParent(joint.transform);
            joint.linearLimit = SetLinearLimit(joint, defaultLimit);
    }

    public void ShootHook()
    {
        if(hasHit)
        {
            ResetHook();
        }
        else
        {
            constrainPosition(false);
            rb.AddForce(transform.forward*hookVelocity,ForceMode.VelocityChange);
        }


    }

    private bool JointReachedLimit(bool addVelocity = false)
    {
        if (addVelocity)
        {
            hookToHookBase += hookVelocity/5;
        }

        if(hookToHookBase>defaultLimit)
            return true;
        else
            return false;
    }

    public bool GetHasHit()
    {
        return hasHit;
    }

    private SoftJointLimit SetLinearLimit(ConfigurableJoint joint,  float Lenght)
    {
        SoftJointLimit softJoint = joint.linearLimit;
        softJoint.limit = Lenght;

        return softJoint;
    }

    void constrainPosition(bool boolean)
    {
        if (boolean)
        {
            rb.constraints = RigidbodyConstraints.FreezePosition; 
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            Debug.Log("colliding");
            constrainPosition(true);
            transform.parent = null;
            hasHit = true;
            joint.linearLimit = SetLinearLimit(joint, hookToHookBase+1);
        }
    }
}
