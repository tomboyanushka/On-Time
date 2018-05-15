using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public float speed = 4.0f;
    //public float maxVelocity = 8.0f;

   
    Rigidbody rigidbody;
    float health = 100f;
    public bool walking = false;

    Animator anim;
    
    void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 inputDirection = input.normalized;

        if (inputDirection != Vector2.zero)
        {
            transform.eulerAngles = Vector3.up * Mathf.Atan2(inputDirection.x , inputDirection.y) * Mathf.Rad2Deg;
            walking = true;
        }

        
        bool jumping = Input.GetKey(KeyCode.Space);
        float velocity = speed * inputDirection.magnitude;
        transform.Translate(Vector3.forward * velocity * Time.deltaTime, Space.World);
        anim.SetInteger("Speed", 1);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "minute")
            health -= 20f;
        else if (collision.gameObject.tag == "hour")
            health -= 10f;
  
    }
}
