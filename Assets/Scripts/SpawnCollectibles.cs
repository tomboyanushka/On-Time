using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectibles : MonoBehaviour
{
    public GameObject[] collectibles;
    Vector3 area;
    float timeDelay;
    

	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        timeDelay += Time.deltaTime;
        if (timeDelay >= 5)
        {
            area = new Vector3(Random.Range(60, -60), 5f, Random.Range(70, -70));
            Instantiate(collectibles[Random.Range(0, collectibles.Length)], area, Quaternion.identity);
            timeDelay = 0f;
        }
	}
}
