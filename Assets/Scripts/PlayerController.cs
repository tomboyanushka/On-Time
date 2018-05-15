using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 4.0f;
    public float maxSpeed = 8.0f;

   
    Rigidbody rigidbody;
    float health = 100f;
    
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        

	}
	
	// Update is called once per frame
	void Update ()
    {

        

        if (Input.GetKey(KeyCode.W))
        {
           
            rigidbody.AddForce(Vector3.forward * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.AddForce(Vector3.left * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.AddForce(Vector3.back * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Debug.Log("space");

            rigidbody.AddForce(Vector3.up * 10, ForceMode.Impulse);
            


        }
        //Debug.Log(health);
        rigidbody.velocity = Vector3.ClampMagnitude(rigidbody.velocity, 10);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "minute")
            health -= 20f;
        else if (collision.gameObject.tag == "hour")
            health -= 10f;
  
    }
}
