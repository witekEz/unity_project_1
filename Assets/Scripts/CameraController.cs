using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject sphereObject;

    public Vector3 distance;
    public float lookUp;
    public float lerpAmount;

    

    void Start()
    {
        sphereObject = GameObject.FindGameObjectWithTag("Player");
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, sphereObject.transform.position + distance, lerpAmount * Time.deltaTime);
        transform.LookAt(sphereObject.transform.position);
        transform.Rotate(-lookUp, 0, 0);
    }
}
