using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    float minutes = 0.0f;
    float hours = 0.0f;
    public GameObject hourHand;
    public GameObject minuteHand;
    
    


    // Use this for initialization
    void Start()
    {
       
        
    }
	
	// Update is called once per frame
	void Update ()
    {
       
        minutes += Time.deltaTime;
        hours += Time.deltaTime;

        if (minutes >= 0.02f)
        {
            minuteHand.transform.localRotation = Quaternion.Lerp(minuteHand.transform.localRotation, minuteHand.transform.rotation * Quaternion.Euler(0, 90, 0), 0.05f);
            minutes = 0.0f;
            
        }

        if (hours >= 5f)
        {
            hourHand.transform.localRotation = Quaternion.Lerp(hourHand.transform.localRotation, hourHand.transform.rotation * Quaternion.Euler(0, 90, 0), 0.05f);
            hours = 0.0f;
            GetComponent<AudioSource>().Play();
        }



    }

  
}
