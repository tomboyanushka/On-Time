using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandLight : MonoBehaviour
{
    private const float PULSE_RANGE = 4.0f;
    private const float PULSE_SPEED = 3.0f;

    private const float PULSE_MINIMUM = 1.0f;

    private Light lt;

    
  
    void Start()
    {
        lt = GetComponent<Light>();
        
    }
    void Update()
    {

        lt.range = PULSE_MINIMUM +  Mathf.PingPong(Time.time * PULSE_SPEED, PULSE_RANGE - PULSE_MINIMUM);
    }

}
