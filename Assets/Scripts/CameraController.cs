using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    Camera cam;
    public Vector3 offset = new Vector3(0,5,-8);
    public float XTilt = 10;
    public float smooth = 0.09f;

    Vector3 destination = Vector3.zero;
    CharacterController charController;
    float rotateVelocity = 0;

   


    void Start()
    {
        charController = target.GetComponent<CharacterController>();
    }

    void LateUpdate()
    {

        MoveToTarget();
        LookAtTarget();
       
    }


    void MoveToTarget()
    {
        destination = charController.PlayerRotation * offset;
        destination += target.position;
        transform.position = destination;
    }
    void LookAtTarget()
    {
        float eulerAngleY = Mathf.SmoothDampAngle(transform.eulerAngles.y, target.eulerAngles.y, ref rotateVelocity, smooth);
        transform.rotation = Quaternion.Euler(transform.eulerAngles.x, eulerAngleY, 0);
    }

}
