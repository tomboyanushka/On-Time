﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunandMoon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.RotateAround(Vector3.zero, Vector3.right, 10 * Time.deltaTime);
        transform.LookAt(Vector3.zero);
	}
}
