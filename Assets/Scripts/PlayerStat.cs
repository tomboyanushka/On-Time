using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerStat
{
    [SerializeField]
    private BarScript barScript;
    [SerializeField]
    private float maxVal;
    [SerializeField]
    private float currentVal;

    public void Init()
    {
        this.MaxValue = maxVal;
        this.CurrentValue = currentVal;
    }

    public float CurrentValue
    {
        get
        {
            return currentVal;
        }

        set
        {
            currentVal = value;
            barScript.Value = currentVal;
        }
    }

    public float MaxValue
    {
        get
        {
            return maxVal;
        }

        set
        {
            maxVal = value;
            barScript.maxValue = maxVal;
        }
    }
}
