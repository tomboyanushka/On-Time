using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float inputDelay = 0.1f;
    public float forwardVelocity = 12;
    public float rotateVelocity = 100;
    public float jumpVelocity = 25;
    public float distToGround = 0.1f;
    public LayerMask Ground;
    public float downwardAccel = 1.0f;
    private float toolCount = 0;
    private bool isDead = false;

    Animator anim;

    Vector3 velocity = Vector3.zero;

    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround, Ground);
    }


    public float health = 100f;

    Quaternion playerRotation;

    Rigidbody rigidbody;
    float forwardInput;
    float rotateInput;
    float jumpInput;

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

        forwardInput = rotateInput = jumpInput = 0;

        anim = GetComponent<Animator>();
	}

    void getInput()
    {
        forwardInput = Input.GetAxis("Vertical");
        rotateInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetAxisRaw("Jump");
    }

    private void Update()
    {
        getInput();
        Rotate();

        if (toolCount == 5 && isDead == false)
        {
            PlayerWins();
        }

        if (health == 0)
        {
            isDead = true;
            PlayerDies();
        }
    }

    private void FixedUpdate()
    {
        Move();
        Jump();

        rigidbody.velocity = transform.TransformDirection(velocity);
    }

    private void Move()
    {
        if (Mathf.Abs(forwardInput) > inputDelay)
        {
            velocity.z = forwardInput * forwardVelocity;
        }
        else
            velocity.z = 0;
        anim.Play("Robo2 Idle");
    }

    private void Jump()
    {
        if (jumpInput > 0 && isGrounded())
        {
            velocity.y = jumpVelocity;
        }
        else if (jumpInput == 0 && isGrounded())
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y -= downwardAccel;
        }

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
        else if (collision.gameObject.tag == "Tool")
        {
            anim.Play("");
            Destroy(collision.gameObject);
            toolCount += 1;
        }
    }

    void PlayerWins()
    {
        Debug.Log("You Win!");
    }

    void PlayerDies()
    {
        Debug.Log("Game Over");
    }

}
