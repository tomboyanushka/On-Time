using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarScripts : MonoBehaviour
{
    public float speed;
    public RectTransform healthBar;
    public float Y;
    private float minX;
    private float maxX;

    public float currentHealth;
    public float maxHealth;

    public Text healthtext;
    public Image HealthV;

    CharacterController c;




    // Use this for initialization
    void Start ()
    {
        c = GetComponent<CharacterController>();
        Y = healthBar.transform.position.y;
        maxX = healthBar.transform.position.x;
        minX = healthBar.transform.position.x - healthBar.rect.width;

        maxHealth = 100;
        //currentHealth = c.health;
	}

    private float MapHealth(float x, float inMin, float inMax, float outMin, float outMax)
    {
        return (x - inMin) * (outMax = outMin) / (inMax - inMin) + outMin;
    }
	
	// Update is called once per frame
	void Update ()
    {
        //currentHealth = c.health;
	}

    public void Playerhealth()
    {
        healthtext.text = "Health: " + currentHealth;

        float currentX = MapHealth(currentHealth, 0, maxHealth, minX, maxX);

        healthBar.position = new Vector3(currentX, Y);

        if (currentHealth > maxHealth / 2)
        {
            HealthV.color = new Color32((byte)MapHealth(currentHealth, maxHealth / 2, maxHealth, 255, 0), 255, 0, 255);
        }
        else
        {
            HealthV.color = new Color32(255, (byte)MapHealth(currentHealth, 0, maxHealth / 2, 0, 255), 0, 255);
        }
    }
}
