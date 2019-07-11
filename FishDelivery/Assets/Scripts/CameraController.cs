using System;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [Serializable]
    public class AdvancedOptions
    {
        public bool updateCameraInUpdate;
        public bool updateCameraInFixedUpdate = true;
        public bool updateCameraInLateUpdate;
    }
    public float baseSmoothing = 2;
    public float distFactor;
    public Transform lookAtTarget;
    public Transform positionTarget;
    public Transform reverseView;
    public AdvancedOptions advancedOptions;

    GameObject player;
    InputManager2 playerInput;

    //bool m_ShowingReverseView;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerInput = player.GetComponent<InputManager2>();
    }

    private void FixedUpdate()
    {
        if (advancedOptions.updateCameraInFixedUpdate)
            UpdateCamera();
    }


    private void Update()
    {
        if (advancedOptions.updateCameraInUpdate)
            UpdateCamera();
    }

    private void LateUpdate()
    {
        if (advancedOptions.updateCameraInLateUpdate)
            UpdateCamera();
    }

    private void UpdateCamera()
    {
        transform.position = Vector3.Lerp(transform.position, positionTarget.position, Time.deltaTime * baseSmoothing * (Vector3.Distance(transform.position, positionTarget.position) * distFactor));
        transform.LookAt(lookAtTarget);
    }

    public void ChangeCameraViewToReverse()
    {
        transform.position = reverseView.position;
        transform.LookAt(lookAtTarget);
    }
}