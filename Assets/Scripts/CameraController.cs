using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Camera cam;
    float offset = 5.0f;
    public float smooth = 2.0f;

    public Vector2 mouseLook;
    public Vector2 rotate;

    public Quaternion rotateY;


    void Start()
    {
        
    }

    void LateUpdate()
    {
       

        //transform.LookAt( target + offset);
    }
}
