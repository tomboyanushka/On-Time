using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float inputDelay = 0.1f;
    public float velocity = 12;
    public float rotateVelocity = 100;

    public float health = 100f;

    Quaternion playerRotation;

    Rigidbody rigidbody;
    float forwardInput, rotateInput;

    public Quaternion PlayerRotation
    {
        get { return playerRotation; }
    }

	// Use this for initialization
	void Start ()
    {
        playerRotation = transform.rotation;
        if (GetComponent<Rigidbody>())
        {
            rigidbody = GetComponent<Rigidbody>();

        }
        else Debug.LogError("Character needs a rigidbody");
	}

    void getInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");
    }

    private void Update()
    {
        getInput();
        Rotate();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            rigidbody.velocity = transform.forward * forwardInput * velocity;
        }
        else
            rigidbody.velocity = Vector3.zero;
    }

    private void Rotate()
    {
        if (Mathf.Abs(rotateInput) > inputDelay)
        {
            playerRotation *= Quaternion.AngleAxis(rotateVelocity * rotateInput * Time.deltaTime, Vector3.up);
            transform.rotation = playerRotation;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "minute")
        {
            health -= 10f;
            Debug.Log(health);
        }
        else if (collision.gameObject.tag == "hour")
        {
            health -= 20f;
            Debug.Log(health);

        }
        else if (collision.gameObject.tag == "Stand")
        {
            health = 100f;
            Debug.Log(health);

        }
    }

}
