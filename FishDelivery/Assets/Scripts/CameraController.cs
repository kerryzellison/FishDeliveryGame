using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject car;
    Vector3 initialCameraOffsetDirection;

    Vector3 CurrentCameraOffsetDirection;
    public float CameraDistance;

    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car");

        initialCameraOffsetDirection=CameraToObjectOffset(car);


    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = SetForwardDirectionToObject(car);
        CurrentCameraOffsetDirection= CameraToObjectOffset(car);
        transform.position = CurrentCameraOffsetDirection*CameraDistance+car.transform.position;


        

    }

    Vector3 SetForwardDirectionToObject(GameObject go)
    {
        Vector3 cameraToObjectDirection;
        cameraToObjectDirection = Vector3.Normalize(go.transform.position - transform.position);
        return cameraToObjectDirection;
    }

    Vector3 CameraToObjectOffset(GameObject go)
    {
        Vector3 offset;
        offset = Vector3.Normalize(transform.position - go.transform.position);
        return offset;
    }

    public void RotateCamera(float vertical, float horizontal)
    {
        transform.position +=transform.up*vertical*0.25f +transform.right*horizontal*0.25f;
    }

    public void ResetCamera()
    {
        CurrentCameraOffsetDirection = initialCameraOffsetDirection;
    }
}
