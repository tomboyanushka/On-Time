using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    GameObject tool;
	// Use this for initialization
	void Start ()
    {
        tool = this.gameObject;
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Rotate(Vector3.up * Time.deltaTime, Space.World);
    }
}
