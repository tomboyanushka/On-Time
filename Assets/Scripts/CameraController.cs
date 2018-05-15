using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Transform cameraTransform;

   
    
    void Start()
    {
        cameraTransform = transform;
       


    }


    private void LateUpdate()
    {
       
  
        cameraTransform.LookAt(target.position);

    }
}
