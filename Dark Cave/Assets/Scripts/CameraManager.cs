using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //The target the camera must follow
    Transform target;

    //The smoothness of the camera
    float smoothSpeed = .125f;

    Vector3 offset = new Vector3(0f, 0f, -10f);

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(Camera.main.transform.position, desiredPosition, smoothSpeed);
        Camera.main.transform.position = smoothedPosition;

        //Note this is used for for 3d games only, looks at tartget while moving to it 
        //transform.LookAt(target);
    }
}

