using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float xMin = 0.0f;
    private const float xMax = 50.0f;


    public Transform lookAt;
    public Transform cameraTransform;

    private Camera cam;
    private float distance = 10f;
    private float currentX = 0f;
    private float currentY = 0f;

    void Start()
    {
        cameraTransform = transform;
        cam = Camera.main;

        
    }
    private void Update()
    {
        currentX += Input.GetAxis("Mouse Y");
        currentY += Input.GetAxis("Mouse X");

        currentX = Mathf.Clamp(currentX, xMin, xMax);

    }


    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        cameraTransform.position = lookAt.position + rotation * dir;
        cameraTransform.LookAt(lookAt.position);

    }



}
