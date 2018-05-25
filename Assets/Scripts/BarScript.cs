using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScript : MonoBehaviour
{
    [SerializeField]
    private float fillAmount;

    [SerializeField]
    private Image healthVisual;

    public float maxValue
    {
        get; set;
    }

    public float Value
    {
        set
        {
            fillAmount = MapHealth(value, 0, maxValue, 0, 1);
        }
    }



    private void Start()
    {
        
    }

    private void Update()
    {
        HandleBar(); 
    }

    void HandleBar()
    {
        if(fillAmount != healthVisual.fillAmount)
            healthVisual.fillAmount = fillAmount;
    }

    private float MapHealth(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
