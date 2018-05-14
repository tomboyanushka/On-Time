using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    float seconds = 0.0f;
    float minutes = 0.0f;
    float hours = 0.0f;
    public GameObject hourHand;
    public GameObject minuteHand;
    public GameObject secondHand;
   

    // Use this for initialization
    void Start()
    {
       // Vector3 secondHandPos = new Vector3(secondHand.transform.rotation);
    }
	
	// Update is called once per frame
	void Update ()
    {
        seconds += Time.deltaTime;
        minutes += Time.deltaTime;
        hours += Time.deltaTime;
        if (seconds >= 0.2)
        {
            secondHand.transform.Rotate(0,10,0);
            seconds = 0.0f;
        }
        if (minutes >= 7.8f)
        {
            minuteHand.transform.Rotate(0, 10, 0);
            minutes = 0.0f;
        }

        
    }

  
}
